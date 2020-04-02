using OpenQA.Selenium;
using SeFramework.Core;

namespace SeFramework.PageObject
{
    public class TopLinks : BaseObject
    {
        private static TopLinks _instance = null;
        private TopLinks(IWebDriver driver) : base(driver) { }
        protected override string Title => "Demo Web Shop";
        public static TopLinks _(IWebDriver driver)
        {
            return _instance != null && driver.Equals(_instance.Driver) ? _instance : (_instance = new TopLinks(driver));
        }

        public enum Controls
        {
            [Control("LinkText", "Register")]
            Register,
            [Control("LinkText", "Log in")]
            LogIn,
            ShoppingCart,
            [Control("PartialLinkText", "Wishlist")]
            Wishlist
        };
    }
}
