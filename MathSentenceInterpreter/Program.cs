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
            string s = "";
            double x;
            string pick;
            bool reRun = true;
            MathExpressions m = new MathExpressions();
            Console.WriteLine("This calculator rounds off >0.5 to 1, and < 0.5 to 0");
            Console.WriteLine("This calculator doesn't allow decimal values as input");
            Console.WriteLine("This calculator doesn't allow ctg-arctan values as input");

            while (reRun)
            {
                Console.WriteLine("Pick your Math Expression type");
                Console.WriteLine("A - Simple sentence ('2+5-3') or Simple trigonometry sentence ('2+cos(1)')");
                Console.WriteLine("B - Simple sentence with one unknown number ('3+x')");
                Console.WriteLine("C - Simple sentence with both features from A and B");
                pick = Console.ReadLine();
                switch (pick)
                {
                    case ("A"):
                        x = 0.01;
                        Console.WriteLine("Write your A sentence");
                        s = Console.ReadLine();
                        m.BasicMathExpression(s);
                        break;
                    case ("B"):
                        Console.WriteLine("Choose your x value");
                        x = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Write your B sentence");
                        s = Console.ReadLine();
                        m.BasicMathExpressionWithOneOrMoreUnknown(s, x);
                        break;
                    case ("C"):
                        Console.WriteLine("Choose your x value");
                        x = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Write your C sentence");
                        s = Console.ReadLine();
                        m.BasicMathExpressionWithTrigonometry(s, x);
                        break;
                }
                Console.WriteLine("Do you want to try another one? y/n");
                pick = Console.ReadLine();
                if (pick == "n")
                    reRun = false;
            }

        }
    }
}
