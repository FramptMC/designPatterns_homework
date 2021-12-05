using DemoqaCom.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace DemoqaCom.Tests
{
    public class SeleniumTest
    {
        private const string SIGN_UP_SUCCEED_MESSAGE = "Thanks for submitting the form";
        private readonly IWebDriver _driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            _driver.Navigate().GoToUrl("https://demoqa.com/");
            _driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        [Test]
        [TestCase("tornike", "nanobashvili", "nanobashvili@gmail.com", GenderConstants.Other, "5555555555")]
        public void OpenFormsPageTest(string username, string secondname, string email, string gender, string phoneNumber)
        {
            HomePage homePage = new HomePage(_driver);

            homePage.Forms.Click();
            Thread.Sleep(2000);

            homePage.PracticeForm.Click();
            Thread.Sleep(3000);

            SignUpForm signUpForm = new SignUpForm(_driver);
            signUpForm.SetFormValues(username, secondname, email, gender, phoneNumber);
            Thread.Sleep(6000);

            signUpForm.SubmitButton.Click();
            Thread.Sleep(3000);

            SignUpFormResultModal resultModal = new SignUpFormResultModal(_driver);

            Assert.IsTrue(resultModal.ResultMessage.Text == SIGN_UP_SUCCEED_MESSAGE);
            Assert.IsTrue(resultModal.ValidateWithTestData(username, secondname, email, gender, phoneNumber));
        }

        [TearDown]
        public void EndTest()
        {
            _driver.Close();
        }
    }
}