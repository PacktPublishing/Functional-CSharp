using System;
using System.Collections.Generic;
using System.Linq;

namespace Projecting
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //SelectOperator();
            SelectManyOperator();
        }
    }

    public partial class Program
    {
        public static void SelectOperator()
        {
            List<Member> memberList = new List<Member>()
            {
                new Member
                {
                    ID = 1,
                    Name = "Eddie Morgan",
                    Gender = "Male",
                    MemberSince = new DateTime(2016, 2, 10)
                },
                new Member
                {
                    ID = 2,
                    Name = "Millie Duncan",
                    Gender = "Female",
                    MemberSince = new DateTime(2015, 4, 3)
                },
                new Member
                {
                    ID = 3,
                    Name = "Thiago Hubbard",
                    Gender = "Male",
                    MemberSince = new DateTime(2014, 1, 8)
                },
                new Member
                {
                    ID = 4,
                    Name = "Emilia Shaw",
                    Gender = "Female",
                    MemberSince = new DateTime(2015, 11, 15)
                }
            };

            //IEnumerable<RecentMember> memberQuery =
            //    from m in memberList
            //    where m.MemberSince.Year > 2014
            //    orderby m.Name
            //    select new RecentMember{
            //        FirstName = m.Name.GetFirstName(),
            //        LastName = m.Name.GetLastName(),
            //        Gender = m.Gender,
            //        MemberSince = m.MemberSince,
            //        Status = "Valid"
            //    };

            IEnumerable<RecentMember> memberQuery =
                memberList
                    .Where(m => m.MemberSince.Year > 2014)
                    .OrderBy(m => m.Name)
                    .Select(m => new RecentMember
                        {
                            FirstName = m.Name.GetFirstName(),
                            LastName = m.Name.GetLastName(),
                            Gender = m.Gender,
                            MemberSince = m.MemberSince,
                            Status = "Valid"
                        });

            foreach (RecentMember rm in memberQuery)
            {
                Console.WriteLine(
                    "First Name  : " + rm.FirstName);
                Console.WriteLine(
                    "Last Name   : " + rm.LastName);
                Console.WriteLine(
                    "Gender      : " + rm.Gender);
                Console.WriteLine
                    ("Member Since: " + 
                    rm.MemberSince.ToString("dd/MM/yyyy"));
                Console.WriteLine(
                    "Status      : " + rm.Status);
                Console.WriteLine();
            }
        }
    }

    public partial class Program
    {
        public static void SelectManyOperator()
        {
            List<string> numberTypes = new List<string>()
            {
                "Multiplied by 2",
                "Multiplied by 3"
            };

            List<int> numbers = new List<int>()
            {
                6, 12, 18, 24
            };

            //IEnumerable<NumberType> query =
            //    numbers.SelectMany(
            //        num => numberTypes, 
            //        (n, t) => new NumberType
            //        {
            //            TheNumber = n,
            //            TheType = t
            //        });

            IEnumerable<NumberType> query =
                from n in numbers
                from t in numberTypes
                select new NumberType
                {
                    TheNumber = n,
                    TheType = t
                };

            foreach (NumberType nt in query)
            {
                Console.WriteLine(
                    String.Format(
                        "Number: {0,2} - Types: {1}",
                        nt.TheNumber,
                        nt.TheType));
            }
        }
    }

    public class NumberType
    {
        public int TheNumber { get; set; }
        public string TheType { get; set; }
    }

    public class Member
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime MemberSince { get; set; }
    }

    public class RecentMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime MemberSince { get; set; }
        public string Status { get; set; }
    }

    public static class ExtensionMethod
    {
        public static string GetFirstName(this string FullName)
        {
            string[] splitFullName = FullName.Split(' ');
            return splitFullName.First();
        }

        public static string GetLastName(this string FullName)
        {
            string[] splitFullName = FullName.Split(' ');
            return splitFullName.Last();
        }
    }
}
