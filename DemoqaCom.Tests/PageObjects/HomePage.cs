using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoqaCom.Tests.PageObjects
{
    public class HomePage
    {
        private IWebDriver _webDriver;

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            PageFactory.InitElements(_webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = @"//h5[text()='Forms']")]
        public IWebElement Forms { get; set; }

        [FindsBy(How = How.XPath, Using = @"//span[@class='text' and text() = 'Practice Form']")]
        public IWebElement PracticeForm { get; set; }
    }
}
