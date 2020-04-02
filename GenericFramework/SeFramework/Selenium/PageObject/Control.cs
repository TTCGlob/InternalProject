using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.Selenium.PageObject
{
    [AttributeUsage(AttributeTargets.Field)]
    public class Control : Attribute
    {
        public Control(string byType, string byParam)
        {
            MethodInfo method = typeof(By).GetMethod(byType);
            ControlId = (By)(method.Invoke(null, new object[] { byParam }));
        }

        public By ControlId { get; }
    }
}
