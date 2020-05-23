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
        public static string Calculate(string s, double x = 0.01, int flag = 0)
        {
            Console.WriteLine(EvalExpression(s.ToCharArray()).ToString());
            return EvalExpression(s.ToCharArray()).ToString();
        }

        //Method returns all indexes of all unknown numbers in the sentence
        static int[] GetIndexes(string s, char c)
        {
            int br1 = 0;
            int br0 = 0;
            List<int> Ind = new List<int>();
            foreach (char i in s)
            {

                if (i == c)
                {
                    Ind.Add(br1);
                    br0++;
                }
                br1++;
            }
            int[] ind = Ind.ToArray();
            return ind;
        }
        //Method returns index of trigonometry expression in the sentence
        static int GetIndexOfTrig(string s)
        {
            int index = s.IndexOf('c');
            if (index == -1)
                index = s.IndexOf('s');
            if (index == -1)
                index = s.IndexOf('t');
            return index;
        }
        public static double EvalExpression(char[] expr)
        {
            return parseSummands(expr, 0);
        }
        public static double parseSummands(char[] expr, int index)
        {
            double x = parseFactors(expr, ref index);
            while (true)
            {
                char op = expr[index];
                if (op != '+' && op != '-')
                    return x;
                index++;
                double y = parseFactors(expr, ref index);
                if (op == '+')
                    x += y;
                else
                    x -= y;
            }
        }
        public static double parseFactors(char[] expr, ref int index)
        {
            double x = GetDouble(expr, ref index);
            while (true)
            {
                char op = expr[index];
                if (op != '/' && op != '*')
                    return x;
                index++;
                double y = GetDouble(expr, ref index);
                if (op == '/')
                    x /= y;
                else
                    x *= y;
            }
        }

        public static double GetDouble(char[] expr, ref int index)
        {
            string dbl = "";
            while (((int)expr[index] >= 48 && (int)expr[index] <= 57) || expr[index] == 48)
            {
                dbl = dbl + expr[index].ToString();
                index++;
                if (index == expr.Length)
                {
                    index--;
                    break;
                }
            }
            return double.Parse(dbl);


        }
    }
}
