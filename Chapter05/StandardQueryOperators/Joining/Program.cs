using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joining
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //JoinOperator();
            GroupJoinOperator();
        }
    }

    public partial class Program
    {
        public static void JoinOperator()
        {
            Course hci = new Course{
                Title = "Human Computer Interaction",
                CreditHours = 3};

            Course iis = new Course{
                Title = "Information in Society",
                CreditHours = 2};

            Course modr = new Course{
                Title = "Management of Digital Records",
                CreditHours = 3};

            Course micd = new Course{
                Title = "Moving Image Collection Development",
                CreditHours = 2};

            Student carol = new Student{
                Name = "Carol Burks",
                CourseTaken = modr};

            Student river = new Student{
                Name = "River Downs",
                CourseTaken = micd};

            Student raylee = new Student{
                Name = "Raylee Price",
                CourseTaken = hci};

            Student jordan = new Student{
                Name = "Jordan Owen",
                CourseTaken = modr};

            Student denny = new Student{
                Name = "Denny Edwards",
                CourseTaken = hci};

            Student hayden = new Student{
                Name = "Hayden Winters",
                CourseTaken = iis};

            List<Course> courses = new List<Course>{
                hci, iis, modr, micd};

            List<Student> students = new List<Student>{
                carol, river, raylee, jordan, denny, hayden};

            //var query = courses.Join(
            //    students,
            //    course => course,
            //    student => student.CourseTaken,
            //    (course, student) =>
            //        new {
            //            StudentName = student.Name,
            //            CourseTaken = course.Title });

            var query =
                from c in courses
                join s in students on c.Title equals s.CourseTaken.Title
                select new {
                    StudentName = s.Name,
                    CourseTaken = c.Title };

            foreach (var item in query)
            {
                Console.WriteLine(
                    "{0} - {1}",
                    item.StudentName,
                    item.CourseTaken);
            }
        }
    }

    public partial class Program
    {
        public static void GroupJoinOperator()
        {
            Course hci = new Course{
                Title = "Human Computer Interaction",
                CreditHours = 3};

            Course iis = new Course{
                Title = "Information in Society",
                CreditHours = 2};

            Course modr = new Course{
                Title = "Management of Digital Records",
                CreditHours = 3};

            Course micd = new Course{
                Title = "Moving Image Collection Development",
                CreditHours = 2};

            Student carol = new Student{
                Name = "Carol Burks",
                CourseTaken = modr};

            Student river = new Student{
                Name = "River Downs",
                CourseTaken = micd};

            Student raylee = new Student{
                Name = "Raylee Price",
                CourseTaken = hci};

            Student jordan = new Student{
                Name = "Jordan Owen",
                CourseTaken = modr};

            Student denny = new Student{
                Name = "Denny Edwards",
                CourseTaken = hci};

            Student hayden = new Student{
                Name = "Hayden Winters",
                CourseTaken = iis};

            List<Course> courses = new List<Course>{
                hci, iis, modr, micd};

            List<Student> students = new List<Student>{
                carol, river, raylee, jordan, denny, hayden};

            var query = courses.GroupJoin(
                students,
                course => course,
                student => student.CourseTaken,
                (course, studentCollection) =>
                    new{
                        CourseTaken = course.Title,
                        Students = 
                            studentCollection
                                .Select(
                                    student => 
                                        student.Name)
                    });

            //var query =
            //    from c in courses
            //    join s in students on c.Title equals s.CourseTaken.Title
            //    select new
            //    {
            //        StudentName = s.Name,
            //        CourseTaken = c.Title
            //    };

            foreach (var item in query)
            {
                Console.WriteLine("{0}:", item.CourseTaken);
                foreach (string stdnt in item.Students)
                {
                    Console.WriteLine("  {0}", stdnt);
                }
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public Course CourseTaken { get; set; }
    }

    public class Course
    {
        public string Title { get; set; }
        public int CreditHours { get; set; }
    }
}
