using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DomainLogicAndMutatingState
{
    public class LibrarianshipImmutable
    {
        private readonly int _maxEntriesPerFile;

        public LibrarianshipImmutable(
            int maxEntriesPerFile)
        {
            _maxEntriesPerFile =
                maxEntriesPerFile;
        }

        public FileAction AddRecord(
            FileContent currentFile,
            string visitorName,
            string bookTitle,
            DateTime returningDate)
        {
            List<DataEntry> entries = Parse(currentFile.Content);

            if (entries.Count < _maxEntriesPerFile)
            {
                entries.Add(
                    new DataEntry(
                        entries.Count + 1,
                        visitorName,
                        bookTitle,
                        returningDate));

                string[] newContent =
                    Serialize(
                        entries);

                return new FileAction(
                    currentFile.FileName,
                    ActionType.Update,
                    newContent);
            }
            else
            {
                var entry = new DataEntry(
                    1,
                    visitorName,
                    bookTitle,
                    returningDate);

                string[] newContent =
                    Serialize(
                        new List<DataEntry> { entry });

                string newFileName =
                    GetNewFileName(
                        currentFile.FileName);

                return new FileAction(
                    newFileName,
                    ActionType.Create,
                    newContent);
            }
        }

        private string[] Serialize(
            List<DataEntry> entries)
        {
            return entries
                .Select(entry =>
                    String.Format(
                        "{0};{1};{2};{3}",
                        entry.Number,
                        entry.Visitor,
                        entry.BookTitle,
                        entry.ReturningDate
                            .ToString("d")))
                .ToArray();
        }

        private List<DataEntry> Parse(
            string[] content)
        {
            var result = new List<DataEntry>();

            foreach (string line in content)
            {
                string[] data = line.Split(';');
                result.Add(
                    new DataEntry(
                        int.Parse(data[0]),
                        data[1],
                        data[2],
                        DateTime.Parse(data[3])));
            }

            return result;
        }

        private string GetNewFileName(
            string existingFileName)
        {
            string fileName =
                Path.GetFileNameWithoutExtension(
                    existingFileName);
            int index = int.Parse(
                fileName
                    .Split('_')[1]);

            return String.Format(
                "LibraryLog_{0:D4}.txt",
                index + 1);
        }

        public IReadOnlyList<FileAction> RemoveRecord(
            string visitorName,
            FileContent[] directoryFiles)
        {
            return directoryFiles
                .Select(file =>
                    RemoveRecordIn(
                        file,
                        visitorName))
                .Where(action =>
                    action != null)
                .Select(action =>
                    action.Value)
                .ToList();
        }

        private FileAction? RemoveRecordIn(
            FileContent file,
            string visitorName)
        {
            List<DataEntry> entries = Parse(
                file.Content);

            List<DataEntry> newContent = entries
                .Where(x =>
                    x.Visitor != visitorName)
                .Select((entry, index) =>
                    new DataEntry(
                        index + 1,
                        entry.Visitor,
                        entry.BookTitle,
                        entry.ReturningDate))
                .ToList();

            if (newContent.Count == entries.Count)
                return null;

            if (newContent.Count == 0)
            {
                return new FileAction(
                    file.FileName,
                    ActionType.Delete,
                    new string[0]);
            }
            else
            {
                return new FileAction(
                    file.FileName,
                    ActionType.Update,
                    Serialize(
                        newContent));
            }
        }
    }

    public struct FileContent
    {
        public readonly string FileName;
        public readonly string[] Content;

        public FileContent(
            string fileName,
            string[] content)
        {
            FileName = fileName;
            Content = content;
        }
    }

    public struct FileAction
    {
        public readonly string FileName;
        public readonly string[] Content;
        public readonly ActionType Type;

        public FileAction(
            string fileName,
            ActionType type,
            string[] content)
        {
            FileName = fileName;
            Type = type;
            Content = content;
        }
    }

    public enum ActionType
    {
        Create,
        Update,
        Delete
    }

    public struct DataEntry
    {
        public readonly int Number;
        public readonly string Visitor;
        public readonly string BookTitle;
        public readonly DateTime ReturningDate;

        public DataEntry(
            int number,
            string visitor,
            string bookTitle,
            DateTime returningDate)
        {
            Number = number;
            Visitor = visitor;
            BookTitle = bookTitle;
            ReturningDate = returningDate;
        }
    }
}
