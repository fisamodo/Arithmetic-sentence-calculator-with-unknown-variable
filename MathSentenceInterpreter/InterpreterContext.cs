using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathInterpreter
{
    public class InterpreterContext
    {
        public string s;
        public double x;
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
                if (x == 0.01)
                {
                    if (flag == -2)
                    {
                        s = convertUnknown(s, index, x);
                        sentence = (EvalExpression(s.ToCharArray()).ToString());
                        Console.WriteLine(EvalExpression(s.ToCharArray()).ToString());
                        return sentence;
                    }

                }
                s = convertUnknown(s, index, x);
                if (flag == -2)
                {
                    sentence = (EvalExpression(s.ToCharArray()).ToString());
                    Console.WriteLine(EvalExpression(s.ToCharArray()).ToString());
                    return sentence;
                }

                if (flag == -1)
                {
                    if (indext1 != -1)
                    {
                        s = convertToPositiveOrNegative(s, indext1, flag);
                        sentence = (EvalExpression(s.ToCharArray()).ToString());
                        Console.WriteLine(EvalExpression(s.ToCharArray()).ToString());
                        return sentence;
                    }
                    sentence = (EvalExpression(s.ToCharArray()).ToString());
                    Console.WriteLine(EvalExpression(s.ToCharArray()).ToString());
                    return sentence;
                }
                s = convertToPositiveOrNegative(s, indext1, flag);
                sentence = (EvalExpression(s.ToCharArray()).ToString());
                Console.WriteLine(EvalExpression(s.ToCharArray()).ToString());
                return sentence;
            }

            s = convertUnknown(s, index, x);
            s = convertToPositiveOrNegative(s, indext1, flag);
            sentence = (EvalExpression(s.ToCharArray()).ToString());
            Console.WriteLine(EvalExpression(s.ToCharArray()).ToString());
            return sentence;
        }
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
            //int[] ls = new int[br0];

            //foreach (int el in Ind)
            //{
            //    int br2 = 0;
            //    ls[br2] = el;
            //    br2++;
            //}
            int[] ind = Ind.ToArray();
            return ind;
        }
        static int GetIndexOfTrig(string s)
        {
            int index = s.IndexOf('c');
            if (index == -1)
                index = s.IndexOf('s');
            if (index == -1)
                index = s.IndexOf('t');
            return index;
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

        static string convertToPositiveOrNegative(string s, int indext1, int flag)
        {
            bool isNegative = false;
            string trigString;
            var aStringBuilder = new StringBuilder(s);
            double trig = convertTrig(s, indext1);
            if (s[indext1 - 1] == '-')
                isNegative = true;
            if (trig == 0 || trig == 1 || trig == 2 || trig == 3 || trig == -1 || trig == -2 || trig == -3)
            {
                if (s[indext1 + 4] == '-')
                {
                    trigString = trig.ToString();
                    aStringBuilder = new StringBuilder(s);
                    aStringBuilder.Remove(indext1 - 1, 7);
                    if (s[indext1 - 1] == '-')
                    {
                        double temp = Convert.ToDouble(trigString);
                        temp *= -1;
                        trigString = "+" + temp.ToString();
                        aStringBuilder.Insert(indext1 - 1, trigString);
                        s = aStringBuilder.ToString();
                        return s;
                    }
                    aStringBuilder.Insert(indext1 - 1, trigString);
                    s = aStringBuilder.ToString();
                    return s;
                }
                trigString = trig.ToString();
                aStringBuilder = new StringBuilder(s);
                aStringBuilder.Remove(indext1 - 1, 6);
                aStringBuilder.Insert(indext1 - 1, "+" + trigString);
                s = aStringBuilder.ToString();
                return s;
            }
            if (trig < 0 && isNegative == true)
            {
                trigString = trig.ToString();
                aStringBuilder = new StringBuilder(s);
                aStringBuilder.Remove(indext1 - 1, 1);
                aStringBuilder.Insert(indext1 - 1, trigString);
                aStringBuilder.Remove(indext1 + 1, 6);
                s = aStringBuilder.ToString();
                return s;
            }
            else
            {
                trigString = trig.ToString();
                aStringBuilder = new StringBuilder(s);
                aStringBuilder.Insert(indext1, trigString);
                aStringBuilder.Remove(indext1 + 1, 6);
                s = aStringBuilder.ToString();
                return s;
            }
        }
        static double convertTrig(string s, int indext1)
        {
            string trigNum;
            double num;
            double trig;
            if (s[indext1 - 1] == '-')
            {
                if (s[indext1 + 4] == '-')
                {
                    trigNum = s[indext1 + 5].ToString();
                    num = Convert.ToDouble(trigNum);
                    num = num * -1;
                }
                else
                {
                    trigNum = s[indext1 + 4].ToString();
                    num = Convert.ToDouble(trigNum);
                }
                if (s[indext1] == 'c')
                {
                    num = Math.Cos(num);
                }
                if (s[indext1] == 's')
                {
                    num = Math.Sin(num);
                }
                if (s[indext1] == 't')
                {
                    num = Math.Tan(num);
                }
                if (num < 0)
                {
                    trig = Math.Round(num, 1);
                    trig = Adjust(trig);
                }
                else
                {
                    trig = num * -1;
                    trig = Math.Round(trig, 1);
                    trig = Adjust(trig);
                }

            }
            else
            {
                if (s[indext1 + 4] == '-')
                {
                    trigNum = s[indext1 + 5].ToString();
                    num = Convert.ToDouble(trigNum);
                    num = num * -1;
                }
                else
                {
                    trigNum = s[indext1 + 4].ToString();
                    num = Convert.ToDouble(trigNum);
                }
                if (s[indext1] == 'c')
                {
                    num = Math.Cos(num);
                }
                if (s[indext1] == 's')
                {
                    num = Math.Sin(num);
                }
                if (s[indext1] == 't')
                {
                    num = Math.Tan(num);
                }
                trig = Math.Round(num, 1);
                trig = Adjust(trig);
            }
            return trig;



        }
        static double Adjust(double input)
        {
            double whole = Math.Truncate(input);
            double remainder = input - whole;
            if (remainder < 0.5 && remainder > 0)
            {
                remainder = 0;
            }
            if (remainder >= 0.5)
            {
                remainder = 1;
            }
            if (remainder > -0.5 && remainder < 0)
            {
                remainder = 0;
            }
            if (remainder <= -0.5)
            {
                remainder = -1;
            }

            return whole + remainder;
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
