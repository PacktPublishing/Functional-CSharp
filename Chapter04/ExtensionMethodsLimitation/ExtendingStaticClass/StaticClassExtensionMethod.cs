using System;

namespace ExtendingStaticClass
{
    public static class StaticClassExtensionMethod
    {
        //public static int Square(this Math m, int i)
        //{
        //    return i * i;
        //}

        public static int Square(this int i)
        {
            return i * i;
        }
    }
}
