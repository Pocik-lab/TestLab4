using Lab2.Interfaces;
using Lab2;
using TestStack.White;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTests
{
    class UnitTestCalcPresenter
    {
        class TestCalcView : ICalculatorView
        {
            public string Result { get; set; }
            public string Error { get; set; }
            public string FirstArg { get; set; }
            public string SecondArg { get; set; }
            public void PrintResult(double res)
            {
                Result = res.ToString("0.##");
            }
            public void DisplayError(string message)
            {
                Error = message;
            }

            public string GetFirstArgumentAsString()
            {
                return FirstArg;
            }

            public string GetSecondArgumentAsString()
            {
                return SecondArg;
            }
        }

        private ICalculatorPresenter calculatorPresenter;
        private TestCalcView calcView;

        [SetUp]
        public void Setup()
        {
            calcView = new TestCalcView();
            calculatorPresenter = new CalculatorPresenter(calcView, new Lab2.Calculator());
        }

        [TestCase("1", "2", "3")]
        [TestCase("0,1", "0,2", "0,3")]
        [TestCase("-1", "-2", "-3")]
        [TestCase("x", "y", "0")]
        [TestCase("x", "1", "1")]
        [TestCase("1", "y", "1")]
        public void TestOnPlusClicked(string a, string b, string res)
        {
            calcView.FirstArg = a;
            calcView.SecondArg = b;

            calculatorPresenter.OnPlusClicked();

            Assert.That(res, Is.EqualTo(calcView.Result));
        }

        [TestCase("1", "2", "-1")]
        [TestCase("-1", "-2", "1")]
        [TestCase("0,1", "0,2", "-0,1")]
        [TestCase("x", "y", "0")]
        [TestCase("x", "1", "-1")]
        [TestCase("1", "y", "1")]
        public void TestOnMinusClicked(string a, string b, string res)
        {
            calcView.FirstArg = a;
            calcView.SecondArg = b;

            calculatorPresenter.OnMinusClicked();

            Assert.That(res, Is.EqualTo(calcView.Result));
        }

        [TestCase("1", "2", "2")]
        [TestCase("-1", "2", "-2")]
        [TestCase("-1", "-2", "2")]
        [TestCase("0,1", "0,2", "0,02")]
        [TestCase("x", "y", "0")]
        [TestCase("x", "1", "0")]
        [TestCase("1", "y", "0")]
        public void TestOnMultiplyClicked(string a, string b, string res)
        {
            calcView.FirstArg = a;
            calcView.SecondArg = b;

            calculatorPresenter.OnMultiplyClicked();

            Assert.That(res, Is.EqualTo(calcView.Result));
        }

        [TestCase("2", "1", "2")]
        [TestCase("2", "-1", "-2")]
        [TestCase("0,02", "0,1", "0,2")]
        [TestCase("x", "y", null)]
        [TestCase("x", "1", "0")]
        [TestCase("1", "y", null)]
        public void TestOnDivideClicked(string a, string b, string res)
        {
            calcView.FirstArg = a;
            calcView.SecondArg = b;

            calculatorPresenter.OnDivideClicked();

            Assert.That(res, Is.EqualTo(calcView.Result));
        }

        [TestCase("1", "", "Empty parameter")]
        [TestCase("", "1", "Empty parameter")]
        [TestCase("", "", "Empty parameter")]
        public void TestOnPlusClickedThrowsException(string a, string b, string res)
        {
            calcView.FirstArg = a;
            calcView.SecondArg = b;

            calculatorPresenter.OnPlusClicked();

            Assert.That(res, Is.EqualTo(calcView.Error));
        }

        [TestCase("1", "", "Empty parameter")]
        [TestCase("", "1", "Empty parameter")]
        [TestCase("", "", "Empty parameter")]
        public void TestOnMinusClickedThrowsException(string a, string b, string res)
        {
            calcView.FirstArg = a;
            calcView.SecondArg = b;

            calculatorPresenter.OnMinusClicked();

            Assert.That(res, Is.EqualTo(calcView.Error));
        }

        [TestCase("1", "", "Empty parameter")]
        [TestCase("", "1", "Empty parameter")]
        [TestCase("", "", "Empty parameter")]
        public void TestOnMultiplyClickedThrowsException(string a, string b, string res)
        {
            calcView.FirstArg = a;
            calcView.SecondArg = b;

            calculatorPresenter.OnMultiplyClicked();

            Assert.That(res, Is.EqualTo(calcView.Error));
        }

        [TestCase("1", "0", "Division by zero")]
        [TestCase("1", "0,00000001", "Division by zero")]
        [TestCase("1", "0,000000009", "Division by zero")]
        [TestCase("1", "-0,00000001", "Division by zero")]
        [TestCase("1", "-0,000000009", "Division by zero")]
        [TestCase("1", "", "Empty parameter")]
        [TestCase("", "1", "Empty parameter")]
        [TestCase("", "", "Empty parameter")]
        public void TestOnDivideClickedThrowsException(string a, string b, string res)
        {
            calcView.FirstArg = a;
            calcView.SecondArg = b;

            calculatorPresenter.OnDivideClicked();

            Assert.That(res, Is.EqualTo(calcView.Error));
        }

        [TestCase("1", "0,000000011", "Division by zero")]
        [TestCase("1", "-0,000000011", "Division by zero")]
        public void TestOnDivideClickedNotThrowsException(string a, string b, string res)
        {
            calcView.FirstArg = a;
            calcView.SecondArg = b;

            calculatorPresenter.OnDivideClicked();

            Assert.That(res, Is.Not.EqualTo(calcView.Error));
        }
    }
}
