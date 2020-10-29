using OpenQA.Selenium;
using System;
using Xunit;
using OpenCartTest.PageObjects;
using OpenCartTest.Utilities;

namespace OpenCartTest
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

            mainPage.VerifyPage();
            mainPage.CurrencyDropdownClick();
            mainPage.ChooseGBP();
            mainPage.SearchForIpod();            
            resultPage.AddIpodsToProductCompare();
            resultPage.GoToProductComparison();
            productComparePage.IsProductComparison();
            productComparePage.removeIpodShuffle();
            var productPrice = productComparePage.addRandomIpodToCart();
            productComparePage.GoToShoppingCart();
            var totalPrice = shoppingCartPage.GetTotalPrice();

            Assert.Equal(productPrice, totalPrice);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
