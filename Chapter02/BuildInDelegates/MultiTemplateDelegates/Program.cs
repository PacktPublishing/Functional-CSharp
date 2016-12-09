<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTemplateDelegates
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //VoidDelegateInvoke();
            ReturnValueDelegateInvoke();
        }
    }

    public partial class Program
    {
        private delegate void AdditionDelegate<T1, T2>(
            T1 value1, T2 value2);
    }

    public partial class Program
    {
        private static void AddIntDouble(int x, double y)
        {
            Console.WriteLine(
                "(int) {0} + (double) {1} = {2}",
                x,
                y,
                x + y);
        }

        private static void AddFloatDouble(float x, double y)
        {
            Console.WriteLine(
                "(float) {0} + (double) {1} = {2}",
                x,
                y,
                x + y);
        }
    }

    public partial class Program
    {
        private static void VoidDelegateInvoke()
        {
            AdditionDelegate<int, double> intDoubleAdd = 
                AddIntDouble;
            AdditionDelegate<float, double> floatDoubleAdd = 
                AddFloatDouble;

            Console.WriteLine("Invoking intDoubleAdd delegate");
            intDoubleAdd(1, 2.5);
            Console.WriteLine("Invoking floatDoubleAdd delegate");
            floatDoubleAdd((float)1.2, 4.3);
        }
    }

    public partial class Program
    {
        private delegate TResult AddAndConvert<T1, T2, TResult>(
            T1 digit1, T2 digit2);
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
        private static void ReturnValueDelegateInvoke()
        {
            AddAndConvert<int, double, float> 
                intDoubleAddConvertToFloat =
                    AddIntDoubleConvert;
            AddAndConvert<float, double, int> 
                floatDoubleAddConvertToInt =
                    AddFloatDoubleConvert;

            Console.WriteLine(
                "Invoking intDoubleAddConvertToFloat delegate");
            float f = intDoubleAddConvertToFloat(5, 3.9);
            Console.WriteLine(
                "Invoking floatDoubleAddConvertToInt delegate");
            int i = floatDoubleAddConvertToInt((float)4.3, 2.1);
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTemplateDelegates
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //VoidDelegateInvoke();
            ReturnValueDelegateInvoke();
        }
    }

    public partial class Program
    {
        private delegate void AdditionDelegate<T1, T2>(
            T1 value1, T2 value2);
    }

    public partial class Program
    {
        private static void AddIntDouble(int x, double y)
        {
            Console.WriteLine(
                "(int) {0} + (double) {1} = {2}",
                x,
                y,
                x + y);
        }

        private static void AddFloatDouble(float x, double y)
        {
            Console.WriteLine(
                "(float) {0} + (double) {1} = {2}",
                x,
                y,
                x + y);
        }
    }

    public partial class Program
    {
        private static void VoidDelegateInvoke()
        {
            AdditionDelegate<int, double> intDoubleAdd = 
                AddIntDouble;
            AdditionDelegate<float, double> floatDoubleAdd = 
                AddFloatDouble;

            Console.WriteLine("Invoking intDoubleAdd delegate");
            intDoubleAdd(1, 2.5);
            Console.WriteLine("Invoking floatDoubleAdd delegate");
            floatDoubleAdd((float)1.2, 4.3);
        }
    }

    public partial class Program
    {
        private delegate TResult AddAndConvert<T1, T2, TResult>(
            T1 digit1, T2 digit2);
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
        private static void ReturnValueDelegateInvoke()
        {
            AddAndConvert<int, double, float> 
                intDoubleAddConvertToFloat =
                    AddIntDoubleConvert;
            AddAndConvert<float, double, int> 
                floatDoubleAddConvertToInt =
                    AddFloatDoubleConvert;

            Console.WriteLine(
                "Invoking intDoubleAddConvertToFloat delegate");
            float f = intDoubleAddConvertToFloat(5, 3.9);
            Console.WriteLine(
                "Invoking floatDoubleAddConvertToInt delegate");
            int i = floatDoubleAddConvertToInt((float)4.3, 2.1);
        }
    }
}
>>>>>>> origin/master
