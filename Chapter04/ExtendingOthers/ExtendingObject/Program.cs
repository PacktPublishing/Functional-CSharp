using System;
using System.Collections.Generic;

namespace ExtendingObject
{
    public class Program
    {
        static void Main(string[] args)
        {
            var obj1 = UInt64.MaxValue;
            obj1.WriteToConsole(nameof(obj1));

            var obj2 = new DateTime(2016, 1, 1);
            obj2.WriteToConsole(nameof(obj2));

            var obj3 = new DataItem
            {
                Name = "Marcos Raymond",
                Gender = "Male"
            };
            obj3.WriteToConsole(nameof(obj3));

            IEnumerable<IDataSource> obj4 =
                new List<IDataSource>
                {
                    new ClubMember1(),
                    new ClubMember2()
                };
            obj4.WriteToConsole(nameof(obj4));
        }
    }

    public class ClubMember1 : IDataSource
    {
        public IEnumerable<DataItem> GetItems()
        {
            return new List<DataItem>
            {
                new DataItem{
                    Name ="Dorian Villarreal",
                    Gender ="Male"},
                new DataItem{
                    Name ="Olivia Bradley",
                    Gender ="Female"},
                new DataItem{
                    Name ="Jocelyn Garrison",
                    Gender ="Female"},
                new DataItem{
                    Name ="Connor Hopkins",
                    Gender ="Male"},
                new DataItem{
                    Name ="Rose Moore",
                    Gender ="Female"}
            };
        }
    }

    public class ClubMember2 : IDataSource
    {
        public IEnumerable<DataItem> GetItems()
        {
            return new List<DataItem>
            {
                new DataItem{
                    Name ="Conner Avery",
                    Gender ="Male"},
                new DataItem{
                    Name ="Lexie Irwin",
                    Gender ="Female"},
                new DataItem{
                    Name ="Bobby Armstrong",
                    Gender ="Male"},
                new DataItem{
                    Name ="Stanley Wilson",
                    Gender ="Male"},
                new DataItem{
                    Name ="Chloe Steele",
                    Gender ="Female"}
            };
        }
    }
}
