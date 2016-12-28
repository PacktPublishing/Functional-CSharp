using System;

namespace SimpleLambdaExpression
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(
            //    displayMessageDelegate(
            //        "A simple lambda expression sample."));

            //firstClassConcept();
            firstClassConcept2(
                displayMessageDelegate,
                "Pass lambda expression to argument");
        }
    }

    public partial class Program
    {
        static Func<string, string> displayMessageDelegate =
            str => String.Format("Message: {0}", str);
    }

    public partial class Program
    {
        static private void firstClassConcept()
        {
            string str = displayMessageDelegate(
                "Assign displayMessageDelegate() to variable");
            Console.WriteLine(str);
        }
    }

    public partial class Program
    {
        static private void firstClassConcept2(
            Func<string, string> funct,
            string message)
        {
            Console.WriteLine(funct(message));
        }
    }
}
