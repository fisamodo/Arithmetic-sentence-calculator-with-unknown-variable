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
            string sentence = "";
            int indext1 = GetIndexOfTrig(s);
            int[] index = GetIndexes(s, 'x');
            if (flag == -1 || flag == -2)
            {
                if (flag == -1)
                {                
                    sentence = (EvalExpression(s.ToCharArray()).ToString());
                    Console.WriteLine(EvalExpression(s.ToCharArray()).ToString());
                    return sentence;
                }
                if(flag == -2)
                {
                    sentence = convertUnknown(s, index, x);
                    sentence = (EvalExpression(s.ToCharArray()).ToString());
                    Console.WriteLine(EvalExpression(s.ToCharArray()).ToString());
                    return sentence;
                }
                
            }
            return sentence;
        }
        static string convertUnknown(string s, int[] indexAr, double x)
        {
            foreach (int i in indexAr)
            {
                if (x == 0.01)
                    return s;
                int indext1 = i;
                if (i == -1)
                    indext1 = GetIndexOfTrig(s);
                int indexTemp;
                indexTemp = indext1;
                var aStringBuilder = new StringBuilder(s);
                if (x < 0)
                {
                    if (s[indexTemp - 1] == '-')
                    {
                        string val = x.ToString();
                        val = val[1].ToString();
                        val = '+' + val;
                        aStringBuilder.Remove(indexTemp - 1, 2);
                        aStringBuilder.Insert(indexTemp - 1, val);
                        s = aStringBuilder.ToString();
                    }
                    else if (s[indexTemp - 1] == '(')
                    {
                        aStringBuilder.Remove(indexTemp, 1);
                        aStringBuilder.Insert(indexTemp, x.ToString());
                        s = aStringBuilder.ToString();
                    }
                    else
                    {
                        aStringBuilder.Remove(indexTemp - 1, 2);
                        aStringBuilder.Insert(indexTemp - 1, x.ToString());
                        s = aStringBuilder.ToString();
                    }
                }
                else
                {
                    if (s[indexTemp - 1] == '-')
                    {
                        string val = x.ToString();
                        val = val[0].ToString();
                        val = '-' + val;
                        aStringBuilder.Remove(indexTemp - 1, 2);
                        aStringBuilder.Insert(indexTemp - 1, val);
                        s = aStringBuilder.ToString();
                    }
                    else if (s[indexTemp - 1] == '(')
                    {
                        aStringBuilder.Remove(indexTemp, 1);
                        aStringBuilder.Insert(indexTemp, x.ToString());
                        s = aStringBuilder.ToString();
                    }
                    aStringBuilder.Remove(indexTemp, 1);
                    aStringBuilder.Insert(indexTemp, x.ToString());
                    s = aStringBuilder.ToString();
                }
            }
            return s;
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
