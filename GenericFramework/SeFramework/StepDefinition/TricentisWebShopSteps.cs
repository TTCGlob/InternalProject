using FluentAssertions;
using SeFramework.Context.General;
using SeFramework.Core;
using SeFramework.PageObject;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SeFramework.StepDefinition
{
    [Binding]
	public sealed class TricentisWebShopSteps
	{
        private readonly ExecutionContext executionContext;
        private BaseObject page;
        public TricentisWebShopSteps(ExecutionContext executionContext)
        {
            this.executionContext = executionContext;
        }

        #region Given
        [Given(@"I navigate to to the webshop")]
        public void GivenINavigateToToTheWebshop()
        {
            executionContext.Driver.Navigate().GoToUrl(executionContext.ConfigReader.Url);
            page = TopLinks.Get(executionContext.Driver);
        }

        [Given(@"I click the log in link")]
        public void GivenIClickTheLogInLink()
        {
            var links = page as TopLinks;
            links.WithControl(TopLinks.Controls.LogIn);
            links.Click();
        }

        [Given(@"I log in to the webshop")]
        public void GivenILogInToTheWebshop()
        {
            GivenINavigateToToTheWebshop();
            GivenIClickTheLogInLink();
            WhenILoginAsTheDefaultUser();
        }
        [Given(@"I navigate to the ""(.*)"" category")]
        public void GivenINavigateToTheCategory(string category)
        {
            var productCategories = ProductCategoryLinks.Get(executionContext.Driver);
            productCategories.WithControl(productCategories[category]).Click();
            page = ProductPage.Get(executionContext.Driver, category);
        }
        #endregion

        #region When

        [When(@"I login as the default user")]
        public void WhenILoginAsTheDefaultUser()
        {
            var username = executionContext.ConfigReader.Username;
            var password = executionContext.ConfigReader.Password;
            var loginPage = LoginPage.GetPage(executionContext.Driver);
            loginPage.WithControl(LoginPage.ReturningCustomer.Email).EnterText(username);
            loginPage.WithControl(LoginPage.ReturningCustomer.Password).EnterText(password);
            loginPage.WithControl(LoginPage.ReturningCustomer.LogIn).Click();
        }
        
        [When(@"I add ""(.*)"" to my cart")]
        public void WhenIAddToMyCart(string product)
        {
            var productPage = page as ProductPage;
            productPage.WithProduct(product)
                       .WithControl(ProductPage.ProductBox.AddToCart)
                       .Click();
        }
        #endregion

        #region Then

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            var page = TopLinks.Get(executionContext.Driver);
            var username = executionContext.ConfigReader.Username;
            page.WithControl(TopLinks.Controls.Account).GetText().Should().Be(username);
        }

        [Then(@"The notification bar should say ""(.*)""")]
        public void ThenTheNotificationBarShouldSay(string message)
        {
            var bar = NotificationBar.Get(executionContext.Driver);
            bar.WithControl(NotificationBar.Controls.Text)
                .GetText().Should().Be(message);
        }


        [Then(@"The shopping cart should indicate it has (.*) items? in it")]
        public void ThenTheShoppingCartShouldIndicateItHasItemInIt(int expected)
        {
            var links = TopLinks.Get(executionContext.Driver);
            var shoppingCartText = links.WithControl(TopLinks.Controls.ShoppingCart).GetText();
            var actual = int.Parse(Regex.Match(shoppingCartText, @"\d+").Value);
            actual.Should().Be(expected, "The shopping cart link should show how many items we added");
        }
        #endregion

        [AfterScenario]
        [Scope(Tag = "cart")]
        public void EmptyCart()
        {
            TopLinks.Get(executionContext.Driver).WithControl(TopLinks.Controls.ShoppingCart).Click();
            var cart = ShoppingCart.Get(executionContext.Driver);
            while (!cart.WithControl(ShoppingCart.Controls.CartEmpty).GetText().Contains("Your Shopping Cart is empty!"))
            {
                cart.WithProduct(0).WithControl(ShoppingCart.ProductControls.RemoveFromCart).Click();
                cart.WithControl(ShoppingCart.Controls.UpdateCart).Click();
            }
        }
    }
}
