using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace HospitalRun.PageObjects
{
    class PatientsPageObject
    {
        private IWebDriver _webDriver;

        //UILocators
        private readonly By _settingsButton = By.CssSelector("span.octicon-gear");
        private readonly By _LogoutButton = By.CssSelector(".logout");
        private readonly By _MedicationButton = By.XPath("//*[text()='Medication']");
        private readonly By _RequestsButton = By.XPath("//*[text()='Requests']");
        private readonly By _CompletedButton = By.XPath("//*[text()='Completed']");
        private readonly By _NewRequestButton = By.XPath("//*[text()='New Request']");
        private readonly By _ReturnMedicationButton = By.XPath("//*[text()='Return Medication']");
        //Data
        const string _expectedPage = ("http://demo.hospitalrun.io/#/login");

        public PatientsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Logout()
        {
            _webDriver.FindElement(_settingsButton).Click();
            _webDriver.FindElement(_LogoutButton).Click();

            Thread.Sleep(10000);

            string actualPage = _webDriver.Url;
            Assert.AreEqual(_expectedPage, actualPage, "URL is wrong, user isn't logged out or opened wrong page");
        }

        public void NewRequest()
        {
            _webDriver.FindElement(_MedicationButton).Click();
            _webDriver.FindElement(_RequestsButton);
            _webDriver.FindElement(_CompletedButton);
            _webDriver.FindElement(_NewRequestButton);
            _webDriver.FindElement(_ReturnMedicationButton);

            _webDriver.FindElement(_NewRequestButton).Click();
        }
    }
}
