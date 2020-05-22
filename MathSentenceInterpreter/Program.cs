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
            InterpreterContext i = new InterpreterContext("2+3*3",1);
        }
    }
}
