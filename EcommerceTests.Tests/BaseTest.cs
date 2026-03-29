using EcommerceTests.Core;

namespace EcommerceTests.Tests;

public class BaseTest : IDisposable
{

    public static IEnumerable<object[]> Browsers =>
    Config.Browsers.SelectMany(browser => new[]
    {
        new object[] {browser}
    });

    protected static void Setup(string browser)
    {
        LogHelper.Info($"Initializing browser: {browser}");
        DriverManager.InitDriver(browser);
        DriverManager.Driver.Navigate().GoToUrl(Config.BaseUrl);
    }

    public void Dispose()
    {
        LogHelper.Info("Closing browser");
        DriverManager.QuitDriver();
    }
}
