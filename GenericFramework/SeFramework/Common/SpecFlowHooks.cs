using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeFramework.Common
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
            try {
                _ec.Driver.Close();
            }
            catch { }
        }

    }
}
