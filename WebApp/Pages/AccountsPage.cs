using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using OpenQA.Selenium;
using WebApp.Drivers;

namespace WebApp.Pages
{
    class AccountsPage : Drivers.DriverHelper
    {
        IWebElement tabAccountSummary => Driver.FindElement(By.Id("account_summary_tab"), 10);
        IWebElement tabTransferFunds => Driver.FindElement(By.Id("transfer_funds_tab"));
        IWebElement tabPayBills => Driver.FindElement(By.Id("pay_bills_tab"));

        public bool isAccountSummaryTabDisplayed() => tabAccountSummary.Displayed;
        

        public void assertAccountSummaryTabText()
        {
            tabAccountSummary.Text.Should().Be("Account Summary");
        }

        public void assertAccountSummaryTabText2(string accountSummaryText)
        {
            tabAccountSummary.Text.Should().Be(accountSummaryText);
        }

        public void clickTransferFundsTab() => tabTransferFunds.Click();
        public void ClickPayBillsTab() => tabPayBills.Click();
    }
}
