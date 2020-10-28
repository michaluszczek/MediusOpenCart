using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace OpenQA.Selenium
{
    internal static class WebDrivers
    {
        public static IWebDriver MakeDriver(Browsers browser)
        {
            switch(browser)
            {
                case Browsers.Chrome:
                    return new ChromeDriver();
                case Browsers.Firefox:
                    return new FirefoxDriver();                
                default:
                    throw new ArgumentOutOfRangeException(nameof(Browsers), browser, null);
            }
        }
    }    
}

  