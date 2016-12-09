using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DomainLogicAndMutatingState
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //LibrarianshipInvocation();
            LibrarianshipImmutableInvocation();
        }
    }

    public partial class Program
    {
        public static void LibrarianshipInvocation()
        {
            Librarianship librarian = 
                new Librarianship(5);

            for (int i = 0; i < bookList.Count; i++)
            {
                librarian.AddRecord(
                    GetLastLogFile(
                        AppDomain.CurrentDomain.BaseDirectory),
                    bookList[i].Borrower,
                    bookList[i].Title,
                    DateTime.Now.AddDays(i));
            }
        }
    }

    //public partial class Program
    //{
    //    public static void LibrarianshipImmutableInvocation()
    //    {
    //        LibrarianshipImmutable librarian =
    //            new LibrarianshipImmutable(5);

    //        for (int i = 0; i < bookList.Count; i++)
    //        {
    //            librarian.AddRecord(
    //                GetLastLogFile(
    //                    AppDomain.CurrentDomain.BaseDirectory),
    //                bookList[i].Borrower,
    //                bookList[i].Title,
    //                DateTime.Now.AddDays(i));
    //        }
    //    }
    //}

    public partial class Program
    {
        public static void LibrarianshipImmutableInvocation()
        {
            AppService appService = new AppService(
                AppDomain.CurrentDomain.BaseDirectory);

            for (int i = 0; i < bookList.Count; i++)
            {
                appService.AddRecord(
                    bookList[i].Borrower,
                    bookList[i].Title,
                    DateTime.Now.AddDays(i));
            }
        }
    }

    public partial class Program
    {
        public static List<Book> bookList =
            new List<Book>()
            {
                new Book(
                    "Arthur Jackson",
                    "Responsive Web Design"),
                new Book(
                    "Maddox Webb",
                    "AngularJS by Example"),
                new Book(
                    "Mel Fry",
                    "Python Machine Learning"),
                new Book(
                    "Haiden Brown",
                    "Practical Data Science Cookbook"),
                new Book(
                    "Sofia Hamilton",
                    "DevOps Automation Cookbook")
            };
    }

    public partial class Program
    {
        public static string GetLastLogFile(
            string LogDirectory)
        {
            string[] logFiles = Directory.GetFiles(
                LogDirectory, 
                "LibraryLog_????.txt");

            if (logFiles.Length > 0)
            {
                return logFiles[logFiles.Length - 1];
            }
            else
            {
                return "LibraryLog_0001.txt";
            }
        }
    }

    public struct Book
    {
        public string Borrower { get; }
        public string Title { get; }

        public Book(
            string borrower,
            string title)
        {
            Borrower = borrower;
            Title = title;
        }
    }
}
