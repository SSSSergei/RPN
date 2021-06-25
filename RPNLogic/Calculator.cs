using System;
using System.Collections.Generic;
using System.Linq;

namespace RPNLogic
{
    public class Calculator
    {
        private int x { get; set; }
        private char[] data { get; set; }

        public Calculator(int x, string data)
        {
            this.x = x;
            this.data = data.ToCharArray().Where(x => x != ' ').ToArray();
        }

        public double Calculate()
        {
            var stack = new Stack<double>();
            foreach (var sym in data)
            {
                if (sym == 'x')
                    stack.Push(x);
                else if (Char.IsLetterOrDigit(sym))
                    stack.Push(double.Parse(sym.ToString()));
                else
                    stack.Push(CurrentCalculate(stack.Pop(), stack.Pop(), sym));
            }
            return stack.Pop();
        }

        private double CurrentCalculate(double second, double first, char op)
        {
            switch (op)
            {
                case (char)Operators.Plus:
                    return first + second;
                case (char)Operators.Minus:
                    return first - second;
                case (char)Operators.Mul:
                    return first * second;
                case (char)Operators.Divide:
                    return first / second;
                case (char)Operators.Pow:
                    return Math.Pow(first, second);
                default:
                    throw new Exception("Detected unknown symbol!");
            }
        }
    }
}
