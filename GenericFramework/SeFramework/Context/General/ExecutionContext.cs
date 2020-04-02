using OpenQA.Selenium;

namespace SeFramework.Context.General
{
    public class ExecutionContext
    {
        public int Test { get; set; }
        public IWebDriver Driver { get; set; }
    }
}
