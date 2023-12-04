using BunnyCartBDDTest.Hooks;
using BunnyCartBDDTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCartBDDTest.StepDefinitions
{
    [Binding]
    internal class SearchStep : CoreCodes
    {
        
        [Given(@"User will be on Homepage")]
        public void GivenUserWillBeOnHomepage()
        {
            BeforeHooks.driver.Url = "https://www.bunnycart.com/";
            BeforeHooks.driver.Manage().Window.Maximize();
        }

        [When(@"User will type the '([^']*)' in the searchbox")]
        public void WhenUserWillTypeTheInTheSearchbox(string searchtext)
        {
            IWebElement? searchInput = BeforeHooks.driver?.FindElement(By.Id("search"));
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
            TakeScreeshot(BeforeHooks.driver);
            try
            {
                Assert.That(BeforeHooks.driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test Passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }
        }
    }
}
