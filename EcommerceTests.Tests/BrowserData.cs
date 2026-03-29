using EcommerceTests.Core;

namespace EcommerceTests.Tests;

public class BrowserData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (var browser in Config.Browsers)
        {
            yield return new object[] { browser };
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}
