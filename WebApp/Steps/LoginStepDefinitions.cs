using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebApp.Pages;
using FluentAssertions;
using NUnit.Framework;
using System.Configuration;
using System;

namespace WebApp.Steps
{
    [Binding]

    //public class LoginSteps : Drivers.DriverHelper
    public class LoginSteps 

    {
        private HomePage homePage = new HomePage();
        private LoginPage loginPage = new LoginPage();
        private AccountsPage accountsPage = new AccountsPage();


        [Given(@"I have navigated to the homepage")]
        public void GivenIHaveNavigatedToTheHomepage()
        {
            // see hooks
        }

        [When(@"I click the SignIn button")]
        public void WhenIClickTheSignInButton()
        {
            homePage.ClickLogin();
        }

        [When(@"I enter the login details")]
        public void WhenIEnterTheLoginDetails()
        {
            // from Default.srprofile
            var username = Environment.GetEnvironmentVariable("__Username");
            var password = Environment.GetEnvironmentVariable("__Password");

            //loginPage.EnterUserNameAndPassword("username", "password");
            loginPage.EnterUserNameAndPassword(username, password);
            loginPage.ClickSubmit();
        }

        [Given(@"the accounts screen is displayed")]
        public void ThenTheAccountsScreenIsDisplayed()
        {
            Assert.That(accountsPage.isAccountSummaryTabDisplayed, Is.True, "The accounts tab is not displayed");
            accountsPage.assertAccountSummaryTabText();
        }

        [Given(@"the (.*) tab is displayed")]
        public void ThenTheAccountSummaryTabIsDisplayed(string accountSummaryText)
        {
            accountsPage.assertAccountSummaryTabText2(accountSummaryText);
        }

        //[Then(@"the SignIn button is displayed")]
        //public void ThenTheSignInButtonIsDisplayed()
        //{
        //    homePage.IsSignInButtonDisplayed();
        //}




    }
}