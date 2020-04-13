using OpenQA.Selenium;
using SeFramework.Config;
using TechTalk.SpecFlow;

namespace SeFramework.Context.General
{
    public class ExecutionContext
    {
        public ScenarioContext ScenarioContext { get; internal set; }
        public ConfigReader ConfigReader { get; internal set; }
        public IWebDriver Driver { get; set; }
    }
}
