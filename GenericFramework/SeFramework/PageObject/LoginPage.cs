using OpenQA.Selenium;
using SeFramework.Core;

namespace SeFramework.PageObject
{
    public class LoginPage : BaseObject
    {
        private static LoginPage _instance = null;
        public LoginPage(IWebDriver driver) : base(driver) { }
        protected override string Title => "Login";
        public static LoginPage GetPage(IWebDriver driver)
        {
            return _instance != null && driver.Equals(_instance.Driver) ? _instance : (_instance = new LoginPage(driver));
        }

        #region Controls
        public enum NewCustomer
        {
            [Control(ByType.XPath, "//input[@value='Register']")]
            Register
        };

        public enum ReturningCustomer
        {
            [Control(ByType.ClassName, "validation-summary-errors")]
            IncorrectLoginMessage,
            [Control(ByType.Id, "Email")]
            Email,
            [Control(ByType.XPath, "//span[@for='Email']")]
            WrongEmailMessage,
            [Control(ByType.Id, "Password")]
            Password,
            [Control(ByType.Id, "RememberMe")]
            RememberMe,
            [Control(ByType.XPath, "//input[@value='Log in']")]
            LogIn
        };
        #endregion
    }
}
