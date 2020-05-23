using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MathSentenceInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            MathExpressions m = new MathExpressions();

            string s = "2+cos(2)";
            double x = 0.01;
            m.BasicMathExpression(s,x);

        }
    }
}
