using System;
using System.Collections.Generic;

namespace ExtendingCollection
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var sources = new IDataSource[]
            //{
            //    new ClubMember1(),
            //    new ClubMember2()
            //};

            //var items = sources.GetAllItemsByGender_IEnum("Female");
            //Console.WriteLine("Invoking GetAllItemsByGender_IEnum()");
            //foreach (var item in items)
            //{
            //    Console.WriteLine(
            //        "Name: {0}\tGender: {1}",
            //        item.Name,
            //        item.Gender);
            //}

            var sources = new List<IDataSource>
            {
                new ClubMember1(),
                new ClubMember2()
            };

            var items =
                sources.GetAllItemsByGender_IEnumTemplate(
                "Female");
            Console.WriteLine(
                "Invoking GetAllItemsByGender_IEnumTemplate()");
            foreach (var item in items)
            {
                Console.WriteLine(
                    "Name: {0}\tGender: {1}",
                    item.Name,
                    item.Gender);
            }
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
