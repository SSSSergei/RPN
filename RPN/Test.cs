using RPNLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace RPN
{
    class Test
    {
        public void Tests()
        {
            var str1 = "2^x";
            var t1 = new Transfer(str1).GetRPN();
            var v1 = new Calculator(0, t1).Calculate();
            var results = new Results(1, 1, 4, str1).AllResults;
        }
    }
}
