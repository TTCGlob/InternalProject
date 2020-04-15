using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SeFramework.Context.General;
using OpenQA.Selenium;
using SeFramework.Core;
using SeFramework.PageObject;

namespace SeFramework.StepDefinition.Stef
{
    [Binding]
    public sealed class TricentisWebShopS
    {
        private readonly ExecutionContext context;
        private BaseObject page;
        public TricentisWebShopS(ExecutionContext context)
        {
            this.context = context;
        }

        //Background: Navigate to url and log in
        [Given(@"I navigated to the DemoWebShop website")]
        public void GivenINavigatedToTheDemoWebShopWebsite()
        {
            context.Driver.Navigate().GoToUrl(context.ConfigReader.Url);
            page = TopLinks.Get(context.Driver);
        }

        [When(@"I click the Log in link")]
        public void WhenIClickTheLogInLink()
        {
            var links = page as TopLinks;
            links.WithControl(TopLinks.Controls.LogIn);
            links.Click();
        }

        [When(@"I submit username and password")]
        public void WhenISubmitUsernameAndPassword()
        {
            var logIn = page as LoginPage;
            LoginPage.GetPage(context.Driver);
            logIn.WithControl(LoginPage.ReturningCustomer.Email).EnterText(context.ConfigReader.Username);
            logIn.WithControl(LoginPage.ReturningCustomer.Password).EnterText(context.ConfigReader.Password);
            logIn.WithControl(LoginPage.ReturningCustomer.LogIn).Click();
        }

        [Then(@"the DetailPage displays")]
        public void ThenTheDetailPageDisplays()
        {
            
        }

    }
}
