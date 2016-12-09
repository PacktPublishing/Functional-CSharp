<<<<<<< HEAD
﻿using System;

namespace SimpleAnonymousMethods
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                displayMessageDelegate(
                    "A simple anonymous method sample."));
        }
    }

    public partial class Program
    {
        static Func<string, string> displayMessageDelegate = 
            delegate (string str)
            {
                return String.Format("Message: {0}", str);
            };
    }
}
=======
﻿using System;

namespace SimpleAnonymousMethods
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                displayMessageDelegate(
                    "A simple anonymous method sample."));
        }
    }

    public partial class Program
    {
        static Func<string, string> displayMessageDelegate = 
            delegate (string str)
            {
                return String.Format("Message: {0}", str);
            };
    }
}
>>>>>>> origin/master
