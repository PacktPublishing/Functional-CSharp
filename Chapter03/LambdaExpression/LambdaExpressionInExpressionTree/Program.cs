using System;
using System.Linq.Expressions;

namespace LambdaExpressionInExpressionTree
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int, int>> expression =
             (a, b) => a * b;

            //exploreParam(expression);
            //exploreBody(expression);
            compilingExpr(expression);
        }
    }

    public partial class Program
    {
        private static void exploreParam(
            Expression<Func<int, int, int>> expr)
        {
            Console.WriteLine(
                "Param 1: {0}, Param 2: {1}",
                expr.Parameters[0],
                expr.Parameters[1]);
        }
    }

    public partial class Program
    {
        private static void exploreBody(
            Expression<Func<int, int, int>> expr)
        {
            BinaryExpression body = 
                (BinaryExpression)expr.Body;
            ParameterExpression left = 
                (ParameterExpression)body.Left;
            ParameterExpression right = 
                (ParameterExpression)body.Right;

            Console.WriteLine(expr.Body);
            Console.WriteLine(
                "\tThe left part of the expression: {0}\n" +
                "\tThe NodeType: {1}\n" +
                "\tThe right part: {2}\n" +
                "\tThe Type: {3}\n",
                left.Name,
                body.NodeType,
                right.Name,
                body.Type);
        }
    }

    public partial class Program
    {
        private static void compilingExpr(
            Expression<Func<int, int, int>> expr)
        {
            int a = 2;
            int b = 3;
            int compResult = expr.Compile()(a, b);
            Console.WriteLine(
                "The result of expression {0}"+
                " with a = {1} and b = {2} is {3}",
                expr.Body,
                a,
                b,
                compResult);
        }
    }
}
