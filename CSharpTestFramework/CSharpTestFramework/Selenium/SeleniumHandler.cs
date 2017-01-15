using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSharpTestFramework.Selenium
{
    class SeleniumHandler
    {
        IWebDriver driver;

        public SeleniumHandler(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebDriver GetDriver()
        {
            return driver;
        }

        protected IWebElement FindElement(By el)
        {
            return GetDriver().FindElement(el);
        }

        protected void Click(By el)
        {
            FindElement(el).Click();
        }

        protected void EnterText(By el, string text)
        {
            FindElement(el).SendKeys(text);
        }

        protected void SelectFromDropdown(By el, string text)
        {
            new SelectElement(FindElement(el)).SelectByText(text);
        }

        protected void SelectFromDropdown(By el, int index)
        {
            new SelectElement(FindElement(el)).SelectByIndex(index);
        }

        protected SeleniumHandler WaitForElementVisible(By el, int seconds)
        {
            GetWaitDriver(0, 0, seconds).Until(ExpectedConditions.ElementIsVisible(el));
            return this;
        }

        protected SeleniumHandler WaitForElementClickable(By el, int seconds)
        {
            GetWaitDriver(0, 0, seconds).Until(ExpectedConditions.ElementToBeClickable(el));
            return this;
        }

        protected SeleniumHandler WaitForElementInvisible(By el, int seconds)
        {
            SetImplicitWait(seconds);
            GetWaitDriver(0, 0, seconds).Until(ExpectedConditions.ElementToBeClickable(el));
            SetImplicitWait(10);
            return this;
        }

        public void NavigateToPage(string url)
        {
            GetDriver().Navigate().GoToUrl(url);
        }

        public void RefreshPage()
        {
            GetDriver().Navigate().Refresh();
        }

        private WebDriverWait GetWaitDriver(int hours, int minutes, int seconds)
        {
            return new WebDriverWait(GetDriver(), new System.TimeSpan(hours, minutes, seconds));
        }

        private void SetImplicitWait(int seconds)
        {
            GetDriver().Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }
    }
}
