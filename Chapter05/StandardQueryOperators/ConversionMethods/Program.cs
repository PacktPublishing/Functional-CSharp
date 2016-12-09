<<<<<<< HEAD
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConversionMethods
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            OfTypeCastSimple();
            //OfTypeCastComplex();
        }
    }

    public partial class Program
    {
        public static void OfTypeCastSimple()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.AddRange(
                new int[] {
                    1, 2, 3, 4, 5 });

            IEnumerable<int> sequenceOfType = 
                arrayList.OfType<int>();
            IEnumerable<int> sequenceCast = 
                arrayList.Cast<int>();

            Console.WriteLine(
                "OfType of arrayList");
            foreach (int i in sequenceOfType)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(
                "Cast of arrayList");
            foreach (int i in sequenceCast)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public partial class Program
    {
        public static void OfTypeCastComplex()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.AddRange(
                new int[] {
                    1, 2, 3, 4, 5
                });

            arrayList.AddRange(
                new string[] {
                    "Cooper", "Shawna", "Max"
            });

            IEnumerable<int> sequenceOfType =
                arrayList.OfType<int>();
            IEnumerable<int> sequenceCast =
                arrayList.Cast<int>();

            Console.WriteLine(
                "OfType of arrayList");
            foreach (int i in sequenceOfType)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(
                "Cast of arrayList");
            foreach (int i in sequenceCast)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
=======
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConversionMethods
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            OfTypeCastSimple();
            //OfTypeCastComplex();
        }
    }

    public partial class Program
    {
        public static void OfTypeCastSimple()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.AddRange(
                new int[] {
                    1, 2, 3, 4, 5 });

            IEnumerable<int> sequenceOfType = 
                arrayList.OfType<int>();
            IEnumerable<int> sequenceCast = 
                arrayList.Cast<int>();

            Console.WriteLine(
                "OfType of arrayList");
            foreach (int i in sequenceOfType)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(
                "Cast of arrayList");
            foreach (int i in sequenceCast)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public partial class Program
    {
        public static void OfTypeCastComplex()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.AddRange(
                new int[] {
                    1, 2, 3, 4, 5
                });

            arrayList.AddRange(
                new string[] {
                    "Cooper", "Shawna", "Max"
            });

            IEnumerable<int> sequenceOfType =
                arrayList.OfType<int>();
            IEnumerable<int> sequenceCast =
                arrayList.Cast<int>();

            Console.WriteLine(
                "OfType of arrayList");
            foreach (int i in sequenceOfType)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(
                "Cast of arrayList");
            foreach (int i in sequenceCast)
            {
                Console.Write(".." + i);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
>>>>>>> origin/master
