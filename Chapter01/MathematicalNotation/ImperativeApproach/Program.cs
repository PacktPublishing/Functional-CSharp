using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperativeApproach
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            increment();
            Console.WriteLine("First increment(), i = {0}", i);

            set(6);
            increment();
            Console.WriteLine("Second increment(), i = {0}", i);

            set(2);
            increment();
            Console.WriteLine("Last increment(), i = {0}", i);

            return;
        }
    }

    public partial class Program
    {
        static int i = 0;

        static void increment()
        {
            i++;
        }

        static void set(int inpSet)
        {
            i = inpSet;
        }
    }
}
