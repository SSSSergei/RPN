using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPNLogic
{
    public enum Operators
    {
        Plus = '+',
        Minus = '-',
        Mul = '*',
        Divide = '/',
        Pow = '^',
        OpenBracket = '(',
        CloseBracket = ')'
    }

    public class Transfer
    {
        private char[] data { get; set; }
        public Transfer(string data)
        {
            this.data = data.ToCharArray().Where(x=>x!=' ').ToArray();
        }

        public string GetRPN()
        {
            var stack = new Stack<char>();
            var queue = new Queue<char>();
            foreach (var sym in data)
            {
                if (Char.IsLetterOrDigit(sym) || sym == 'x')
                {
                    queue.Enqueue(sym);
                }
                else if (stack.Count == 0 || sym == (char)Operators.OpenBracket 
                    || GetPriority(stack.Peek()) < GetPriority(sym))
                {
                    stack.Push(sym);
                }
                else if (sym == (char)Operators.CloseBracket)
                {
                    while (stack.Peek() != (char)Operators.OpenBracket)
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.Count > 0 && GetPriority(stack.Peek()) >= GetPriority(sym))
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Push(sym);
                }
            }
            while (stack.Count != 0)
                queue.Enqueue(stack.Pop());
            return GetString(queue);
        }

        private int GetPriority(char op)
        {
            switch(op)
            {
                case (char)Operators.Pow:
                    return 4;
                case (char)Operators.Mul:
                    return 3;
                case (char)Operators.Divide:
                    return 3;
                case (char)Operators.Plus:
                    return 2;
                case (char)Operators.Minus:
                    return 2;
            }
            return 1;
        }

        private string GetString(Queue<char> data)
        {
            var sb = new StringBuilder();
            foreach (var item in data)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
