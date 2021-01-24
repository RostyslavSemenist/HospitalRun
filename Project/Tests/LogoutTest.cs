using HospitalRun.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HospitalRun
{
    class LogoutTest
    {

        IWebDriver webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();


        [Test]
        public void Logout()
        {
            var loginPage = new LoginPageObject(webDriver);
            loginPage
                .LoginValid();

            var patientsPage = new PatientsPageObject(webDriver);
            patientsPage
                .Logout();
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }

    }
}
