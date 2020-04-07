using FluentAssertions;
using SeFramework.Context.General;
using SeFramework.Core;
using SeFramework.PageObject;
using TechTalk.SpecFlow;

namespace SeFramework.StepDefinition
{
    [Binding]
	public sealed class TricentisWebShop
	{
        private readonly ExecutionContext executionContext;
        private BaseObject page;
        public TricentisWebShop(ExecutionContext executionContext)
        {
            this.executionContext = executionContext;
        }

        #region Given
        [Given(@"I navigate to to the webshop")]
        public void GivenINavigateToToTheWebshop()
        {
            executionContext.Driver.Navigate().GoToUrl(executionContext.ConfigReader.Url);
            page = TopLinks.GetPage(executionContext.Driver);
        }

        [Given(@"I click the log in link")]
        public void GivenIClickTheLogInLink()
        {
            var links = page as TopLinks;
            page.WithControl(TopLinks.Controls.LogIn);
            page.Click();
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


        #endregion

        #region Then

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            var page = TopLinks.GetPage(executionContext.Driver);
            var username = executionContext.ConfigReader.Username;
            page.WithControl(TopLinks.Controls.Account).GetText().Should().Be(username);
        }
        #endregion
    }
}
