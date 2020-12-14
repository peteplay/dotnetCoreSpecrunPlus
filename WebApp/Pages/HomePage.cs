using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using WebApp.Drivers;

namespace WebApp.Pages
{
    class HomePage : Drivers.DriverHelper
    {
        IWebElement lnkLogin => Driver.FindElement(By.Id("signin_button"), 10);
        IWebElement lnkAccountSummary => Driver.FindElement(By.Id("account_summary_tab"), 10);
        //IWebElement lnkFeedback => Driver.FindElement(By.XPath("//li[@id='feedback']"));
        IWebElement lnkFeedback => Driver.FindElement(By.Id("feedback"), 10);

        public LoginPage ClickLogin()
        {
            lnkLogin.Click();
            return new LoginPage();
        }
            
        public bool isAccountSummaryTabDisplayed() => lnkAccountSummary.Displayed;
        public bool IsSignInButtonDisplayed() => lnkLogin.Displayed;

        public void NavigateToFeedbackPage()
        {
            lnkFeedback.Click();
        }
    }
}
