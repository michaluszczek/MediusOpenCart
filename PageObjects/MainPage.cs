using OpenQA.Selenium;

namespace XUnitTestProject1.PageObjects
{
    internal class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {

        }

        private IWebElement currencyDropdown => Driver.FindElement(By.XPath("//button[@class='btn btn-link dropdown-toggle']"));
        private IWebElement GBP => Driver.FindElement(By.Name("GBP"));
        private IWebElement searchField => Driver.FindElement(By.Name("search"));
        private IWebElement searchButton => Driver.FindElement(By.XPath("//button[@class = 'btn btn-default btn-lg']"));

        public void CurrencyDropdownClick()
        {
            currencyDropdown.Click();
        }

        public void ChooseGBP()
        {
            GBP.Click();
        }

        internal void SearchForIpod()
        {
            searchField.SendKeys("iPod");
            searchButton.Click();
        }
    }

    
}
