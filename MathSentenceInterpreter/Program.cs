using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathSentenceInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            MathExpressions i = new MathExpressions();

            i.BasicMathExpressionWithOneOrMoreUnknown("2+3*x",2);
        }
    }
}
