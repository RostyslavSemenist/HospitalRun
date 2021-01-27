using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace HospitalRun.PageObjects
{
    class LoginPageObject
    {
        private IWebDriver _webDriver;

        //Data
        const string _pageURL = ("http://demo.hospitalrun.io/#/login");
        const string _userName = ("hr.doctor@hospitalrun.io");
        const string _password = ("HRt3st12");
        const string _expectedPage = ("http://demo.hospitalrun.io/#/patients");

        //UILocators
        private readonly By _usernameField = By.CssSelector("#identification");
        private readonly By _passwordField = By.CssSelector("#password");
        private readonly By _signInButton = By.CssSelector(".btn-lg");
        private readonly By _alert = By.CssSelector(".alert");

        public LoginPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void LoginValid()
        {
            _webDriver.Navigate().GoToUrl(_pageURL);
            Thread.Sleep(1000);

            var usernameField = _webDriver.FindElement(_usernameField);

            usernameField.Click();
            usernameField.SendKeys(_userName);

            var passwordField = _webDriver.FindElement(_passwordField);
            passwordField.Click();
            passwordField.SendKeys(_password);

            var singinButton = _webDriver.FindElement(_signInButton);
            singinButton.Click();

            Thread.Sleep(10000);

            string actualPage = _webDriver.Url;

            Assert.AreEqual(_expectedPage, actualPage, "URL is wrong, user isn't logged out or opened wrong page");

        }

        public void LoginInvalid()
        {
            _webDriver.Navigate().GoToUrl(_pageURL);
            Thread.Sleep(1000);

            var usernameField = _webDriver.FindElement(_usernameField);
            usernameField.Click();
            usernameField.SendKeys(_userName + "1");

            var passwordField = _webDriver.FindElement(_passwordField);
            passwordField.Click();
            passwordField.SendKeys(_password + "1");

            var singinButton = _webDriver.FindElement(_signInButton);
            singinButton.Click();

            Thread.Sleep(500);
            Assert.IsTrue(_webDriver.FindElement(_alert).Displayed);
        }


    }
}
