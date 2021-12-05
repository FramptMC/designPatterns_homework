using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoqaCom.Tests.PageObjects
{
    public class SignUpForm
    {
        private IWebDriver _webDriver;

        public SignUpForm(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            PageFactory.InitElements(_webDriver, this);

            Genders = new RadioButtons(_webDriver, _webDriver.FindElements(By.Name("gender")));
        }
        
        [FindsBy(How = How.Id, Using = "userForm")]
        public IWebElement Form { get; set; }

        [FindsBy(How = How.Id, Using = "submit")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement LastNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "userEmail")]
        public IWebElement UserEmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "userNumber")]
        public IWebElement UserNumberInput { get; set; }

        public RadioButtons Genders { get; set; }

        public void SetFormValues(string firstName, string lastName, string userEmail, string gender, string userNumber)
        {
            FirstNameInput.SendKeys(firstName);
            LastNameInput.SendKeys(lastName);
            UserEmailInput.SendKeys(userEmail);
            UserNumberInput.SendKeys(userNumber);
            Genders.SelectValue(gender);
        }
    }
}
