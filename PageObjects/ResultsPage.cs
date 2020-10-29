using OpenQA.Selenium;
using System.Collections.Generic;

namespace OpenCartTest.PageObjects
{
    internal class ResultPage : BasePage
    {
        public ResultPage(IWebDriver driver) : base(driver)
        {

        }

        private IList<IWebElement> compareButtons => Driver.FindElements(By.XPath("//i[@class='fa fa-exchange']"));
        private IWebElement productCompare => Driver.FindElement(By.Id("compare-total"));

        public void AddIpodsToProductCompare()
        {
            foreach(var ipod in compareButtons)
            {
                ipod.Click();
            }
        }
        public void GoToProductComparison()
        {
            productCompare.Click();
        }
    }    
}
