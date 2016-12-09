using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelining
{
    class Program
    {
        static void Main(string[] args)
        {
            var bytes = new byte[] {
                0x70, 0x69, 0x70, 0x65, 0x6C,
                0x69, 0x6E, 0x69, 0x6E, 0x67 };
            var stringFromBytes = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(stringFromBytes);
        }
    }
}
