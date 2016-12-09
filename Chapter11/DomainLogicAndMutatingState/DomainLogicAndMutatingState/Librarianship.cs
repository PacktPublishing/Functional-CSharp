using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DomainLogicAndMutatingState
{
    public class Librarianship
    {
        private readonly int _maxEntriesPerFile;

        public Librarianship(
            int maxEntriesPerFile)
        {
            _maxEntriesPerFile =
                maxEntriesPerFile;
        }

        public void AddRecord(
            string currentFile,
            string visitorName,
            string bookTitle,
            DateTime returnDate)
        {
            if (!File.Exists(currentFile))
            {
                string newLine =
                    String.Format(
                        "1;{0};{1};{2}",
                        visitorName,
                        bookTitle,
                        returnDate
                            .ToString("d")
                        );

                File.WriteAllLines(
                    currentFile,
                    new[] {
                        newLine });
            }
            else
            {
                string[] lines = File.ReadAllLines(
                    currentFile);

                if (lines.Length < _maxEntriesPerFile)
                {
                    int lastIndex = int.Parse(
                        lines.Last()
                            .Split(';')[0]);

                    string newLine =
                        String.Format(
                            "{0};{1};{2};{3}",
                            (lastIndex + 1),
                            visitorName,
                            bookTitle,
                            returnDate
                                .ToString("d")
                            );

                    File.AppendAllLines(
                        currentFile,
                        new[] {
                        newLine });
                }
                else
                {
                    string newLine =
                        String.Format(
                            "1;{0};{1};{2}",
                            visitorName,
                            bookTitle,
                            returnDate
                                .ToString("d")
                            );

                    string newFileName =
                        GetNewFileName(
                            currentFile);

                    File.WriteAllLines(
                        newFileName,
                        new[] {
                        newLine });

                    currentFile = newFileName;
                }
            }
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

        public void RemoveRecord(
            string visitorName,
            string directoryName)
        {
            foreach (string fileName in Directory.GetFiles(
                directoryName))
            {
                string tempFile = Path.GetTempFileName();
                List<string> linesToKeep = File
                    .ReadLines(fileName)
                    .Where(line => !line.Contains(visitorName))
                    .ToList();

                if (linesToKeep.Count == 0)
                {
                    File.Delete(
                        fileName);
                }
                else
                {
                    File.WriteAllLines(
                        tempFile,
                        linesToKeep);

                    File.Delete(
                        fileName);

                    File.Move(
                        tempFile,
                        fileName);
                }
            }
        }
    }
}
