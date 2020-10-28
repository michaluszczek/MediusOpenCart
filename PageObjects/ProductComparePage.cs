using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using XUnitTestProject1.Utilities;

namespace XUnitTestProject1.PageObjects
{
    internal class ProductComparePage : BasePage
    {
        public ProductComparePage(IWebDriver driver) : base(driver)
        {

        }

        private IWebElement removeButton => Driver.FindElement(By.XPath("//*[@id='content']/table/tbody[2]/tr/td[4]/a"));
        private IList<IWebElement> addToCartButtons => Driver.FindElements(By.XPath("//input[@class='btn btn-primary btn-block']"));
        private IWebElement shoppingCartButton => Driver.FindElement(By.XPath("/html/body/header/div/div/div[3]/div/button"));
        private IList<IWebElement> prices => Driver.FindElements(By.XPath("*//tr[td/text() = 'Price']/td/following-sibling::*"));
        private IWebElement viewCart => Driver.FindElement(By.XPath("//*[@id='cart']/ul/li[2]/div/p/a[1]"));

        internal bool IsProductComparison()
        {
            var title = Driver.Title;
            if(title == "Product Comparison")
            {
                return true;
            }
            else
                return false;
        }

        internal void removeIpodShuffle()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            removeButton.Click();
            wait.Until(e => shoppingCartButton.Displayed);
        }

        internal decimal addRandomIpodToCart()
        {
            Random random = new Random();
            var oneOfThree = random.Next(0, 2);
            var randomIpod = addToCartButtons[oneOfThree];
            IList<IWebElement> listOfPrices = prices;
            var price = listOfPrices[oneOfThree].Text;
            var textPrice = price.Substring(price.IndexOf("£") + 1);
            var decimalPrice = Convert.ToDecimal(textPrice, new CultureInfo("en-US"));
            randomIpod.Click();
            return decimalPrice;
        }

        internal void GoToShoppingCart()
        {
            //Waits.WaitUntilClickable(Driver, shoppingCartButton, 10);
            Helper wait = new Helper(Driver);
            wait.WaitUntilCilckable(shoppingCartButton);
            shoppingCartButton.Click();
            viewCart.Click();            
        }
    }
}