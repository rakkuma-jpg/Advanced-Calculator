using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorPrivateAssembly;

namespace AdvancedCalculator
{
    public partial class Calculator : Form
    {
        //user input list, needs to be flushed after used
        private List<string> currentNumber = new List<string>();

        //num1,num2 is equals to its currenNumber
        private float num1;
        private float num2;
        private float result;

        private string currentOperator = "";
        private bool isEnteringSecondNumber = false;

        public Calculator()
        {
            InitializeComponent();
        }
        private void Num1_EqualsToCurrentNumber()
        {
            string temp = string.Join("", currentNumber);
            this.num1 = float.Parse(temp);
            Console.WriteLine("currentNumber: " + string.Join(", ", this.currentNumber));
            Console.WriteLine("num1 operation result: " + this.num1);
            currentNumber.Clear();
            this.isEnteringSecondNumber = true;
        }
        private void Num2_EqualsToCurrentNumber()
        {
            string temp = string.Join("", currentNumber);
            this.num2 = float.Parse(temp);
            Console.WriteLine("currentNumber: " + string.Join(", ", this.currentNumber));
            Console.WriteLine("num2 operation result: " + this.num2);
            currentNumber.Clear();
            
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            this.currentNumber.Add(btn.Text);
            lblDisplay.Text = string.Join("", this.currentNumber);

        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            currentOperator = btn.Text;

            if (!this.isEnteringSecondNumber)
            {
                Num1_EqualsToCurrentNumber();
            }
            else
            {
                Num2_EqualsToCurrentNumber();
            }

        }
        private void Compute()
        {
            float result = 0;

            switch (this.currentOperator)
            {
                case "+":
                    result = BasicComputation.Add(this.num1, this.num2);
                    break;
                case "-":
                    result = BasicComputation.Subtract(this.num1, this.num2);
                    break;
                case "*":
                    result = BasicComputation.Multiply(this.num1, this.num2);
                    break;
                case "÷":
                    result = BasicComputation.Divide(this.num1, this.num2);
                    break;
                case "%":
                    result = BasicComputation.Percent(this.num1, this.num2);
                    break;
            }

            this.result = result;
        }
        private void btnEquals_Click(object sender, EventArgs e)
        {
            Compute();
            lblDisplay.Text = string.Join("", this.result);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            currentNumber.Clear();
            num1 = 0;
            num2 = 0;
            result = 0;
            currentOperator = "";
            isEnteringSecondNumber = false;
            lblDisplay.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string item = currentNumber[currentNumber.Count - 1];
            currentNumber.RemoveAt(currentNumber.Count - 1 );
            lblDisplay.Text = string.Join("", this.currentNumber);
        }
    }
}
