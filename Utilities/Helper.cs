using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using XUnitTestProject1.PageObjects;

namespace XUnitTestProject1.Utilities
{
    internal class Helper : BasePage
    {        
        public Helper(IWebDriver driver) : base(driver)
        {

        }
        public static string StartUrl { get; } = "http://demo.opencart.com/";
        public static IWebDriver startBrowser(Browsers browser)
        {
            var driver = WebDrivers.MakeDriver(browser);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(StartUrl);
            return driver;
        }

        public static IWebElement WaitUntilCilckable(IWebElement elementToBeCilcked)
        {
            WebDriverWait wait = new WebDriverWait(BasePage.Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until<IWebElement>(driver =>
            {
                try
                {
                    if (elementToBeCilcked.Displayed && elementToBeCilcked.Enabled)
                    {
                        return elementToBeCilcked;
                    }
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
            return element;
        }
    } 
}


