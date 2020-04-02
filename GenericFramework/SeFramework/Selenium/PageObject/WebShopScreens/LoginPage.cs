using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeFramework.Selenium.PageObject.WebShopScreens
{
    public class LoginPage : BaseObject
    {
        private static LoginPage _instance = null;
        public LoginPage(IWebDriver driver) : base(driver) { }
        protected override string Title => "Login";
        public static LoginPage _(IWebDriver driver)
        {
            return _instance != null && driver.Equals(_instance.Driver) ? _instance : (_instance = new LoginPage(driver));
        }

        #region Controls
        public enum NewCustomer
        {
            [Control("XPath", "//input[@value='Register']")]
            Register
        };

        public enum ReturningCustomer
        {
            [Control("ClassName", "validation-summary-errors")]
            IncorrectLoginMessage,
            [Control("ClassName", "email")]
            Email,
            [Control("XPath", "//span[@for='Email']")]
            WrongEmailMessage,
            [Control("ClassName", "password")]
            Password,
            [Control("XPath", "//input[@id='RememberMe']")]
            RememberMe,
            [Control("XPath", "//input[@value='Log in']")]
            LogIn
        };
        #endregion
    }
}
