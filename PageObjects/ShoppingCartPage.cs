using OpenQA.Selenium;
using System;
using System.Globalization;

namespace XUnitTestProject1.PageObjects
{
    internal class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {

        }

        private IWebElement totalPrice => Driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/table/tbody/tr[4]/td[2]"));
        internal decimal GetTotalPrice()
        {
            var price = totalPrice.Text;
            var textPrice = price.Substring(price.IndexOf('£') + 1);
            var decimalPrice = Convert.ToDecimal(textPrice, new CultureInfo("en-US"));
            return decimalPrice;
        }
    }
}
