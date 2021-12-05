using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoqaCom.Tests.PageObjects
{
    public class SignUpFormResultModal
    {
        private readonly IWebDriver _webDriver;
        private const string _resultSucceedMessage = "example-modal-sizes-title-lg";
        private const string _resultTableXPath = @"//table";
        private const string _resultTableRowXPath = "//tbody//tr";

        public SignUpFormResultModal(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            PageFactory.InitElements(_webDriver, this);
        }

        [FindsBy(How = How.Id, Using = _resultSucceedMessage)]
        public IWebElement ResultMessage { get; set; }

        [FindsBy(How = How.XPath, Using = _resultTableXPath)]
        public IWebElement ResultTable { get; set; }

        public bool ValidateWithTestData(string username, string secondname, string email, string gender, string phoneNumber)
        {
            IReadOnlyCollection<IWebElement> tableRows = ResultTable.FindElements(By.XPath(_resultTableRowXPath));
            bool valid = true;

            foreach (IWebElement element in tableRows)
            {
                var tds = element.FindElements(By.TagName("td"));

                valid = (tds[0].Text) switch
                {
                    "Student Name" => username == tds[1].Text,
                    "Student Email" => email == tds[1].Text,
                    "Gender" => gender == tds[1].Text,
                    "Mobile" => phoneNumber == tds[1].Text,
                    _ => true
                };
            }

            return valid;
        }
    }
}
