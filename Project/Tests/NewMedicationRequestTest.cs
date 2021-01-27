using HospitalRun.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HospitalRun
{
    class NewMedicationRequestTest
    {
        IWebDriver webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();

        [Test]
        public void Request()
        {
            var loginPage = new LoginPageObject(webDriver);
            loginPage
                .LoginValid();

            var mainPage = new PatientsPageObject(webDriver);
            mainPage
                .NewRequest();

            var newRequest = new NewMedicationRequestPageObject(webDriver);
            newRequest
                .RequestANewMedication();
        }

        [TearDown]
        public void Quit()
        {
            webDriver.Quit();
        }
    }
}
