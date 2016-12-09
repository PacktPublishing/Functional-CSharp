using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DomainLogicAndMutatingState.Test
{
    [TestClass]
    public partial class LibrarianshipImmutableTest
    {
        [TestMethod]
        // Add record to existing log file 
        // but the lines is lower then maxEntriesPerFile 
        public void AddRecord_LinesIsLowerThanMaxEntriesPerFileTest()
        {
            LibrarianshipImmutable librarian = 
                new LibrarianshipImmutable(5);

            FileContent file = new FileContent(
                "LibraryLog_0001.txt", 
                new[]{
                    "1;Arthur Jackson;Responsive Web Design;9/26/2016"
                });

            FileAction action = librarian.AddRecord(
                file,
                "Maddox Webb",
                "AngularJS by Example",
                new DateTime(
                    2016, 9, 27, 0, 0, 0));

            Assert.AreEqual(
                ActionType.Update, 
                action.Type);
            Assert.AreEqual(
                "LibraryLog_0001.txt", 
                action.FileName);
            CollectionAssert.AreEqual(
                new[]{
                    "1;Arthur Jackson;Responsive Web Design;9/26/2016",
                    "2;Maddox Webb;AngularJS by Example;9/27/2016"
                },
                action.Content);
        }

        [TestMethod]
        // Add record to a new log file 
        // becausecurrent log file has reached maxEntriesPerFile 
        public void AddRecord_LinesHasReachMaxEntriesPerFileTest()
        {
            LibrarianshipImmutable librarian = 
                new LibrarianshipImmutable(3);

            FileContent file = new FileContent(
                "LibraryLog_0001.txt", 
                new[]{
                    "1;Arthur Jackson;Responsive Web Design;9/26/2016",
                    "2;Maddox Webb;AngularJS by Example;9/27/2016",
                    "3;Mel Fry;Python Machine Learning;9/28/2016"
                });

            FileAction action = librarian.AddRecord(
                file,
                "Haiden Brown",
                "Practical Data Science",
                new DateTime(2016, 9, 29, 0, 0, 0));

            Assert.AreEqual(
                ActionType.Create, 
                action.Type);
            Assert.AreEqual(
                "LibraryLog_0002.txt", 
                action.FileName);
            CollectionAssert.AreEqual(
                new[]{
                    "1;Haiden Brown;Practical Data Science;9/29/2016"
                }, 
                action.Content);
        }

        [TestMethod]
        // Remove selected record from files in the directory
        public void RemoveRecord_FilesIsAvailableInDirectoryTest()
        {
            LibrarianshipImmutable librarian = 
                new LibrarianshipImmutable(10);

            FileContent file = new FileContent(
                "LibraryLog_0001.txt", 
                new[]
                {
                    "1;Arthur Jackson;Responsive Web Design;9/26/2016",
                    "2;Maddox Webb;AngularJS by Example;9/27/2016",
                    "3;Mel Fry;Python Machine Learning;9/28/2016"
                });

            IReadOnlyList<FileAction> actions = 
                librarian.RemoveRecord(
                    "Arthur Jackson", 
                    new[] {
                        file });

            Assert.AreEqual(
                1, 
                actions.Count);

            Assert.AreEqual(
                "LibraryLog_0001.txt", 
                actions[0].FileName);

            Assert.AreEqual(
                ActionType.Update, 
                actions[0].Type);

            CollectionAssert.AreEqual(
                new[]{
                    "1;Maddox Webb;AngularJS by Example;9/27/2016",
                    "2;Mel Fry;Python Machine Learning;9/28/2016"
                }, 
                actions[0].Content);
        }

        [TestMethod]
        // Remove selected record from files in the directory
        // If file becomes empty, it will be deleted
        public void RemoveRecord_FileBecomeEmptyTest()
        {

            LibrarianshipImmutable librarian =
                new LibrarianshipImmutable(10);

            FileContent file = new FileContent(
                "LibraryLog_0001.txt",
                new[]
                {
                    "1;Arthur Jackson;Responsive Web Design;9/26/2016"
                });

            IReadOnlyList<FileAction> actions =
                librarian.RemoveRecord(
                    "Arthur Jackson", 
                    new[] {
                        file });

            Assert.AreEqual(
                1, 
                actions.Count);

            Assert.AreEqual(
                "LibraryLog_0001.txt", 
                actions[0].FileName);

            Assert.AreEqual(
                ActionType.Delete, 
                actions[0].Type);
        }

        [TestMethod]
        // Remove nothing if selected record is unavailable
        public void RemoveRecord_SelectedRecordIsUnavailableTest()
        {
            LibrarianshipImmutable librarian =
                new LibrarianshipImmutable(10);

            FileContent file = new FileContent(
                "LibraryLog_0001.txt",
                new[]
                {
                    "1;Sofia Hamilton;DevOps Automation;9/30/2016"
                });

            IReadOnlyList<FileAction> actions =
                librarian.RemoveRecord(
                    "Arthur Jackson",
                    new[] {
                        file });

            Assert.AreEqual(
                0, 
                actions.Count);
        }
    }
}
