using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DomainLogicAndMutatingState
{
    public class AppService
    {
        private readonly string _directoryName;
        private readonly LibrarianshipImmutable _librarian;
        private readonly FileProcessor _fileProcessor;

        public AppService(
            string directoryName)
        {
            _directoryName = directoryName;
            _librarian = new LibrarianshipImmutable(10);
            _fileProcessor = new FileProcessor();
        }

        public void AddRecord(
            string visitorName,
            string bookTitle,
            DateTime returningDate)
        {
            FileInfo fileInfo = new DirectoryInfo(
                _directoryName)
                    .GetFiles()
                    .OrderByDescending(x =>
                        x.LastWriteTime)
                    .First();

            FileContent file =
                _fileProcessor.ReadFile(
                    fileInfo.Name);

            FileAction action =
                _librarian.AddRecord(
                    file,
                    visitorName,
                    bookTitle,
                    returningDate);

            _fileProcessor.ApplyChange(
                action);
        }

        public void RemoveRecord(
            string visitorName)
        {
            FileContent[] files =
                _fileProcessor.ReadDirectory(
                    _directoryName);

            IReadOnlyList<FileAction> actions =
                _librarian.RemoveRecord(
                    visitorName, files);

            _fileProcessor.ApplyChanges(
                actions);
        }
    }
}
