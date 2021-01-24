using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
namespace HospitalRun.PageObjects
{
    class NewMedicationRequestPageObject
    {
        private IWebDriver _webDriver;

        //Data
        private const string _PatientName = ("Test Patient");
        private const string _Medication = ("Pramoxine");
        private const string _PrescriptionText = ("Testing prescription");
        private const string _PatientFullName = ("Test Patient - P00201");

        //UILocators
        private readonly By _PatientField = By.CssSelector("#patientTypeAhead-ember2318");
        private readonly By _NeededPatient = By.XPath("//*[@id='ember2354']/span/div/div/div[4]/strong");
        private readonly By _VisitButton = By.CssSelector("#visit-ember2363");
        private readonly By _NeededVisitDate = By.XPath("//*[@id='visit-ember2363']/option[2]");
        private readonly By _MedicationField = By.CssSelector("#inventoryItemTypeAhead-ember2385");
        
        private readonly By _NeededMedication = By.XPath("//*[@id='ember2389']/span/div/div/div[1]");
        private readonly By _PrescriptionField = By.CssSelector("#prescription-ember2417");
        
        private readonly By _PrecriptionDateField = By.CssSelector("#display_prescriptionDate-ember2440");
        private readonly By _QuantityRequestedField = By.CssSelector("#quantity-ember2459");
        private readonly By _RefillsField = By.CssSelector("#refills-ember2466");
        private readonly By _AddButton = By.XPath("//*[@id='ember2281']/div/div[2]/button[2]");
        private readonly By _ModalDialog = By.CssSelector("#ember412");
        private readonly By _ModalOkButton = By.XPath("//button[text()='Ok']");
        private readonly By _CloseButton = By.CssSelector(".octicon");
        private readonly By _PageName = By.CssSelector(".view-current-title");

        

        

        public NewMedicationRequestPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void RequestANewMedication()
        {
            Thread.Sleep(1000);
            var patientField = _webDriver.FindElement(_PatientField);
            patientField.Click();

            Thread.Sleep(1000);
            patientField.SendKeys(_PatientName);

            Thread.Sleep(1000);
            _webDriver.FindElement(_NeededPatient).Click();

            Thread.Sleep(1000);
            _webDriver.FindElement(_VisitButton).Click();
            
            Thread.Sleep(2000);
            _webDriver.FindElement(_NeededVisitDate).Click();

            var medicationField = _webDriver.FindElement(_MedicationField);
            medicationField.Click();
            medicationField.SendKeys(_Medication);
            _webDriver.FindElement(_NeededMedication).Click();

            var prescriptionField = _webDriver.FindElement(_PrescriptionField);
            prescriptionField.Click();
            prescriptionField.SendKeys(_PrescriptionText);

            //DateTime today = DateTime.Today.Date;
         
            var prescriptionDateField = _webDriver.FindElement(_PrecriptionDateField);
            prescriptionDateField.Click();
            prescriptionDateField.Clear();

            DateTime now = DateTime.Now;

            prescriptionDateField.SendKeys(now.ToString("d"));

            Thread.Sleep(1000);

            var quantityRequestedField = _webDriver.FindElement(_QuantityRequestedField);
            quantityRequestedField.Click();

            Random random = new Random();
            int value = random.Next(1, 5);

            quantityRequestedField.SendKeys(value.ToString());

            var refillsField = _webDriver.FindElement(_RefillsField);
            refillsField.Click();
            refillsField.SendKeys(value.ToString());

            Thread.Sleep(1000);
            _webDriver.FindElement(_AddButton).Click();

            Thread.Sleep(2000);
            Assert.IsTrue(_webDriver.FindElement(_ModalDialog).Displayed);
            Assert.IsTrue(_webDriver.FindElement(_CloseButton).Displayed);

            _webDriver.FindElement(_ModalOkButton).Click();

            Thread.Sleep(2000);
            Assert.IsTrue(_webDriver.FindElement(_PageName).Displayed);









        }



    }
}
