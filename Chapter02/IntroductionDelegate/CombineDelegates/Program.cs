using System;

namespace CombineDelegates
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            CombineDelegate();
            //RemoveDelegate();
            //DuplicateEntries();
        }
    }

    public partial class Program
    {
        private delegate void CalculatorDelegate(int a, int b);
    }

    public partial class Program
    {
        private static void Add(int x, int y)
        {
            Console.WriteLine(
                "{0} + {1} = {2}",
                x,
                y,
                x + y);
        }

        private static void Subtract(int x, int y)
        {
            Console.WriteLine(
                "{0} - {1} = {2}",
                x,
                y,
                x - y);
        }

        private static void Multiply(int x, int y)
        {
            Console.WriteLine(
                "{0} * {1} = {2}",
                x,
                y,
                x * y);
        }

        private static void Division(int x, int y)
        {
            Console.WriteLine(
                "{0} / {1} = {2}",
                x,
                y,
                x / y);
        }
    }

    public partial class Program
    {
        private static void CombineDelegate()
        {
            CalculatorDelegate calcMultiples =
                (CalculatorDelegate)Delegate.Combine(
                    new CalculatorDelegate[] {
                        Add,
                        Subtract,
                        Multiply,
                        Division });

            Delegate[] calcList = calcMultiples.GetInvocationList();
            Console.WriteLine(
                "Total delegates in calcMultiples: {0}", 
                calcList.Length);
            calcMultiples(6, 3);
        }
    }

    public partial class Program
    {
        private static void RemoveDelegate()
        {
            CalculatorDelegate addDel = Add;
            CalculatorDelegate subDel = Subtract;
            CalculatorDelegate mulDel = Multiply;
            CalculatorDelegate divDel = Division;

            CalculatorDelegate calcDelegates1 =
                (CalculatorDelegate)Delegate.Combine(
                    addDel,
                    subDel);
            CalculatorDelegate calcDelegates2 =
                (CalculatorDelegate)Delegate.Combine(
                    calcDelegates1,
                    mulDel);
            CalculatorDelegate calcDelegates3 =
                (CalculatorDelegate)Delegate.Combine(
                    calcDelegates2,
                    divDel);
            Console.WriteLine(
                "Total delegates in calcDelegates3: {0}",
                calcDelegates3.GetInvocationList().Length);
            calcDelegates3(6, 3);

            CalculatorDelegate calcDelegates4 =
                (CalculatorDelegate)Delegate.Remove(
                    calcDelegates3, 
                    mulDel);
            Console.WriteLine(
                "Total delegates in calcDelegates4: {0}",
                calcDelegates4.GetInvocationList().Length);
            calcDelegates4(6, 3);
        }
    }

    public partial class Program
    {
        private static void DuplicateEntries()
        {
            CalculatorDelegate addDel = Add;
            CalculatorDelegate subDel = Subtract;
            CalculatorDelegate mulDel = Multiply;

            CalculatorDelegate duplicateDelegates1 =
                (CalculatorDelegate)Delegate.Combine(
                    addDel,
                    subDel);
            CalculatorDelegate duplicateDelegates2 =
                (CalculatorDelegate)Delegate.Combine(
                    duplicateDelegates1,
                    mulDel);
            CalculatorDelegate duplicateDelegates3 =
                (CalculatorDelegate)Delegate.Combine(
                    duplicateDelegates2,
                    subDel);
            CalculatorDelegate duplicateDelegates4 =
                (CalculatorDelegate)Delegate.Combine(
                    duplicateDelegates3,
                    addDel);
            Console.WriteLine(
                "Total delegates in duplicateDelegates4: {0}",
                duplicateDelegates4.GetInvocationList().Length);
            duplicateDelegates4(6, 3);
        }
    }
}
