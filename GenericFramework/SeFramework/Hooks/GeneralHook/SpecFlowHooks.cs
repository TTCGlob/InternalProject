using OpenQA.Selenium.Firefox;
using SeFramework.Context.General;
using System;
using TechTalk.SpecFlow;

namespace SeFramework.Hooks.GeneralHook
{
    [Binding]
    class SpecFlowHooks
    {
        private readonly ExecutionContext _ec;
        public SpecFlowHooks(ExecutionContext ec)
        {
            _ec = ec;
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
        }

        [AfterFeature]
        public static void AfterFeature()
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _ec.Driver = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                _ec.Driver.Close();
            }
            catch { }
        }

    }
}
