<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictAnonymousMethod
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Conflict();
        }
    }

    public partial class Program
    {
        static List<int> numbers = new List<int>()
        {
            54, 24, 91, 70, 72, 44, 61, 93,
            73, 3, 56, 5, 38, 60, 29, 32,
            86, 44, 34, 25, 22, 44, 66, 7,
            9, 59, 70, 47, 55, 95, 6, 42
        };
    }

    public partial class Program
    {
        private static void Conflict()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Action<int> actDelegate = delegate(int i)
                {
                    Console.WriteLine("{0}", i);
                };

                actDelegate(i);
            }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConflictAnonymousMethod
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Conflict();
        }
    }

    public partial class Program
    {
        static List<int> numbers = new List<int>()
        {
            54, 24, 91, 70, 72, 44, 61, 93,
            73, 3, 56, 5, 38, 60, 29, 32,
            86, 44, 34, 25, 22, 44, 66, 7,
            9, 59, 70, 47, 55, 95, 6, 42
        };
    }

    public partial class Program
    {
        private static void Conflict()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Action<int> actDelegate = delegate(int i)
                {
                    Console.WriteLine("{0}", i);
                };

                actDelegate(i);
            }
        }
    }
}
>>>>>>> origin/master
