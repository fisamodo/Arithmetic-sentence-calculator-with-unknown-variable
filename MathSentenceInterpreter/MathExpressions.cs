using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathSentenceInterpreter
{
    public class MathExpressions : Expressions
    {
        public override string BasicMathExpression(string s, double x = 0.01, int flag = -1)
        {
            string sentence = InterpreterContext.Calculate(s, x, flag);
            return sentence;
        }

        public override string BasicMathExpressionWithOneOrMoreUnknown(string s, double x, int flag = -2)
        {

            throw new NotImplementedException();


        }

        public override string BasicMathExpressionWithTrigonometry(string s, double x)
        {
            throw new NotImplementedException();

        }
    }
}
