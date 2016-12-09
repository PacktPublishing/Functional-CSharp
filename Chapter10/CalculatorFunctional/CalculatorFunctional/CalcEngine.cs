using System;

namespace CalculatorFunctional
{
    public class Calc
    {
        public string m_input { get; set; }
        public string m_sign { get; set; }
        public string m_operator { get; set; }
        public string m_lastNum { get; set; }
        public string m_lastInput { get; set; }
        public bool m_wait { get; set; }
        public bool m_decimal { get; set; }
        public bool m_lastHitEquals { get; set; }

        public bool m_solve { get; set; }
        public string m_answer { get; set; }
        public bool m_funcSuccess { get; set; }
    }

    public static class CalcMethodsExtension
    {
        public static Calc Clear(
            this Calc calc)
        {
            return calc
                .ModifyCalcSign("+")
                .ModifyCalcInput(".")
                .ModifyCalcDecimal(false);
        }

        public static Calc ClearAll(
            this Calc calc)
        {
            return calc
                .Clear()
                .ModifyCalcLastNum(null)
                .ModifyCalcLastInput(null)
                .ModifyCalcOperator(null)
                .ModifyCalcWait(false)
                .ModifyCalcLastHitEquals(false);
        }

        public static Calc DoFuncWhen(
            this Calc calc,
            Func<bool> predicate,
            Func<Calc> func)
        {
            return predicate() ?
                func() :
                calc;
        }

        public static String FormatInput(
            this Calc calc, 
            String n)
        {
            return n
                .ModifyStringWhen(
                    () => n.IndexOf(".") == 0,
                    () => n = "0" + n)
                .ModifyStringWhen(
                    () => n.IndexOf(".") == n.Length - 1,
                    () => n = n + "0")
                .ModifyStringWhen(
                    () => calc.m_sign.Equals("-") &&
                        n != "0.0" &&
                        n.IndexOf("-") == -1,
                    () => n = "-" + n);
        }

        public static Calc Solve(
            this Calc calc)
        {
            return calc.CleanUp()
                 .Answer()
                 .UpdateAnswerToCalc();
        }

        public static Calc PrepareOperation(
            this Calc calc,
            string strOperator)
        {
            return PatternMatch.Match()
                .With(
                    () => strOperator == "add",
                    () => calc.PrepareOperationAdd())
                .With(
                    () => strOperator == "subtract",
                    () => calc.PrepareOperationSubtract())
                .With(
                    () => strOperator == "multiply",
                    () => calc.PrepareOperationMultiply())
                .With(
                    () => strOperator == "divide",
                    () => calc.PrepareOperationDivide())
                .Do();
        }

        public static Calc PrepareOperationAdd(
            this Calc calc)
        {
            return PatternMatch.Match()
                .With(
                    () => calc.m_lastNum == null ||
                        calc.m_wait,
                    () => calc.PrepareOperationAddLastNumNull())
                .Else(
                    () => calc.PrepareOperationAddLastNumNonNull())
                .Do()
                .ModifyCalcLastHitEquals(false);
        }

        public static Calc 
            PrepareOperationAddLastNumNull(
                this Calc calc)
        {
            return calc
                .DoFuncWhen(
                    () =>
                        calc.m_lastNum != null &&
                            !calc.m_operator.Equals("+") &&
                            !calc.m_lastHitEquals &&
                            !calc.m_wait,
                    () => calc.Solve())
                .ModifyCalcOperator("+")
                .ModifyCalcLastNum(
                    "" + calc.FormatInput(
                        calc.m_input))
                .ModifyCalcSign("+")
                .ModifyCalcDecimal(false)
                .ModifyCalcWait(true);
        }

        public static Calc 
            PrepareOperationAddLastNumNonNull(
                this Calc calc)
        {
            return calc
                .DoFuncWhen(
                    () => !calc.m_wait,
                    () => calc.Solve())
                .ModifyCalcOperator("+")
                .ModifyCalcSign("+")
                .ModifyCalcWait(true);
        }

        public static Calc PrepareOperationSubtract(
            this Calc calc)
        {
            return PatternMatch.Match()
                .With(
                    () => calc.m_lastNum == null ||
                        calc.m_wait,
                    () => calc.PrepareOperationSubtractLastNumNull())
                .Else(
                    () => calc.PrepareOperationSubtractLastNumNonNull())
                .Do()
                .ModifyCalcLastHitEquals(false);
        }

        public static Calc
           PrepareOperationSubtractLastNumNull(
               this Calc calc)
        {
            return calc
                .DoFuncWhen(
                    () =>
                        calc.m_lastNum != null &&
                            !calc.m_operator.Equals("-") &&
                            !calc.m_lastHitEquals &&
                            !calc.m_wait,
                    () => calc.Solve())
                .ModifyCalcOperator("-")
                .ModifyCalcLastNum(
                    "" + calc.FormatInput(
                        calc.m_input))
                .ModifyCalcSign("+")
                .ModifyCalcDecimal(false)
                .ModifyCalcWait(true);
        }

        public static Calc
            PrepareOperationSubtractLastNumNonNull(
                this Calc calc)
        {
            return calc
                .DoFuncWhen(
                    () => !calc.m_wait,
                    () => calc.Solve())
                .ModifyCalcOperator("-")
                .ModifyCalcSign("+")
                .ModifyCalcWait(true);
        }

        public static Calc PrepareOperationMultiply(
            this Calc calc)
        {
            return PatternMatch.Match()
                .With(
                    () => calc.m_lastNum == null ||
                        calc.m_wait,
                    () => calc.PrepareOperationMultiplyLastNumNull())
                .Else(
                    () => calc.PrepareOperationMultiplyLastNumNonNull())
                .Do()
                .ModifyCalcLastHitEquals(false);
        }

        public static Calc
           PrepareOperationMultiplyLastNumNull(
               this Calc calc)
        {
            return calc
                .DoFuncWhen(
                    () =>
                        calc.m_lastNum != null &&
                            !calc.m_operator.Equals("*") &&
                            !calc.m_lastHitEquals &&
                            !calc.m_wait,
                    () => calc.Solve())
                .ModifyCalcOperator("*")
                .ModifyCalcLastNum(
                    "" + calc.FormatInput(
                        calc.m_input))
                .ModifyCalcSign("+")
                .ModifyCalcDecimal(false)
                .ModifyCalcWait(true);
        }

        public static Calc
            PrepareOperationMultiplyLastNumNonNull(
                this Calc calc)
        {
            return calc
                .DoFuncWhen(
                    () => !calc.m_wait,
                    () => calc.Solve())
                .ModifyCalcOperator("*")
                .ModifyCalcSign("+")
                .ModifyCalcWait(true);
        }

        public static Calc PrepareOperationDivide(
            this Calc calc)
        {
            return PatternMatch.Match()
                .With(
                    () => calc.m_lastNum == null ||
                        calc.m_wait,
                    () => calc.PrepareOperationDivideLastNumNull())
                .Else(
                    () => calc.PrepareOperationDivideLastNumNonNull())
                .Do()
                .ModifyCalcLastHitEquals(false);
        }

        public static Calc
           PrepareOperationDivideLastNumNull(
               this Calc calc)
        {
            return calc
                .DoFuncWhen(
                    () =>
                        calc.m_lastNum != null &&
                            !calc.m_operator.Equals("/") &&
                            !calc.m_lastHitEquals,
                    () => calc.Solve())
                .ModifyCalcOperator("/")
                .ModifyCalcLastNum(
                    "" + calc.FormatInput(
                        calc.m_input))
                .ModifyCalcSign("+")
                .ModifyCalcDecimal(false)
                .ModifyCalcWait(true);
        }

        public static Calc
            PrepareOperationDivideLastNumNonNull(
                this Calc calc)
        {
            return calc
                .DoFuncWhen(
                    () => !calc.m_wait,
                    () => calc.Solve())
                .ModifyCalcOperator("/")
                .ModifyCalcSign("+")
                .ModifyCalcWait(true);
        }

        public static Calc FunctionButton(
            this Calc calc,
            string str)
        {
            return PatternMatch.Match()
                .With(() => str == "sqrt",
                    () => calc.FunctionButtonSqrt())
                .With(() => str == "percent",
                    () => calc.FunctionButtonPercent())
                .With(() => str == "inverse",
                    () => calc.FunctionButtonInverse())
                .With(() => str == "delete",
                    () => calc.FunctionButtonDelete())
                .With(() => str == "switchSign",
                    () => calc.FunctionButtonSwitchSign())
                .With(() => str == "decimal",
                    () => calc.FunctionButtonDecimal())
                .Do();
        }

        public static Calc FunctionButtonSqrt(
            this Calc calc)
        {
            //return calc.DoFuncWhen(
            //    () => !calc.m_sign.Equals("-"),
            //    () => calc.Sqrt(
            //        calc.m_input));
            return calc
                .ModifyCalcInputWhen(
                    () => !calc.m_sign.Equals("-"),
                    Sqrt(calc.m_input))
                .ModifyCalcFuncSuccessBasedOn(
                    () => !calc.m_sign.Equals("-"));
        }

        public static string Sqrt(
            string str)
        {
            return Convert.ToString(
                Math.Sqrt(
                    Convert.ToDouble(
                        str)));
        }

        public static Calc FunctionButtonPercent(
            this Calc calc)
        {
            return calc
                .ModifyCalcInputWhen(
                    () => calc.m_lastNum != null,
                    Percent(calc.m_lastNum,
                        calc.m_input))
                .ModifyCalcFuncSuccessBasedOn(
                    () => calc.m_lastNum != null);
        }

        public static string Percent(
            string strLast,
            string str)
        {
            return Convert.ToString(
                Convert.ToDouble(strLast) *
                (Convert.ToDouble(str) /
                100));
        }

        public static Calc FunctionButtonInverse(
            this Calc calc)
        {
            return calc
                .ModifyCalcInputWhen(
                    () => Convert.ToDouble(
                        calc.m_input) != 0,
                    Inverse1(calc.m_input))
                .DoFuncWhen(
                    () => Convert.ToDouble(
                        calc.m_input) != 0,
                    () => calc.Inverse2(
                        calc.m_input))
                .ModifyCalcFuncSuccessBasedOn(
                    () => Convert.ToDouble(
                        calc.m_input) != 0);
        }

        public static string Inverse1(
            string str)
        {
            return Convert.ToString(
                1 / Convert.ToDouble(
                    str));
        }

        public static Calc Inverse2(
            this Calc calc,
            string str)
        {
            calc.m_input = Convert.ToString(
                Math.Round(
                    Convert.ToDouble(
                        str)));
            return calc;
        }

        public static Calc FunctionButtonDelete(
            this Calc calc)
        {
            //return PatternMatch.Match()
            //    .With(() => calc.m_decimal == true,
            //        () => calc.DeleteWithDecimal())
            //    .Else(() => calc.DeleteWithoutDecimal())
            //    .Do()
            //    .ModifyCalcInputWhen(
            //        () => calc.m_input.Equals(".") ||
            //            calc.m_input.Equals("-."),
            //        ".")
            //    .ModifyCalcSignWhen(
            //        () => calc.m_input.Equals(".") ||
            //            calc.m_input.Equals("-."),
            //        "+");

            return calc.DoFuncWhen(
                () => !calc.m_input.Equals(".") &&
                    !calc.m_wait,
                () => DoDeleteIfValid(calc));
        }

        public static Calc DoDeleteIfValid(
            this Calc calc)
        {
            return PatternMatch.Match()
                .With(() => calc.m_decimal == true,
                    () => calc.DeleteWithDecimal())
                .Else(() => calc.DeleteWithoutDecimal())
                .Do()
                .ModifyCalcInputWhen(
                    () => calc.m_input.Equals(".") ||
                        calc.m_input.Equals("-."),
                    ".")
                .ModifyCalcSignWhen(
                    () => calc.m_input.Equals(".") ||
                        calc.m_input.Equals("-."),
                    "+");
        }

        public static Calc DeleteWithDecimal(
            this Calc calc)
        {
            return calc
                .ModifyCalcInput(
                    RemoveLastDigit(
                        calc.m_input))
                .ModifyCalcInputWhen(
                    () => calc.m_input.IndexOf(".") < 0,
                    calc.m_input + ".")
                .ModifyCalcDecimalWhen(
                    () => calc.m_input.IndexOf(".") < 0,
                    false)
                ;
        }

        public static string RemoveLastDigit(
            string str)
        {
            return str.Remove(
                str.Length - 1);
        }

        public static Calc DeleteWithoutDecimal(
            this Calc calc)
        {
            return calc
                .ModifyCalcInput(
                    RemoveDot(
                        calc.m_input));
        }

        public static string RemoveDot(
            string str)
        {
            return str.Remove(
                str.IndexOf(".") - 1,
                1);
        }

        public static Calc FunctionButtonSwitchSign(
            this Calc calc)
        {
            return calc
                .DoFuncWhen(
                    () => !calc.m_wait &&
                        !calc.m_input.Equals("."),
                    () => calc.SwitchSignWhenNotWait())
                .ModifyCalcFuncSuccessBasedOn(
                    () => !calc.m_wait &&
                        !calc.m_input.Equals("."));
        }

        public static Calc SwitchSignWhenNotWait(
            this Calc calc)
        {
            return PatternMatch.Match()
                .With(() => calc.m_sign.Equals("+") &&
                        !calc.m_input.Equals(""),
                    () => calc.SwitchSignWhenPositive())
                .Else(() => calc.SwitchSignWhenNegative())
                .Do();
        }

        public static Calc SwitchSignWhenPositive(
            this Calc calc)
        {
            return calc
                .ModifyCalcSign("-")
                .ModifyCalcInput("-" + calc.m_input);
        }

        public static Calc SwitchSignWhenNegative(
            this Calc calc)
        {
            return calc
                .ModifyCalcInputWhen(
                    () => calc.m_sign.Equals("-"),
                    RemoveFirstDigit(calc.m_input))
                .ModifyCalcSign("+");
        }

        public static string RemoveFirstDigit(
            string str)
        {
            return str.Remove(0, 1);
        }

        public static Calc FunctionButtonDecimal(
            this Calc calc)
        {
            return calc
                .ModifyCalcDecimalBasedOn(
                    () => !calc.m_decimal == true)
                .ModifyCalcFuncSuccessBasedOn(
                    () => !calc.m_decimal == true);
        }

        public static string Decimal(
            string str)
        {
            return Convert.ToString(
                Math.Sqrt(
                    Convert.ToDouble(
                        str)));
        }

        public static Calc AppendNum(
            this Calc calc,
            double numValue)
        {
            return PatternMatch.Match()
                .With(
                    () => numValue == Math.Round(numValue) &&
                        numValue >= 0,
                    () => calc.AppendNumWhenRound(numValue))
                .Else(
                    () => calc.AppendNumWhenNotRound(numValue))
                .Do();
        }

        public static Calc AppendNumWhenRound(
            this Calc calc,
            double numValue)
        {
            return PatternMatch.Match()
                .With(
                    () => calc.m_input.Equals(".") || 
                        calc.m_wait == true,
                    () => calc.AppendNumWhenRoundAndEmpty(
                        numValue))
                .Else(
                    () => calc.AppendNumWhenRoundAndNotEmpty(
                        numValue))
                .Do()
                .ModifyCalcInputWhen(
                    () => calc.m_input.IndexOf("0", 0, 1) == 0 && 
                        calc.m_input.IndexOf(".") > 1,
                    calc.m_input.Remove(0, 1));
        }

        public static Calc 
            AppendNumWhenRoundAndEmpty(
                this Calc calc,
                double numValue)
        {
            return calc
                .DoFuncWhen(
                    () => calc.m_lastHitEquals == true,
                    () => calc.ClearAll())
                .ModifyCalcLastHitEqualsNegation()
                .ModifyCalcInputWhen(
                    () => calc.m_decimal == true,
                    "." + numValue)
                .ModifyCalcInputWhen(
                    () => calc.m_decimal == false,
                    numValue + ".")
                .ModifyCalcWait(false);
        }

        public static Calc 
            AppendNumWhenRoundAndNotEmpty(
                this Calc calc,
                double numValue)
        {
            return calc
                .ModifyCalcInputWhen(
                    () => calc.m_decimal == true,
                    calc.m_input + "" + numValue)
                .ModifyCalcInputWhen(
                    () => calc.m_decimal == false,
                    calc.m_input.Insert(
                        calc.m_input.IndexOf(
                            "."), 
                        "" + numValue));
        }

        public static Calc AppendNumWhenNotRound(
            this Calc calc,
            double numValue)
        {
            return calc
                .DoFuncWhen(
                    () => calc.m_lastHitEquals == true,
                    () => calc.ClearAll())
                .ModifyCalcLastHitEqualsNegation()
                .ModifyCalcInput("" + numValue)
                .ModifyCalcInput(
                    calc.FormatInput(
                        calc.m_input))
                .ModifyCalcInputWhen(
                    () => !calc.m_input.Contains("."),
                    calc.m_input + ".")
                .ModifyCalcDecimalWhen(
                    () => calc.m_input.Contains(".") &&
                        !(calc.m_input.EndsWith("0") &&
                            calc.m_input.IndexOf(".") == 
                            calc.m_input.Length - 2),
                    true)
                .ModifyCalcSignWhen(
                    () => calc.m_input.Contains("-"),
                    "-")
                .ModifyCalcSignWhen(
                    () => !calc.m_input.Contains("-"),
                    "+")
                .ModifyCalcInputWhen(
                    () => calc.m_input.IndexOf(
                            "0", 0, 1) == 0 &&
                        calc.m_input.IndexOf(".") > 1,
                    RemoveFirstDigit(calc.m_input))
                .ModifyCalcInputWhen(
                    () => calc.m_input.EndsWith("0") &&
                        calc.m_input.IndexOf(".") == 
                            calc.m_input.Length - 2,
                    RemoveLastDigit(calc.m_input))
                .ModifyCalcWait(false);
        }

        public static double GetDisplay(
            this Calc calc)
        {
            return Convert.ToDouble(
                calc.FormatInput(
                    calc.m_input));
        }
    }

    public static class CalcPropertiesExtension
    {
        public static Calc Input(
            this Calc calc,
            string input)
        {
            calc.m_input =
                input;
            return calc;
        }

        public static Calc LastNum(
            this Calc calc,
            string lastNum)
        {
            calc.m_lastNum =
                lastNum;
            return calc;
        }

        public static Calc LastInput(
            this Calc calc,
            string lastInput)
        {
            calc.m_lastInput =
                lastInput;
            return calc;
        }

        public static Calc Sign(
            this Calc calc,
            string sign)
        {
            calc.m_sign =
                sign;
            return calc;
        }

        public static Calc Wait(
            this Calc calc,
            bool wait)
        {
            calc.m_wait =
                wait;
            return calc;
        }

        public static Calc Decimal(
            this Calc calc,
            bool dec)
        {
            calc.m_decimal =
                dec;
            return calc;
        }

        public static Calc LastHitEquals(
            this Calc calc,
            bool lastHitEquals)
        {
            calc.m_lastHitEquals =
                lastHitEquals;
            return calc;
        }

        public static Calc ModifyCalcInput(
            this Calc calc,
            string str)
        {
            calc.m_input = str;
            return calc;
        }

        public static Calc ModifyCalcInputWhen(
            this Calc calc,
            Func<bool> predicate,
            string str)
        {
            return predicate()
                ? calc.ModifyCalcInput(
                    str)
                : calc;
        }

        public static Calc ModifyCalcLastNum(
            this Calc calc,
            string str)
        {
            calc.m_lastNum = str;
            return calc;
        }

        public static Calc ModifyCalcLastNumWhen(
            this Calc calc,
            Func<bool> predicate,
            string str)
        {
            return predicate()
                ? calc.ModifyCalcLastNum(
                    str)
                : calc;
        }

        public static Calc ModifyCalcLastInput(
            this Calc calc,
            string str)
        {
            calc.m_lastInput = str;
            return calc;
        }

        public static Calc ModifyCalcLastInputWhen(
            this Calc calc,
            Func<bool> predicate,
            string str)
        {
            return predicate()
                ? calc.ModifyCalcLastInput(
                    str)
                : calc;
        }

        public static Calc ModifyCalcSign(
            this Calc calc,
            string str)
        {
            calc.m_sign = str;
            return calc;
        }

        public static Calc ModifyCalcSignWhen(
            this Calc calc,
            Func<bool> predicate,
            string str)
        {
            return predicate()
                ? calc.ModifyCalcSign(
                    str)
                : calc;
        }

        public static Calc ModifyCalcDecimal(
            this Calc calc,
            bool val)
        {
            calc.m_decimal = val;
            return calc;
        }

        public static Calc ModifyCalcDecimalWhen(
            this Calc calc,
            Func<bool> predicate,
            bool val)
        {
            return predicate()
                ? calc.ModifyCalcDecimal(
                    val)
                : calc;
        }

        public static Calc ModifyCalcDecimalBasedOn(
            this Calc calc,
            Func<bool> predicate)
        {
            return predicate() ?
                calc.ModifyCalcDecimal(true) :
                calc.ModifyCalcDecimal(false);
        }





        public static Calc ModifyCalcOperator(
            this Calc calc,
            string str)
        {
            calc.m_operator = str;
            return calc;
        }

        public static Calc ModifyCalcWait(
            this Calc calc,
            bool val)
        {
            calc.m_wait = val;
            return calc;
        }

        public static Calc ModifyCalcLastHitEquals(
            this Calc calc,
            bool val)
        {
            calc.m_lastHitEquals = val;
            return calc;
        }

        public static Calc 
            ModifyCalcLastHitEqualsNegation(
                this Calc calc)
        {
            calc.m_lastHitEquals = 
                !calc.m_lastHitEquals;
            return calc;
        }

        public static Calc ModifyCalcFuncSuccess(
            this Calc calc,
            bool val)
        {
            calc.m_funcSuccess = val;
            return calc;
        }

        public static Calc ModifyCalcFuncSuccessBasedOn(
            this Calc calc,
            Func<bool> predicate)
        {
            return predicate() ?
                calc.ModifyCalcFuncSuccess(true) :
                calc.ModifyCalcFuncSuccess(false);
        }
    }

    public static class StringMethodsExtension
    {
        public static string ModifyStringWhen(
            this string @this,
            Func<bool> predicate,
            Func<string> modifier)
        {
            return predicate()
                ? modifier()
                : @this;
        }

        public static string SolveAdd(
            this string @string, 
            string str)
        {
            return Convert.ToString(
                Convert.ToDouble(@string) +
                Convert.ToDouble(str));
        }

        public static string SolveSubtract(
            this string @string,
            string str)
        {
            return Convert.ToString(
                Convert.ToDouble(@string) -
                Convert.ToDouble(str));
        }

        public static string SolveMultiply(
            this string @string,
            string str)
        {
            return Convert.ToString(
                Convert.ToDouble(@string) *
                Convert.ToDouble(str));
        }

        public static string SolveDivide(
            this string @string,
            string str)
        {
            return Convert.ToString(
                Convert.ToDouble(@string) /
                Convert.ToDouble(str));
        }
    }

    public static class CalcSolveMethodsExtension
    {
        public static Calc Answer(
            this Calc calc)
        {
            calc.m_answer = calc.m_operator.Match()
                .With(o => o == "+", 
                    calc.m_lastNum.SolveAdd(
                        calc.m_lastInput))
                .With(o => o == "-", 
                    calc.m_lastNum.SolveSubtract(
                        calc.m_lastInput))
                .With(o => o == "*", 
                    calc.m_lastNum.SolveMultiply(
                        calc.m_lastInput))
                .With(o => o == "/", 
                    !calc.FormatInput(
                        calc.m_lastInput).Equals(
                            "0.0") ? 
                        calc.m_lastNum.SolveDivide(
                            calc.m_lastInput) : 
                        "")
                .Else("")
                .Do();

            calc.m_solve = calc.m_answer.Match()
                .With(o => o.Equals(""), false)
                .Else(true)
                .Do();

            return calc;
        }

        public static Calc CleanUp(
            this Calc calc)
        {
            return calc
                .ModifyCalcInputWhen(
                    () => calc.m_input.Equals(""),
                    "0")
                .ModifyCalcLastNumWhen(
                    () => calc.m_lastNum == null ||
                        calc.m_lastNum.Equals(""),
                    "0,0")
                .ModifyCalcLastInputWhen(
                    () => !calc.m_wait,
                    "" + calc.FormatInput(
                        calc.m_input));
        }

        public static Calc UpdateAnswerToCalc(
            this Calc calc)
        {
            calc.m_lastNum = calc.m_answer;
            calc.m_input = calc.m_answer;
            calc.m_sign = "+";
            calc.m_decimal = false;
            calc.m_lastHitEquals = true;
            calc.m_wait = true;

            calc.m_solve = true;
            return calc;
        }
    }
}
