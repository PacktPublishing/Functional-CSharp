using System;

namespace HonestSignature
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public partial class Program
    {
        public static int SumUp(
            int a, int b)
        {
            return a + b;
        }
    }

    public partial class Program
    {
        public static void RunGenerateRandom()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(
                    String.Format(
                        "Number {0} = {1}",
                        i,
                        GenerateRandom(100)));
            }
        }
    }

    public partial class Program
    {
        public static int GenerateRandom(
            int max)
        {
            Random rnd = new Random(
                Guid.NewGuid()
                    .GetHashCode());
            return rnd.Next(max);
        }
    }

    //public partial class Program
    //{
    //    public static int Divide(
    //        int a, int b)
    //    {
    //        return a / b;
    //    }
    //}

    public partial class Program
    {
        public static int? Divide(
            int a, int b)
        {
            if (b == 0)
                return null;


            return a / b;
        }
    }
}
