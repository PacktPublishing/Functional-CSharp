using System;

namespace ImperativeApproach
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //ConsumeTuple();
            ReturnTuple();
        }
    }

    public partial class Program
    {
        private static Tuple<string, int, int> geometry1 =
            new Tuple<string, int, int>(
                "Rectangle",
                2,
                3);

        private static Tuple<string, int, int> geometry2 =
            Tuple.Create(
                "Square",
                2,
                2);
    }

    public partial class Program
    {
        private static void ConsumeTuple()
        {
            Console.WriteLine(
                "{0} has size {1} x {2}",
                geometry1.Item1,
                geometry1.Item2,
                geometry1.Item3);

            Console.WriteLine(
                "{0} has size {1} x {2}",
                geometry2.Item1,
                geometry2.Item2,
                geometry2.Item3);
        }
    }

    public partial class Program
    {
        private static void ConsumeTupleByItemName()
        {
            var rect = GetSizeNamedItem("Rectangle");
            Console.WriteLine(
                "Rectangle has size {0} x {1}",
                rect.x,
                rect.y);

            var square = GetSizeNamedItem("Square");
            Console.WriteLine(
                "Square has size {0} x {1}",
                square.x,
                square.y);
        }
    }

    public partial class Program
    {
        private static Tuple<int, int> GetSize(
            string shape)
        {
            if (shape == "Rectangle")
            {
                return Tuple.Create(2, 3);
            }
            else if (shape == "Square")
            {
                return Tuple.Create(2, 2);
            }
            else
            {
                return Tuple.Create(0, 0);
            }
        }
    }

    public partial class Program
    {
        (int, int) GetSizeInCS7(
            string shape)
        {
            if (shape == "Rectangle")
            {
                return (2, 3);
            }
            else if (shape == "Square")
            {
                return (2, 2);
            }
            else
            {
                return (0, 0);
            }
        }
    }

    public partial class Program
    {
        private static (int x, int y) GetSizeNamedItem(
            string shape)
        {
            if (shape == "Rectangle")
            {
                return (2, 3);
            }
            else if (shape == "Square")
            {
                return (2, 2);
            }
            else
            {
                return (0, 0);
            }
        }
    }

    public partial class Program
    {
        private static void ReturnTuple()
        {
            var rect = GetSize("Rectangle");
            Console.WriteLine(
                "Rectangle has size {0} x {1}",
                rect.Item1,
                rect.Item2);

            var square = GetSize("Square");
            Console.WriteLine(
                "Square has size {0} x {1}",
                square.Item1,
                square.Item2);
        }
    }
}