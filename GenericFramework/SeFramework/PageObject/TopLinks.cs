using OpenQA.Selenium;
using SeFramework.Core;

namespace SeFramework.PageObject
{
    public class TopLinks : BaseObject
    {
        private static TopLinks _instance = null;
        private TopLinks(IWebDriver driver) : base(driver) { }
        protected override string Title => "Demo Web Shop";
        public static TopLinks GetPage(IWebDriver driver) =>
            _instance != null && driver.Equals(_instance.Driver)
            ? _instance
            : (_instance = new TopLinks(driver));

        public enum Controls
        {
            [Control(ByType.LinkText, "Register")]
            Register,
            [Control(ByType.LinkText, "Log in")]
            LogIn,
            [Control(ByType.PartialLinkText, "Shopping cart")]
            ShoppingCart,
            [Control(ByType.PartialLinkText, "Wishlist")]
            Wishlist,
            [Control(ByType.ClassName, "account")]
            Account
        };
    }
}
