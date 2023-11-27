using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProj.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        public IWebDriver driver;
        [BeforeScenario]
        public void InitializeBrowser()
        {
            driver = new ChromeDriver();
            
        }
        [AfterScenario]
        public void CleanupBrowser()
        {
            driver?.Quit();
        }
        [Given(@"Google Homepage should be loaded")]
        public void GivenGoogleHomepageShouldBeLoaded()
        {
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }

        [When(@"Type ""(.*)"" in search text box")]
        public void WhenTypeInSearchTextBox(string searchText)
        {
            IWebElement searchInput = driver.FindElement(By.Id("APjFqb"));
            searchInput.SendKeys(searchText);
        }

        [When(@"Click on the Google Search Button")]
        public void WhenClickOnTheGoogleSearchButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement? gsb = fluentWait.Until(d =>
            {
                IWebElement? searchbutton = driver.FindElement(By.ClassName("gNO89b"));
                return searchbutton.Displayed ? searchbutton : null;
            });
            if(gsb != null)
            {
                gsb.Click();
            }
        }

        [Then(@"the results should be displayed on the next page with title ""([^""]*)""")]
        public void ThenTheResultsShouldBeDisplayedOnTheNextPageWithTitle(string title)
        {
            Assert.That(driver?.Title, Is.EqualTo(title));
        }

        [When(@"Click on the IMFL Button")]
        public void WhenClickOnTheIMFLButton()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement? gsb = fluentWait.Until(d =>
            {
                IWebElement? searchbutton = driver.FindElement(By.Name("btnI"));
                return searchbutton.Displayed ? searchbutton : null;
            });
            if (gsb != null)
            {
                gsb.Click();
            }
        }

        [Then(@"the results should be redirected to a new page with title ""([^""]*)""")]
        public void ThenTheResultsShouldBeRedirectedToANewPageWithTitle(string title)
        {
            Assert.That(driver.Title.Contains(title));
        }

    }
}
