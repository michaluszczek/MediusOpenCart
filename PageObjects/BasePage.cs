using OpenQA.Selenium;

namespace XUnitTestProject1.PageObjects
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public static string StartUrl { get; } = "http://demo.opencart.com/";
        public static IWebDriver startBrowser(Browsers Driver)
        {
            var driver = WebDrivers.MakeDriver(Driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(StartUrl);
            return driver;
        }


    }
}
