using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathSentenceInterpreter
{
    public class InterpreterContext
    {
        string s;
        double x;
        public InterpreterContext(String s, double x)
        {
            this.s = s;
            this.x = x;
        }
    }
}
