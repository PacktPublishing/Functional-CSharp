﻿using System;
using System.Text;

namespace NestedMethodCalls
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                Encoding.UTF8.GetString(
                    new byte[] { 0x70, 0x69, 0x70, 0x65, 0x6C,
                        0x69, 0x6E, 0x69, 0x6E, 0x67 }
                )
            );
        }
    }
}
