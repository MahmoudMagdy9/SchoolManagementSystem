using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    internal class Calculator
    {
        private static double firstNumValue;
        private static double secondNumValue;
        public enum CalculatorOperationType { Addition, Substraction, Dividing, Multiplying, None };

        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public string Operator { get; set; }

        public double CalculateResult()
        {
            switch (Operator)
            {
                case "+":
                    return Operand1 + Operand2;
                case "-":
                    return Operand1 - Operand2;
                case "*":
                    return Operand1 * Operand2;
                case "/":
                    return Operand1 / Operand2;
                default:
                    throw new InvalidOperationException("Invalid operator");
            }
        }
    }
}
