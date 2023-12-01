using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkedInTests.StepDefinitions
{
    [Binding]
    public class LoginStep
    {
        public static IWebDriver? driver;
        private IWebElement? passwordInput;
        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();

        }
        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
        }

        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver.Url = "https://linkedin.com";
        }

        [When(@"User will enter username '(.*)'")]
        public void WhenUserWillEnterUsername(string un)
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            IWebElement? emailInput = fluentWait.Until(d => d?.FindElement(By.Id("session_key")));
            emailInput?.SendKeys(un);

        }

        [When(@"User will enter password '(.*)'")]
        public void WhenUserWillEnterPassword(string pwd)
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
             passwordInput = fluentWait.Until(d => d?.FindElement(By.Id("session_password")));
            passwordInput?.SendKeys(pwd);
            Console.WriteLine(passwordInput?.GetAttribute("value"));

        }

        [When(@"User will click on Login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js?.ExecuteScript("arguments[0].scrollIntoView(true);", driver?.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(3000);
            js?.ExecuteScript("arguments[0].click();", driver?.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will be redirected to Homepage")]
        public void ThenUserWillBeRedirectedToHomepage()
        {
            Assert.That(driver.Title.Contains("Log In"));
        }

        [Then(@"Error Message for Password Length should be thrown")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {
            IWebElement? alertPara = driver?.FindElement(By.XPath("//p[@for='session_password']"));
            string? alerttext = alertPara?.Text;
            Assert.That(alertPara.Text.Contains("6 characters"));
        }

        [When(@"User will click on Show Link in the password textbox")]
        public void WhenUserWillClickOnShowLinkInThePasswordTextbox()
        {
            IWebElement? showButton = driver?.FindElement(By.XPath("//button[text()='Show']"));
            showButton?.Click();
        }

        [Then(@"Password characters should shown")]
        public void ThenPasswordCharactersShouldShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("text"));
        }

        [When(@"User will click on Hide Link in the password textbox")]
        public void WhenUserWillClickOnHideLinkInThePasswordTextbox()
        {
            IWebElement? hideButton = driver?.FindElement(By.XPath("//button[text()='Hide']"));
            hideButton?.Click();
        }

        [Then(@"Password characters should not be shown")]
        public void ThenPasswordCharactersShouldNotBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("password"));
        }

    }
}
