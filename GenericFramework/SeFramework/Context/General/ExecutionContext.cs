using OpenQA.Selenium;
using SeFramework.Config;

namespace SeFramework.Context.General
{
    public class ExecutionContext
    {
        public ConfigReader ConfigReader { get; internal set; }
        public IWebDriver Driver { get; set; }
    }
}
