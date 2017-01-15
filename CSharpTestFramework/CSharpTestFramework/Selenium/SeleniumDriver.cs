using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTestFramework.Selenium
{
    class SeleniumDriver
    {

        public IWebDriver InitializeChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("test-type");
            options.AddArguments("--disable-extensions");
            options.AddArguments("no-sandbox");
            return setDriverDefaults(new ChromeDriver(options));
        }

        public IWebDriver InitializeChromeDriver(string endpoint)
        {
            IWebDriver driver = InitializeChromeDriver();
            driver.Navigate().GoToUrl(endpoint);
            return driver;
        }

        public PhantomJSDriver InitializePhantomJsDriver()
        {
            return new PhantomJSDriver();
        }

        public FirefoxDriver InitializeFirefoxDriver()
        {
            return new FirefoxDriver();
        }

        private IWebDriver setDriverDefaults(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 768);
            return driver;
        }
    }
}
