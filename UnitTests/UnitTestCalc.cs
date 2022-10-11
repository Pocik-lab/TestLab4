using System;
using NUnit.Framework;
using Lab2.Interfaces;
using Lab2;

namespace UnitTests
{
    public class UnitTestCalc
    {
        private ICalculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new Lab2.Calculator();
        }

        [TestCase(1, 2, 3)]
        [TestCase(-1, -2, -3)]
        [TestCase(-1, 2, 1)]
        [TestCase(1, -2, -1)]
        [TestCase(1 / 3.0, 1 / 3.0, 2 / 3.0)]
        [TestCase(double.MinValue, double.MinValue, 2 * double.MinValue)]
        [TestCase(double.MaxValue, double.MaxValue, 2 * double.MaxValue)]
        public void TestSum(double a, double b, double res)
        {
            var ans = calculator.Sum(a,b);  
            Assert.That(res, Is.EqualTo(ans));
        }

        [TestCase(1, 2, -1)]
        [TestCase(-1, -2, 1)]
        [TestCase(-1, 2, -3)]
        [TestCase(1, -2, 3)]
        [TestCase(2 / 3.0, 1 / 3.0, 1 / 3.0)]
        [TestCase(double.MinValue, double.MinValue, 0)]
        [TestCase(double.MaxValue, double.MaxValue, 0)]
        public void TestSubstract(double a, double b, double res)
        {
            var ans = calculator.Subtract(a, b);

            Assert.That(res, Is.EqualTo(ans));
        }

        [TestCase(1, 2, 2)]
        [TestCase(-1, -2, 2)]
        [TestCase(-1, 2, -2)]
        [TestCase(1, -2, -2)]
        [TestCase(1 / 3.0, 2 / 3.0, 2 / 9.0)]
        [TestCase(double.MinValue, double.MinValue, double.MinValue * double.MinValue)]
        [TestCase(double.MaxValue, double.MaxValue, double.MaxValue * double.MaxValue)]
        public void TestMultiply(double a, double b, double res)
        {
            var ans = calculator.Multiply(a, b);

            Assert.That(res, Is.EqualTo(ans));
        }

        [TestCase(1, 2, 0.5)]
        [TestCase(-1, -2, 0.5)]
        [TestCase(-1, 2, -0.5)]
        [TestCase(1, -2, -0.5)]
        [TestCase(2 / 3.0, 1 / 3.0, 2)]
        [TestCase(double.MinValue, double.MinValue, 1)]
        [TestCase(double.MaxValue, double.MaxValue, 1)]
        public void TestDivide(double a, double b, double res)
        {
            var ans = calculator.Divide(a, b);

            Assert.That(res, Is.EqualTo(ans));
        }

        [TestCase(1, 0)]
        [TestCase(1, 0.00000001)]
        [TestCase(1, 0.000000009)]
        [TestCase(1, -0.00000001)]
        [TestCase(1, -0.000000009)]
        public void TestDivideThrowsException(double a, double b)
        {
            Assert.Throws<ArithmeticException>(() => calculator.Divide(a, b));
        }

        [TestCase(1, 0.000000011)]
        [TestCase(1, -0.000000011)]
        public void TestDivideNotThrowsException(double a, double b)
        {
            Assert.DoesNotThrow(() => calculator.Divide(a, b));
        }
    }
}