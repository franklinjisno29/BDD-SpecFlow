using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BunnyCartBDDTest.Hooks
{
    [Binding]
    public sealed class AfterHooks
    {

        [AfterFeature]
        public static void CleanUp()
        {
            BeforeHooks.driver?.Quit();
        }

        [AfterScenario]
        public static void NavigateToHomePage()
        {
            BeforeHooks.driver?.Navigate().GoToUrl("https://www.bunnycart.com/");
        }
    }
}