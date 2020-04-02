using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.Common
{
    public class ExecutionContext
    {
        public int Test { get; set; }
        public IWebDriver Driver { get; set; }
    }
}
