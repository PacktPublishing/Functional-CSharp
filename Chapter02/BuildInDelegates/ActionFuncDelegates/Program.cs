using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //ActionDelegateInvoke();
            FuncDelegateInvoke();
        }
    }

    public partial class Program
    {
        private static void AddIntDouble(int x, double y)
        {
            Console.WriteLine(
                "int {0} + double {1} = {2}",
                x,
                y,
                x + y);
        }

        private static void AddFloatDouble(float x, double y)
        {
            Console.WriteLine(
                "float {0} + double {1} = {2}",
                x,
                y,
                x + y);
        }
    }


    public partial class Program
    {
        private static void ActionDelegateInvoke()
        {
            Action<int, double> intDoubleAddAction =
                AddIntDouble;
            Action<float, double> floatDoubleAddAction =
                AddFloatDouble;

            Console.WriteLine(
                "Invoking intDoubleAddAction delegate");
            intDoubleAddAction(1, 2.5);
            Console.WriteLine(
                "Invoking floatDoubleAddAction delegate");
            floatDoubleAddAction((float)1.2, 4.3);
        }
    }

    public partial class Program
    {
        private static float AddIntDoubleConvert(int x, double y)
        {
            float result = (float)(x + y);
            Console.WriteLine(
                "(int) {0} + (double) {1} = (float) {2}",
                x,
                y,
                result);
            return result;
        }

        private static int AddFloatDoubleConvert(float x, double y)
        {
            int result = (int)(x + y);
            Console.WriteLine(
                "(float) {0} + (double) {1} = (int) {2}",
                x,
                y,
                result);
            return result;
        }
    }

    public partial class Program
    {
        private static void FuncDelegateInvoke()
        {
            Func<int, double, float>
                intDoubleAddConvertToFloatFunc =
                    AddIntDoubleConvert;
            Func<float, double, int>
                floatDoubleAddConvertToIntFunc =
                    AddFloatDoubleConvert;

            Console.WriteLine(
                "Invoking intDoubleAddConvertToFloatFunc delegate");
            float f = intDoubleAddConvertToFloatFunc(5, 3.9);
            Console.WriteLine(
                "Invoking floatDoubleAddConvertToIntFunc delegate");
            int i = floatDoubleAddConvertToIntFunc((float)4.3, 2.1);
        }
    }
}
