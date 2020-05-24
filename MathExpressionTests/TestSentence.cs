using System;
using MathSentenceInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathExpressionTests
{
    [TestClass]
    public class TestSentence
    {
        [TestMethod]
        public void TestBasicMathSentenceWithNumberAndUnknownNumber()
        {
            string s = "2+x";
            double x;
            x = 2;
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpressionWithOneOrMoreUnknown(s, x);
            Assert.AreEqual(sentence, "4");


        }
        [TestMethod]
        public void TestBasicMathSentenceWithNumberAndTrigonometry()
        {
            string s = "2+cos(1)";
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpression(s);
            Assert.AreEqual(sentence, "3");
        }
        [TestMethod]
        public void TestBasicMathSentenceWithNumberUnknownNumberAndTrigonometryAndAddition()
        {
            string s = "2+x+cos(1)";
            double x;
            x = 2;
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpressionWithTrigonometry(s, x);
            Assert.AreEqual(sentence, "5");
        }
        [TestMethod]
        public void TestBasicMathSentenceWithNumberUnknownInTrigonometryAndAddition()
        {
            string s = "2+2+cos(x)";
            double x;
            x = 1;
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpressionWithTrigonometry(s, x);
            Assert.AreEqual(sentence, "5");
        }
        [TestMethod]
        public void TestBasicMathSentenceWithTwoOrMoreNumbers()
        {
            string s = "1+2+3-3-2-1";
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpression(s);
            Assert.AreEqual(sentence, "0");

        }
        [TestMethod]
        public void TestBasicMathSentenceWithTwoUnknownNumbers()
        {
            string s = "1+3+x+x";
            double x = 3;
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpressionWithOneOrMoreUnknown(s, x);
            Assert.AreEqual(sentence, "10");

        }
        [TestMethod]
        public void TestBasicMathSentenceWithTwoUnknownNumbersOneBeingTrig()
        {
            string s = "1+3+x+cos(x)";
            double x = -1;
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpressionWithTrigonometry(s, x);
            Assert.AreEqual(sentence, "4");

        }
        [TestMethod]
        public void TestBasicMathSentenceWithTwoUnknownNumbersOneBeingTrigSin()
        {
            string s = "1+3+x+sin(x)";
            double x = -1;
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpressionWithTrigonometry(s, x);
            Assert.AreEqual(sentence, "2");

        }
        [TestMethod]
        public void TestBasicMathSentenceWithTwoUnknownNumbersOneBeingTrigTan()
        {
            string s = "1+3+x+tan(x)";
            double x = -1;
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpressionWithTrigonometry(s, x);
            Assert.AreEqual(sentence, "1");

        }
        [TestMethod]
        public void TestBasicMathSentenceWithTwoUnknownNumbersOneBeingTrigSinNegative()
        {
            string s = "1+3-x-sin(x)";
            double x = -1;
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpressionWithTrigonometry(s, x);
            Assert.AreEqual(sentence, "6");

        }
        [TestMethod]
        public void TestBasicMathSentenceWithTwoUnknownNumbersOneBeingTrigTanNegative()
        {
            string s = "1+3-x-tan(x)";
            double x = -1;
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpressionWithTrigonometry(s, x);
            Assert.AreEqual(sentence, "7");

        }
        [TestMethod]
        public void TestBasicMathSentenceWithTwoUnknownNumbersOneBaeingTrigTanNegative()
        {
            string s = "1+3-x-3*2-tan(x)";
            double x = -1;
            MathExpressions m = new MathExpressions();
            string sentence = m.BasicMathExpressionWithTrigonometry(s, x);
            Assert.AreEqual(sentence, "1");

        }
    }
}
