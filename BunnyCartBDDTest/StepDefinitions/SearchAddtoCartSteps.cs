using BunnyCartBDDTest.Hooks;
using BunnyCartBDDTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Security.Cryptography;
using TechTalk.SpecFlow;

namespace BunnyCartBDDTest.StepDefinitions
{
    [Binding]
    internal class SearchAddtoCartSteps : CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;

        [Given(@"User will be on Homepage")]
        public void GivenUserWillBeOnHomepage()
        {
            driver.Url = "https://www.bunnycart.com/";
            driver.Manage().Window.Maximize();
        }

        [When(@"User will type the '([^']*)' in the searchbox")]
        public void WhenUserWillTypeTheInTheSearchbox(string searchtext)
        {
            IWebElement? searchInput = driver?.FindElement(By.Id("search"));
            searchInput?.SendKeys(searchtext);
            searchInput?.SendKeys(Keys.Enter);
        }

        //[When(@"User clicks on Search button")]
        //public void WhenUserClicksOnSearchButton()
        //{
        //    IWebElement? searchbutton = driver?.FindElement(By.XPath("//button[@title='Search']"));
        //    searchbutton.Click();
        //}

        [Then(@"Search Results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            TakeScreenshot(driver);
            try
            {
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test Passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }
        }

        //[Given(@"Search page is loaded")]
        //public void GivenSearchPageIsLoaded()
        //{
        //    driver.Url = "https://www.bunnycart.com/catalogsearch/result/?q=water";
        //}

        [When(@"User selects a '([^']*)'")]
        public void WhenUserSelectsA(string pId)
        {
            driver.FindElement(By.XPath("(//div[@data-container='product-grid'])[" + pId + "]")).Click();
        }

        [Then(@"Product page '([^']*)' is loaded")]
        public void ThenProductPageIsLoaded(string searchtext)
        {
            TakeScreenshot(driver);
            try
            {
                Assert.That(driver.Title, Does.Contain(searchtext));
                LogTestResult("Search Test", "Search Test Passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }
        }
        [When(@"User select the quantity of the product")]
        public void WhenUserSelectTheQuantityOfTheProduct()
        {
            driver.FindElement(By.ClassName("qty-inc")).Click();
            Thread.Sleep(3000);
        }

        [When(@"User Clicks the Add to Cart Button")]
        public void WhenUserClicksTheAddToCartButton()
        {
            driver.FindElement(By.Id("product-addtocart-button")).Click();
            Thread.Sleep(3000);
        }

        [Then(@"Product '([^']*)' added to cart")]
        public void ThenProductAddedToCart(string searchtext)
        {
            driver.FindElement(By.XPath("//a[contains(@class,'showcart')]")).Click();
            Thread.Sleep(10000);
            Assert.That(driver.FindElement(By.XPath("//a[contains(text(),'Water')]")).Text, Does.Contain(searchtext));
        }

    }
}
