using NUnit.Framework;
using SeFramework.Context.General;
using SeFramework.Core;
using SeFramework.PageObject;
using System;
using TechTalk.SpecFlow;

namespace SeFramework.StepDefinition
{

    [Binding]
    class _2UnlimitedBindings
    {
        private readonly ExecutionContext _ec;
        private BaseObject _currentScreen;

        public _2UnlimitedBindings(ExecutionContext ec)
        {
            _ec = ec;
        }

        [Given(@"Webpage (.*) is loaded")]
        [Given(@"Go to (.*)")]
        public void GivenGoURL(string url)
        {
            _ec.Driver.Url = url;
        }

        [Given(@"Switch to (.*) page")]
        public void GivenSwitchToPage(string pageName)
        {
            _currentScreen = TopLinks._(_ec.Driver);
            TopLinks.Controls control = TopLinks.Controls.LogIn;

            switch (pageName)
            {
                case "Log in":
                    control = TopLinks.Controls.LogIn;
                    break;
                case "Register":
                    control = TopLinks.Controls.Register;
                    break;
                case "Shopping Cart":
                    control = TopLinks.Controls.ShoppingCart;
                    break;
                case "Wishlist":
                    control = TopLinks.Controls.Wishlist;
                    break;
                default:
                    Assert.Fail($"Unknown page name: {pageName}");
                    break;
            }
            _currentScreen.withControlE(control).click();
        }


        [When(@"I enter (.*) in Email field")]
        public void WhenIEnterInEmailField(string emailValue)
        {
            _currentScreen = LoginPage._(_ec.Driver);
            var ctrl = _currentScreen.withControlE(LoginPage.ReturningCustomer.Email);
            ctrl.click();
            ctrl.enterText(emailValue);
        }

        [When(@"Change the focus")]
        public void WhenChangeTheFocus()
        {
            _currentScreen.withControlE(LoginPage.ReturningCustomer.Password).click();
        }

        [Then(@"I can see the error message")]
        public void ThenICanSeeTheErrorMessage()
        {
            var errMessage = _currentScreen.withControlE(LoginPage.ReturningCustomer.WrongEmailMessage);
            Assert.IsFalse(string.IsNullOrEmpty(errMessage.getText()), "Error message is empty");
        }
    }

    public class ScreenUtils
    {
        public static BaseObject GetScreen(Type screenType)
        {
            //BaseObject screen = screenType.InvokeMember("_", System.Reflection.BindingFlags.Static, EqualityComparer.)
            return null;
        }
    }
}
