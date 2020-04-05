﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Linq;
using SeFramework.ExtensionResources;

namespace SeFramework.Core
{
    public abstract class BaseObject
    {
        private IWebElement _currentElement = null;

        public BaseObject(IWebDriver driver, By iFrameId = null)
        {
            Driver = driver;
            Driver.SwitchTo().DefaultContent();
            if (iFrameId != null)
            {
                IWebElement iFrameElement = Driver.FindElement(iFrameId);
                Driver.SwitchTo().Frame(iFrameElement);
            }
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        protected abstract string Title { get; }
        public IWebDriver Driver { get; set; } = null;

        // TODO: need to add assertions ???
        public BaseObject withControlE<TT>(TT givenControl, double waitTimeout = 10.0)
        {
            // Make sure wa are on the proper screen
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(Title));

            _currentElement = null;
            Type controlsInstance = givenControl.GetType();
            MemberInfo[] members = controlsInstance.GetMember(givenControl.ToString());
            //if (members.Length == 1)
            //{
            //    foreach (object attribute in members[0].GetCustomAttributes(true))
            //    {
            //        if (attribute is Control)
            //        {
            //            Control control = attribute as Control;
            //            //_currentElement = driver.FindElement(control.ControlId);
            //            _currentElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(control.ControlId));
            //            break;
            //        }
            //    }
            //}

            var member = members.Single();
            var control = (Control)member.GetCustomAttributes(true).Single(attribute => attribute is Control);
            _currentElement = Driver.WaitThenFindElement(control.ControlId, TimeSpan.FromSeconds(10));
            return this;
        }

        #region Actions
        public BaseObject testText(string text)
        {
            Console.WriteLine("{0} ", text);
            return this;
        }

        public BaseObject enterText(string text)
        {
            _currentElement.SendKeys(text);
            return this;
        }
        public string getText()
        {
            return _currentElement.Text;
        }

        public IWebElement getControl()
        {
            return _currentElement;
        }

        public BaseObject click()
        {
            _currentElement.Click();
            return this;
        }

        public BaseObject select(string item)
        {
            SelectElement dropdown = new SelectElement(_currentElement);
            dropdown.SelectByText(item);
            return this;
        }

        public virtual BaseObject selectMenu<TT>(params TT[] menuItems)
        {
            foreach (TT menuItem in menuItems)
            {
                withControlE(menuItem).click();
            }
            return this;
        }
        #endregion
    };
}
