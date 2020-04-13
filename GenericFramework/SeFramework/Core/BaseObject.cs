using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Linq;
using SeFramework.ExtensionResources;
using System.Collections.Generic;

namespace SeFramework.Core
{
    public abstract class BaseObject
    {
        protected IWebElement _currentElement = null;

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
        public IWebElement Parent { get; protected set; } = null;

        // TODO: need to add assertions ???
        public BaseObject WithControl<TT>(TT givenControl, double waitTimeout = 10.0)
        {
            // Make sure wa are on the proper screen
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(Title));
            _currentElement = null;

            Type controlsInstance = givenControl.GetType();
            if (!Attribute.IsDefined(controlsInstance, typeof(ChildControl))) Parent = null;

            var parentIds = controlsInstance.GetCustomAttributes<Parent>(true)
                .Select(p => p.ControlId);

            MemberInfo member = controlsInstance.GetMember(givenControl.ToString()).Single();
            
            parentIds = parentIds.Concat(member.GetCustomAttributes<Parent>().Select(p => p.ControlId));
            var control = member.GetCustomAttribute<Control>(true);
            
            foreach (var parentBy in parentIds)
            {
                Parent = Driver.WaitThenFindElement(Parent, parentBy, TimeSpan.FromSeconds(5));
            }

            _currentElement = Driver.WaitThenFindElement(Parent, control.ControlId, TimeSpan.FromSeconds(5));
            Parent = null;
            return this;
        }

        #region Actions
        public BaseObject testText(string text)
        {
            Console.WriteLine("{0} ", text);
            return this;
        }

        public BaseObject EnterText(string text)
        {
            _currentElement.SendKeys(text);
            return this;
        }
        public string GetText()
        {
            return _currentElement.Text;
        }

        public bool IsDisplayed<TT>(TT item, double timeout = 3.0)
        {
            try
            {
                WithControl(item, timeout);
                return _currentElement.Displayed;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is WebDriverTimeoutException)
                    return false;
                throw ex;
            }
        }

        public IWebElement GetControl()
        {
            return _currentElement;
        }

        public BaseObject Click()
        {
            _currentElement.Click();
            return this;
        }

        public BaseObject Select(string item)
        {
            SelectElement dropdown = new SelectElement(_currentElement);
            dropdown.SelectByText(item);
            return this;
        }

        public virtual BaseObject SelectMenu<TT>(params TT[] menuItems)
        {
            foreach (TT menuItem in menuItems)
            {
                WithControl(menuItem).Click();
            }
            return this;
        }
        #endregion
    };
}