using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using EcommerceTests.Core;
using log4net.Repository.Hierarchy;

namespace EcommerceTests.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        private readonly WebDriverWait _wait;
        private readonly WebDriverWait _shortWait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _shortWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(20));

        }
    
        protected void WaitForElementToAppear(By locator)
        {
            LogHelper.Info($"Waiting for element to disappear: {locator}");
            _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected void WaitForElementToHaveText(By locator, string text)
        {
            LogHelper.Info($"Waiting for element to have text '{text}': {locator}");
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }    
    }
}