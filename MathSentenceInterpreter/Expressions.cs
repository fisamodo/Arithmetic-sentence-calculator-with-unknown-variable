using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathSentenceInterpreter
{
    public abstract class Expressions
    {
        public abstract string BasicMathExpression(string s, double x = 0.01, int flag = -1);
        public abstract string BasicMathExpressionWithOneOrMoreUnknown(string s, double x, int flag = -2);
        public abstract string BasicMathExpressionWithTrigonometry(string s, double x);
    }
}
