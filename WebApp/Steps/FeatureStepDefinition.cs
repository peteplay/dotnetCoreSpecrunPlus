using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WebApp.Pages;

namespace WebApp.Steps
{
    [Binding]
    public sealed class FeatureStepDefinition
    {
        private AccountsPage accountsPage = new AccountsPage();
        private TransferFundsPage transferPage = new TransferFundsPage();

        [When(@"I click the Transfer Funds Tab")]
        public void WhenIClickTheTransferFundsTab()
        {
            accountsPage.clickTransferFundsTab();
        }

        [Then(@"the Transfer Money & Make Payments screen is displayed")]
        public void ThenTheTransferMoneyMakePaymentsScreenIsDisplayed()
        {
            transferPage.IsTransferHeaderDisplayed();
        }

        [When(@"I click the pay Bills tab")]
        public void WhenIClickThePayBillsTab()
        {
            accountsPage.ClickPayBillsTab();
        }




    }
}
