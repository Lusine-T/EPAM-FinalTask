using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace EcommerceTests.Core;

public class DriverManager
{
    private DriverManager() { }

    private static ThreadLocal<IWebDriver?> _driver = new();

    public static IWebDriver Driver
    {
        get
        {
            if (_driver.Value == null)
            {
                throw new InvalidOperationException("WebDriver has not been initialized. Call InitDriver first.");
            }
            return _driver.Value;
        }
    }

    public static void InitDriver(string browser)
    {
        if (_driver.Value != null)
            return;
       
        switch (browser.ToLower())
        {
            case "chrome":
                _driver.Value = new ChromeDriver();
                break;
            case "edge":
                _driver.Value = new EdgeDriver();
                break;
            default:
                throw new InvalidOperationException($"Browser '{browser}' not supported");
        }


        _driver.Value.Manage().Window.Maximize();
        _driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 
    }

    public static void QuitDriver()
    {
        _driver.Value?.Quit();
        _driver.Value = null;
    }
}