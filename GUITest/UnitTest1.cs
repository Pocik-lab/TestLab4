using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;
using System.Collections.Generic;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;
using System.Threading;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace GUITest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly static string path = @"C:\Users\Александр Тегин\Desktop\Тестирование\Lab2\Lab2\bin\Debug\Lab2.exe";
        public Window AppStart()
        {
            Application application = null;
            Window window = null;
            application = Application.Launch(path);
            var windows = application.GetWindows();
            window = windows.Find(x => x.Id == "CalculatorForm");
            return window;
        }

        [TestCase("1", "2", "3")]
        [TestCase("0,1", "0,2", "0,3")]
        [TestCase("-1", "-2", "-3")]
        [TestCase("x", "y", "0")]
        [TestCase("x", "1", "1")]
        [TestCase("1", "y", "1")]
        public void TestOnPlusClicked(string a, string b, string res)
        {
            var window = AppStart();
            TextBox firstArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbA"));
            Thread.Sleep(1000);
            firstArg.SetValue(a);
            TextBox secArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbB"));
            Thread.Sleep(1000);
            secArg.SetValue(b);
            Button sumClick = window.Get<Button>(SearchCriteria.ByAutomationId("btSum"));
            Thread.Sleep(1000);
            sumClick.Click();
            TextBox Display = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbMessage"));
            Assert.That(res, Is.EqualTo(Display.Name.ToString()));
            Thread.Sleep(2000);
            window.Close();
        }

        [TestCase("1", "2", "-1")]
        [TestCase("-1", "-2", "1")]
        [TestCase("0,1", "0,2", "-0,1")]
        [TestCase("x", "y", "0")]
        [TestCase("x", "1", "-1")]
        [TestCase("1", "y", "1")]
        public void TestOnMinusClicked(string a, string b, string res)
        {
            var window = AppStart();
            TextBox firstArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbA"));
            Thread.Sleep(1000);
            firstArg.SetValue(a);
            TextBox secArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbB"));
            Thread.Sleep(1000);
            secArg.SetValue(b);
            Button minusClick = window.Get<Button>(SearchCriteria.ByAutomationId("BtSubstract"));
            Thread.Sleep(1000);
            minusClick.Click();
            TextBox Display = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbMessage"));
            Assert.That(res, Is.EqualTo(Display.Name.ToString()));
            Thread.Sleep(2000);
            window.Close();
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
            var window = AppStart();
            TextBox firstArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbA"));
            Thread.Sleep(1000);
            firstArg.SetValue(a);
            TextBox secArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbB"));
            Thread.Sleep(1000);
            secArg.SetValue(b);
            Button mulClick = window.Get<Button>(SearchCriteria.ByAutomationId("btMultiply"));
            Thread.Sleep(1000);
            mulClick.Click();
            TextBox Display = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbMessage"));
            Assert.That(res, Is.EqualTo(Display.Name.ToString()));
            Thread.Sleep(2000);
            window.Close();
        }

        [TestCase("2", "1", "2")]
        [TestCase("2", "-1", "-2")]
        [TestCase("0,02", "0,1", "0,2")]
        [TestCase("x", "y", "Division by zero")]
        [TestCase("x", "1", "0")]
        [TestCase("1", "y", "Division by zero")]
        public void TestOnDivideClicked(string a, string b, string res)
        {
            var window = AppStart();
            TextBox firstArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbA"));
            Thread.Sleep(1000);
            firstArg.SetValue(a);
            TextBox secArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbB"));
            Thread.Sleep(1000);
            secArg.SetValue(b);
            Button divClick = window.Get<Button>(SearchCriteria.ByAutomationId("btDevide"));
            Thread.Sleep(1000);
            divClick.Click();
            TextBox Display = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbMessage"));
            Assert.That(res, Is.EqualTo(Display.Name.ToString()));
            Thread.Sleep(2000);
            window.Close();
        }

        [TestCase("1", "", "Empty parameter")]
        [TestCase("", "1", "Empty parameter")]
        [TestCase("", "", "Empty parameter")]
        public void TestOnPlusClickedThrowsException(string a, string b, string res)
        {
            var window = AppStart();
            TextBox firstArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbA"));
            Thread.Sleep(1000);
            firstArg.SetValue(a);
            TextBox secArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbB"));
            Thread.Sleep(1000);
            secArg.SetValue(b);
            Button sumClick = window.Get<Button>(SearchCriteria.ByAutomationId("btSum"));
            Thread.Sleep(1000);
            sumClick.Click();
            TextBox Display = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbMessage"));
            Assert.That(res, Is.EqualTo(Display.Name.ToString()));
            Thread.Sleep(2000);
            window.Close();
        }

        [TestCase("1", "", "Empty parameter")]
        [TestCase("", "1", "Empty parameter")]
        [TestCase("", "", "Empty parameter")]
        public void TestOnMinusClickedThrowsException(string a, string b, string res)
        {
            var window = AppStart();
            TextBox firstArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbA"));
            Thread.Sleep(1000);
            firstArg.SetValue(a);
            TextBox secArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbB"));
            Thread.Sleep(1000);
            secArg.SetValue(b);
            Button minusClick = window.Get<Button>(SearchCriteria.ByAutomationId("BtSubstract"));
            Thread.Sleep(1000);
            minusClick.Click();
            TextBox Display = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbMessage"));
            Assert.That(res, Is.EqualTo(Display.Name.ToString()));
            Thread.Sleep(2000);
            window.Close();
        }

        [TestCase("1", "", "Empty parameter")]
        [TestCase("", "1", "Empty parameter")]
        [TestCase("", "", "Empty parameter")]
        public void TestOnMultiplyClickedThrowsException(string a, string b, string res)
        {
            var window = AppStart();
            TextBox firstArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbA"));
            Thread.Sleep(1000);
            firstArg.SetValue(a);
            TextBox secArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbB"));
            Thread.Sleep(1000);
            secArg.SetValue(b);
            Button mulClick = window.Get<Button>(SearchCriteria.ByAutomationId("btMultiply"));
            Thread.Sleep(1000);
            mulClick.Click();
            TextBox Display = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbMessage"));
            Assert.That(res, Is.EqualTo(Display.Name.ToString()));
            Thread.Sleep(2000);
            window.Close();
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
            var window = AppStart();
            TextBox firstArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbA"));
            Thread.Sleep(1000);
            firstArg.SetValue(a);
            TextBox secArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbB"));
            Thread.Sleep(1000);
            secArg.SetValue(b);
            Button divClick = window.Get<Button>(SearchCriteria.ByAutomationId("btDevide"));
            Thread.Sleep(1000);
            divClick.Click();
            TextBox Display = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbMessage"));
            Assert.That(res, Is.EqualTo(Display.Name.ToString()));
            Thread.Sleep(2000);
            window.Close();
        }

        [TestCase("1", "0,000000011", "Division by zero")]
        [TestCase("1", "-0,000000011", "Division by zero")]
        public void TestOnDivideClickedNotThrowsException(string a, string b, string res)
        {
            var window = AppStart();
            TextBox firstArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbA"));
            Thread.Sleep(1000);
            firstArg.SetValue(a);
            TextBox secArg = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbB"));
            Thread.Sleep(1000);
            secArg.SetValue(b);
            Button divClick = window.Get<Button>(SearchCriteria.ByAutomationId("btDevide"));
            Thread.Sleep(1000);
            divClick.Click();
            TextBox Display = window.Get<TextBox>(SearchCriteria.ByAutomationId("tbMessage"));
            Assert.That(res, Is.Not.EqualTo(Display.Name.ToString()));
            Thread.Sleep(2000);
            window.Close();
        }
    }
}
