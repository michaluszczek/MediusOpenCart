using OpenQA.Selenium;
using System;
using Xunit;
using XUnitTestProject1.PageObjects;
using XUnitTestProject1.Utilities;

namespace XUnitTestProject1
{
    public class EtoETest : IDisposable
    {
        IWebDriver driver;        

        [Theory]
        [InlineData(Browsers.Chrome)]
        [InlineData(Browsers.Firefox)]
        public void EtoEtest(Browsers browser)
        {
            driver = Helper.startBrowser(browser);
            MainPage mainPage = new MainPage(driver);
            ResultPage resultPage = new ResultPage(driver);
            ProductComparePage productComparePage = new ProductComparePage(driver);
            ShoppingCartPage shoppingCartPage = new ShoppingCartPage(driver);

            mainPage.CurrencyDropdownClick();
            mainPage.ChooseGBP();
            mainPage.SearchForIpod();            
            resultPage.AddIpodsToProductCompare();
            resultPage.GoToProductComparison();
            Assert.True(productComparePage.IsProductComparison());
            productComparePage.removeIpodShuffle();
            var productPrice = productComparePage.addRandomIpodToCart();
            productComparePage.GoToShoppingCart();
            var shoppingCartPrice = shoppingCartPage.GetShopCartPrice();

            Assert.Equal(productPrice, shoppingCartPrice);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
