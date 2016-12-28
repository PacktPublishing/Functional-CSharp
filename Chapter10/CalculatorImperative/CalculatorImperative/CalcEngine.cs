using System;

namespace CalculatorImperative
{
    internal class CalcEngine
    {
        // This is the behind the scenes number 
        // that represents what will be on the display 
        // and what number to store as last input
        private static string m_input;

        // Sign of the number (positive or negative) 
        private static string m_sign;

        // Current operator selected (+, -, * or /)
        public static String m_operator;

        // Last result displayed
        private static String m_lastNum;

        // Last input made
        private static String m_lastInput;

        // If the calculator should start a new input 
        // after a number is hit
        public static bool m_wait;

        // If the user is entering in decimal values
        public static bool m_decimal;

        // If the last key that was hit was the equals button
        private static bool m_lastHitEquals;

        static CalcEngine()
        {
            // "." is used to respresent no input
            // which registers as 0
            m_input = ".";

            m_sign = "+";
            m_operator = null;
            m_lastNum = null;
            m_lastInput = null;
            m_wait = false;
            m_decimal = false;
            m_lastHitEquals = false;
        }

        // Formats the input into a valid double format
        private static string FormatInput(
            string str)
        {
            // Format the input to something convertable 
            // by Convert.toDouble

            // Prepend a Zero 
            // if the string begins with a "."
            if (str.IndexOf(".") == 0)
            {
                str = "0" + str;
            }

            // Appened a Zero 
            // if the string ends with a "."
            if (str.IndexOf(".") ==
                str.Length - 1)
            {
                str = str + "0";
            }

            // If negative is turned on 
            // and there's no "-" 
            // in the current string
            // then "-" is prepended
            if (m_sign.Equals("-") &&
                str != "0.0" &&
                str.IndexOf("-") == -1)
            {
                str = "-" + str;
            }

            return str;
        }

        // Indicate that user doesn't input value yet
        private static bool IsEmpty()
        {
            if (m_input.Equals(".") || m_wait)
                return true;
            else
                return false;
        }

        // For Clear Entry, 
        // just reset appropriate variable
        public static void Clear()
        {
            //Just clear the current input
            m_sign = "+";
            m_input = ".";
            m_decimal = false;
        }

        // Resets all variables
        public static void ClearAll()
        {
            //Reset the calculator
            m_input = ".";
            m_lastNum = null;
            m_lastInput = null;
            m_operator = null;
            m_sign = "+";
            m_wait = false;
            m_decimal = false;
            m_lastHitEquals = false;
        }

        // Appends number to the input
        public static void AppendNum(
            double numValue)
        {
            if (numValue == Math.Round(numValue) &&
                numValue >= 0)
            {
                // Append number to the input string
                if (!IsEmpty())
                {
                    // if decimal is turned on
                    if (m_decimal)
                    {
                        m_input += "" + numValue;
                    }
                    else
                    {
                        m_input = m_input.Insert(
                            m_input.IndexOf("."), "" + numValue);
                    }
                }
                // If nothing was entered yet, 
                // then set input equal to the number hit
                else
                {
                    // Start over if the last key hit 
                    // was the equals button 
                    // and no operators were chosen
                    if (m_lastHitEquals)
                    {
                        ClearAll();
                        m_lastHitEquals = false;
                    }

                    if (m_decimal)
                    {
                        m_input = "." + numValue;
                    }
                    else
                    {
                        m_input = numValue + ".";
                    }
                    m_wait = false;
                }

                if (m_input.IndexOf("0", 0, 1) == 0 &&
                    m_input.IndexOf(".") > 1)
                {
                    //Get rid of any extra zeroes 
                    //that may have been prepended
                    m_input = m_input.Remove(0, 1);
                }
            }
            // If they're trying to append a decimal or negative, 
            // that's impossible so just replace the entire input
            // with that value
            else
            {
                // Start over if the last key hit 
                // was the equals button 
                // and no operators were chosen
                if (m_lastHitEquals)
                {
                    ClearAll();
                    m_lastHitEquals = false;
                }
                m_input = "" + numValue;

                // Reformat
                m_input = FormatInput(m_input);
                if (!m_input.Contains("."))
                {
                    m_input += ".";
                }

                if (m_input.Contains(".") &&
                    !(m_input.EndsWith("0") &&
                    m_input.IndexOf(".") ==
                        m_input.Length - 2))
                {
                    m_decimal = true;
                }

                if (m_input.Contains("-"))
                {
                    m_sign = "-";
                }
                else
                {
                    m_sign = "+";
                }

                // Get rid of any extra zeroes 
                // that may have been prepended or appended
                if (m_input.IndexOf("0", 0, 1) == 0 &&
                    m_input.IndexOf(".") > 1)
                {
                    m_input = m_input.Remove(0, 1);
                }

                if (m_input.EndsWith("0") &&
                    m_input.IndexOf(".") == m_input.Length - 2)
                {
                    m_input.Remove(m_input.Length - 1);
                }

                m_wait = false;
            }
        }

        // Get display from input
        public static double GetDisplay()
        {
            return Convert.ToDouble(
                FormatInput(m_input));
        }

        // Handles decimal square roots, 
        // decimal buttons, percents, inverse, delete, 
        // and sign switching
        public static bool FunctionButton(
            string str)
        {
            bool success = false;
            switch (str)
            {
                case "sqrt":
                    if (!m_sign.Equals("-"))
                    {
                        m_input = Convert.ToString(
                            Math.Sqrt(
                                Convert.ToDouble(
                                    m_input)));
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                case "percent":
                    if (m_lastNum != null)
                    {
                        m_input = Convert.ToString(
                            Convert.ToDouble(m_lastNum) *
                            (Convert.ToDouble(m_input) /
                            100));
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                case "inverse":
                    if (Convert.ToDouble(m_input) != 0)
                    {
                        m_input = Convert.ToString(
                            1 / Convert.ToDouble(
                                m_input));
                        if (Math.Abs(
                            Convert.ToDouble(
                                m_input)) -
                            (Math.Round(
                                Convert.ToDouble(
                                    m_input))) <
                            .000000001)
                        {
                            m_input = Convert.ToString(
                                Math.Round(
                                    Convert.ToDouble(
                                        m_input)));
                        }
                        success = true;
                    }
                    else
                    {
                        // Unable to inverse Zero.
                        success = false;
                    }
                    break;
                case "delete":
                    if (!m_input.Equals(".") &&
                        !m_wait)
                    {
                        if (m_decimal)
                        {
                            m_input = m_input.Remove(
                                m_input.Length - 1);
                            if (m_input.IndexOf(".") < 0)
                            {
                                m_input += ".";
                                m_decimal = false;
                            }
                        }
                        else
                        {
                            m_input = m_input.Remove(
                                m_input.IndexOf(".") - 1,
                                1);
                        }
                        if (m_input.Equals(".") ||
                            m_input.Equals("-."))
                        {
                            m_input = ".";
                            m_sign = "+";
                        }
                        success = true;
                    }
                    else
                    {
                        // Nothing to backspace
                        success = false;
                    }
                    break;
                case "switchSign":
                    if (!m_wait &&
                        !m_input.Equals("."))
                    {
                        if (m_sign.Equals("+") &&
                            !m_input.Equals(""))
                        {
                            m_sign = "-";
                            m_input = "-" + m_input;
                        }
                        else
                        {
                            if (m_sign.Equals("-"))
                            {
                                m_input = m_input.Remove(0, 1);
                            }
                            m_sign = "+";
                        }
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    break;
                case "decimal":
                    if (!m_decimal)
                    {
                        m_decimal = true;
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    break;
            }
            return success;
        }

        // Solve the currently stored expression
        public static bool Solve()
        {
            bool canSolve = true;

            // For normal solving
            if (m_operator != null)
            {
                // Clean up
                if (m_input.Equals(""))
                    m_input = "0";

                if (m_lastNum == null ||
                    m_lastNum.Equals(""))
                {
                    m_lastNum = "0.0";
                }

                if (!m_wait)
                {
                    m_lastInput = "" + FormatInput(m_input);
                }

                // We take the previous number value 
                // and perform an operation with the current value
                String answer = "";
                switch (m_operator)
                {
                    case "+":
                        answer = "" + Convert.ToString(
                            Convert.ToDouble(m_lastNum) +
                            Convert.ToDouble(m_lastInput));
                        break;
                    case "-":
                        answer = "" + Convert.ToString(
                            Convert.ToDouble(m_lastNum) -
                            Convert.ToDouble(m_lastInput));
                        break;
                    case "*":
                        answer = "" + Convert.ToString(
                            Convert.ToDouble(m_lastNum) *
                            Convert.ToDouble(m_lastInput));
                        break;
                    case "/":
                        if (!FormatInput(
                            m_lastInput).Equals("0.0"))
                        {
                            answer = "" + Convert.ToString(
                                Convert.ToDouble(m_lastNum) /
                                Convert.ToDouble(m_lastInput));
                        }
                        break;
                }

                if (answer.Equals(""))
                {
                    // The operation cannot be proceed
                    canSolve = false;
                }
                else
                {
                    m_lastNum = answer;
                    m_input = answer;
                    m_sign = "+";
                    m_decimal = false;
                    m_lastHitEquals = true;
                    m_wait = true;
                    canSolve = true;
                }
            }

            return canSolve;
        }

        // Handles operation functions
        public static void PrepareOperation(
            string strOperator)
        {
            switch (strOperator)
            {
                case "add":
                    // If this is the first number 
                    // that user inputs
                    if (m_lastNum == null ||
                        m_wait)
                    {
                        if (m_lastNum != null &&
                            !m_operator.Equals("+") &&
                            !m_lastHitEquals &&
                            !m_wait)
                            Solve();
                        m_operator = "+";
                        m_lastNum = "" + FormatInput(
                            m_input);
                        m_sign = "+";
                        m_decimal = false;
                        m_wait = true;
                    }
                    // If this is the second or higher number 
                    // that user inputs
                    // then update the results of the calculation
                    else
                    {
                        if (!m_wait)
                            Solve();
                        m_operator = "+";
                        m_sign = "+";
                        m_wait = true;
                    }
                    m_lastHitEquals = false;
                    break;
                case "subtract":
                    if (m_lastNum == null || m_wait)
                    {
                        if (m_lastNum != null &&
                            !m_operator.Equals("-") &&
                            !m_lastHitEquals && !m_wait)
                            Solve();
                        m_operator = "-";
                        m_lastNum = "" + FormatInput(m_input);
                        m_sign = "+";
                        m_decimal = false;
                        m_wait = true;
                    }
                    else
                    {
                        if (!m_wait)
                            Solve();
                        m_operator = "-";
                        m_sign = "+";
                        m_wait = true;
                    }
                    m_lastHitEquals = false;
                    break;
                case "multiply":
                    if (m_lastNum == null || m_wait)
                    {
                        if (m_lastNum != null &&
                            !m_operator.Equals("*") &&
                            !m_lastHitEquals &&
                            !m_wait)
                            Solve();
                        m_operator = "*";
                        m_lastNum = "" + FormatInput(m_input);
                        m_sign = "+";
                        m_decimal = false;
                        m_wait = true;
                    }
                    else
                    {
                        if (!m_wait)
                            Solve();
                        m_operator = "*";
                        m_sign = "+";
                        m_wait = true;
                    }
                    m_lastHitEquals = false;
                    break;
                case "divide":
                    if (m_lastNum == null || m_wait)
                    {
                        if (m_lastNum != null &&
                            !m_operator.Equals("/")
                            && !m_lastHitEquals)
                            Solve();
                        m_operator = "/";
                        m_lastNum = "" + FormatInput(m_input);
                        m_sign = "+";
                        m_decimal = false;
                        m_wait = true;
                    }
                    else
                    {
                        if (!m_wait)
                            Solve();
                        m_operator = "/";
                        m_sign = "+";
                        m_wait = true;
                    }
                    m_lastHitEquals = false;
                    break;
            }
        }
    }
}
