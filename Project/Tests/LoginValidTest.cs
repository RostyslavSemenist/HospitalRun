using HospitalRun.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HospitalRun
{
    public class LoginValidTest
    {

        IWebDriver webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();


        [Test]
        public void LogIn_Valid()
        {
            var loginPage = new LoginPageObject(webDriver);
            loginPage
                .LoginValid();
        }
        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }


    }
}


