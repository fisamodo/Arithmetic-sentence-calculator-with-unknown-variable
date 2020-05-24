using MathSentenceInterpreter;
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
            int indext1 = SentenceTranslator.GetIndexOfTrig(s);
            int[] index = SentenceTranslator.GetIndexes(s, 'x');
            if (flag == -1 || flag == -2)
            {
                if (flag == -2)
                {
                    s = SentenceTranslator.convertUnknown(s, index, x);
                    sentence = (MathParser.EvalExpression(s.ToCharArray()).ToString());
                    Console.WriteLine(MathParser.EvalExpression(s.ToCharArray()).ToString());
                    return sentence;
                }
                if (flag == -1)
                {
                    if (indext1 != -1)
                    {
                        s = SentenceTranslator.convertToPositiveOrNegative(s, indext1, flag);
                        sentence = (MathParser.EvalExpression(s.ToCharArray()).ToString());
                        Console.WriteLine(MathParser.EvalExpression(s.ToCharArray()).ToString());
                        return sentence;
                    }
                    sentence = (MathParser.EvalExpression(s.ToCharArray()).ToString());
                    Console.WriteLine(MathParser.EvalExpression(s.ToCharArray()).ToString());
                    return sentence;
                }
                s = SentenceTranslator.convertToPositiveOrNegative(s, indext1, flag);
                sentence = (MathParser.EvalExpression(s.ToCharArray()).ToString());
                Console.WriteLine(MathParser.EvalExpression(s.ToCharArray()).ToString());
                return sentence;
            }
            s = SentenceTranslator.convertUnknown(s, index, x);
            s = SentenceTranslator.convertToPositiveOrNegative(s, indext1, flag);
            sentence = (MathParser.EvalExpression(s.ToCharArray()).ToString());
            Console.WriteLine(MathParser.EvalExpression(s.ToCharArray()).ToString());
            return sentence;
        }
        
       
    }
}
