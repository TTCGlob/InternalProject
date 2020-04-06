using OpenQA.Selenium;
using System;
using System.Reflection;


namespace SeFramework.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public class Control : Attribute
    {
        private Control(string byType, string byParam)
        {
            MethodInfo method = typeof(By).GetMethod(byType);
            ControlId = (By)method.Invoke(null, new object[] { byParam });
        }

        public Control(ByType byType, string byParam) : this(byType.ToString(), byParam) { }

        public By ControlId { get; }
    }
}
