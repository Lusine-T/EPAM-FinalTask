using EcommerceTests.Core;
using OpenQA.Selenium;

namespace EcommerceTests.PageObjects
{
    public class LoginPage : BasePage
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public LoginPage() : base(DriverManager.Driver) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        private IWebElement EmailField => Driver.FindElement(By.XPath("//input[@id='email']"));
        private IWebElement PasswordField => Driver.FindElement(By.XPath("//input[@id='password']"));
        private IWebElement LoginButton => Driver.FindElement(By.XPath("//button[@type='submit']"));
        
        private IWebElement UsernameError;
        private IWebElement PasswordError;
        

        public void InitializeUsernameError()
        {
            try
            {
                this.UsernameError = Driver.FindElement(By.XPath("//input[@id='email']/parent::div/following-sibling::p"));
            }
            catch (Exception)
            {
                LogHelper.Info($"Cannot initialize UsernameError field");                
            }
        }
        public void InitializePasswordError()
        {
            try
            {
                this.PasswordError = Driver.FindElement(By.XPath("//input[@id='password']/parent::div/following-sibling::p"));
            }
            catch (Exception)
            {
                LogHelper.Info($"Cannot initialize PasswordError field");
            }
        }

        public ProductsPage Login(string email, string password)
        {
            LogHelper.Info($"Login with email: {email}");

            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            LoginButton.Click();
            return new ProductsPage();
        }

        public string GetUsernameError()
        {
            if (UsernameError is not null && UsernameError.Displayed)
                return UsernameError.Text;
             
            return string.Empty;
        }
        public string GetPasswordError()
        {
            if (PasswordError is not null && PasswordError.Displayed)
                return PasswordError.Text;

            return string.Empty;
        }
    }
}