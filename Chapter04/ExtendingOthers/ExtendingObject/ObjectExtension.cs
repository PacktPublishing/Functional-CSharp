using System;

namespace ExtendingObject
{
    public static class ObjectExtension
    {
        public static void WriteToConsole(
            this object o,
            string objectName)
        {
            Console.WriteLine(
                String.Format(
                    "{0}: {1}\n",
                    objectName, 
                    o.ToString()));
        }
    }
}
