using BoDi;
using OpenQA.Selenium.Firefox;
using SeFramework.Context.General;
using System;
using TechTalk.SpecFlow;

namespace SeFramework.Hooks.GeneralHook
{
    [Binding]
    class SpecFlowHooks
    {
        private readonly ExecutionContext executionContext;
        public SpecFlowHooks(IObjectContainer container)
        {
            executionContext = new ExecutionContext()
            {
                ConfigReader = InitialisationActions.GetConfigReader()
            };
            container.RegisterInstanceAs(executionContext);
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
            executionContext.Driver = InitialisationActions.InitialiseDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            executionContext.Driver?.Close();
            executionContext.Driver?.Quit();
            executionContext.Driver?.Dispose();
            executionContext.Driver = null;
        }

    }
}
