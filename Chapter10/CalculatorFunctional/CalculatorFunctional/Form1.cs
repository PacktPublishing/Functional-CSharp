using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorFunctional
{
    public partial class Form1 : Form
    {
        Calc m_calc = new Calc();

        public Form1()
        {
            InitializeComponent();

            m_calc = m_calc.ClearAll();
        }

        //Format the display based on if commas are on or not
        private string FormatDisplay(
            string str)
        {
            String dec = "";
            int totalCommas = 0;
            int pos = 0;
            bool addNegative = false;

            if (str.StartsWith("-"))
            {
                str = str.Remove(0, 1);
                addNegative = true;
            }

            if (str.IndexOf(".") > -1)
            {
                dec = str.Substring(str.IndexOf("."), 
                    str.Length - str.IndexOf("."));
                str = str.Remove(str.IndexOf("."), 
                    str.Length - str.IndexOf("."));
            }

            if (Convert.ToDouble(str) < Math.Pow(10, 19))
            {
                if (str.Length > 3)
                {
                    totalCommas = (str.Length - (str.Length % 3)) / 3;
                    if (str.Length % 3 == 0)
                    {
                        totalCommas--;
                    }
                    pos = str.Length - 3;
                    while (totalCommas > 0)
                    {
                        str = str.Insert(pos, ",");
                        pos -= 3;
                        totalCommas--;
                    }
                }
            }

            str += "" + dec;
            if (str.IndexOf(".") == -1)
            {
                str = str + ".";
            }

            if (str.IndexOf(".") == 0)
            {
                str.Insert(0, "0");
            }
            else if (str.IndexOf(".") == str.Length - 2 && 
                str.LastIndexOf("0") == str.Length - 1)
            {
                str = str.Remove(str.Length - 1);
            }

            if (addNegative)
            {
                str = str.Insert(0, "-");
            }
            return str;
        }

        private void UpdateScreen()
        {
            double d1 = m_calc.GetDisplay();
            string str1 = Convert.ToString(d1);
            txtScreen.Text = FormatDisplay(
                str1);
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btnNum = sender as Button;
            int numValue;

            switch (btnNum.Name)
            {
                case "btn1":
                    numValue = 1;
                    break;
                case "btn2":
                    numValue = 2;
                    break;
                case "btn3":
                    numValue = 3;
                    break;
                case "btn4":
                    numValue = 4;
                    break;
                case "btn5":
                    numValue = 5;
                    break;
                case "btn6":
                    numValue = 6;
                    break;
                case "btn7":
                    numValue = 7;
                    break;
                case "btn8":
                    numValue = 8;
                    break;
                case "btn9":
                    numValue = 9;
                    break;
                default:
                    numValue = 0;
                    break;
            }
            m_calc = m_calc.AppendNum(numValue);
            UpdateScreen();
        }

        //Performs some misc function on the calcEngine based on the button that was pressed
        //(Again, everything here is merely updating the screen, 
        //but the calcEngine variable holds the true state of things)
        private void btnFunction_Click(object sender, EventArgs e)
        {
            Button btnFunction = sender as Button;
            string strValue;

            switch (btnFunction.Name)
            {
                case "btnSqrt":
                    strValue = "sqrt";
                    break;
                case "btnPercent":
                    strValue = "percent";
                    break;
                case "btnInverse":
                    strValue = "inverse";
                    break;
                case "btnDelete":
                    strValue = "delete";
                    break;
                case "btnSwitchSign":
                    strValue = "switchSign";
                    break;
                case "btnDecimal":
                    strValue = "decimal";
                    break;
                default:
                    strValue = "";
                    break;
            }
            m_calc = m_calc.FunctionButton(strValue);
            UpdateScreen();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            //Attempt to solve the math
            m_calc = m_calc.Solve();
            if (!m_calc.m_solve)
            {
                btnClearAll.PerformClick();
                UpdateScreen();
            }

            UpdateScreen();
        }

        //Tell the calculator engine to clear itself
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button)
            {
                Button btnClear = sender as Button;
                switch (btnClear.Name)
                {
                    case "btnClearAll":
                        m_calc = m_calc.ClearAll();
                        UpdateScreen();
                        break;
                    case "btnClearEntry":
                        m_calc = m_calc.Clear();
                        UpdateScreen();
                        break;
                }
            }
        }

        //Pass an operation into the calc engine (+, -, *, /) 
        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button btnOperator = sender as Button;
            string strOperator = "";

            switch (btnOperator.Name)
            {
                case "btnAdd":
                    strOperator = "add";
                    break;
                case "btnSubtract":
                    strOperator = "subtract";
                    break;
                case "btnMultiply":
                    strOperator = "multiply";
                    break;
                case "btnDivide":
                    strOperator = "divide";
                    break;
            }

            m_calc = m_calc.PrepareOperation(
                strOperator);
            UpdateScreen();
        }
    }
}
