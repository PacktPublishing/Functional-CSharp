namespace FuncAssignToMethod
{
    class Program
    {
        delegate int DoubleAction(
            int inp);

        static void Main(string[] args)
        {
            DoubleAction da = Double;
            int doubledValue = da(2);
        }

        static int Double(
            int input)
        {
            return input * 2;
        }
    }
}
