using System.Globalization;
using OpenQA.Selenium;
using EcommerceTests.Core;

namespace EcommerceTests.PageObjects
{
    public class ProductsPage : BasePage
    {
        private List<IWebElement> ProductsNamesList;
        private List<IWebElement> ProductsFavoriteButtonsList;
        private List<IWebElement> ProductsPricesList;

        private IWebElement SortDropdown => Driver.FindElement(By.XPath("//button[@data-slot = 'popover-trigger']"));
        private static By ProductPrices => By.XPath("//div[contains(@class, 'flex flex')]/div[contains(@class, 'flex')]/span"); 
        private static By DropDownOptionLowToHigh => By.XPath("/html/body/div[3]/div/div/div[2]/div/div/div/div[3]");

        private static By ProductNames => By.XPath("//div[contains(@class, 'flex flex')]/a[contains(@class, 'text-lg')]");
        private static By AddToFavoritesButtons => By.XPath("//div[contains(@class, 'flex flex')]//button[@class = ' cursor-pointer']");

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public ProductsPage() : base(DriverManager.Driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {            
        }

        public ProductsPage InitializeProducts()
        {
            LogHelper.Info($"Creating lists of ProductNames, FavoritesButtons, and Prices");
            ProductsNamesList = Driver.FindElements(ProductNames).ToList();
            ProductsFavoriteButtonsList = Driver.FindElements(AddToFavoritesButtons).ToList();
            ProductsPricesList = Driver.FindElements(ProductPrices).ToList();
            return this;
        }

        public ProductsPage SelectSortOption(string option)
        {
            SortDropdown.Click();
            if (option == "Price: Low to High")
            {
                LogHelper.Info($"Selecting option 'Price: Low to High' to search");
                WaitForElementToAppear(DropDownOptionLowToHigh);
                Driver.FindElement(DropDownOptionLowToHigh).Click();
          
                WaitForElementToHaveText(By
                    .XPath("//div[contains(@class, 'flex flex')][1]/div[contains(@class, 'flex')]/span")
                    ,"45.00");
            }
            return this;
        }

        public List<double> GetProductPrices()
        {
            LogHelper.Info($"converting string to double");
            return ProductsPricesList.Select(x => double.Parse(x.Text.Replace("$", ""), CultureInfo.InvariantCulture)).ToList();
        }

        public ProductsPage ClickFavoriteButton(int index)
        {
            if (index < 0 || index >= ProductsFavoriteButtonsList.Count)
            {
#pragma warning disable S112 // General or reserved exceptions should never be thrown
                throw new IndexOutOfRangeException();
#pragma warning restore S112 // General or reserved exceptions should never be thrown
            }
            else
            { 
                ProductsFavoriteButtonsList[index].Click();
                LogHelper.Info($"Selecting favorite product");
            }
            return this;
        }

        public string GetProductName(int index)
        { 
            if (index < 0 || index >= ProductsNamesList.Count)
            {
#pragma warning disable S112 // General or reserved exceptions should never be thrown
                throw new IndexOutOfRangeException();
#pragma warning restore S112 // General or reserved exceptions should never be thrown
            }
            else
            {
                LogHelper.Info($"Returning the name of the product");
                return ProductsNamesList[index].Text;
            }
        }

        public FavoritesPage GoToFavoritesPage() 
        {
            Driver.FindElement(By.XPath("//button[contains(@id,'radix')]")).Click();
            Driver.FindElement(By.XPath("//*[contains(@id,'radix')]/div[@role = 'group']/div")).Click();

            return new FavoritesPage();

        }
    }
}