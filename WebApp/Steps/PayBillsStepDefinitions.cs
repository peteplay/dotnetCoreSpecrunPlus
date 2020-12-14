using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApp.Pages;

namespace WebApp.Steps
{
    [Binding]
    public sealed class PayBillsStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private PayBillsPage payBillsPage = new PayBillsPage();
        //private AccountsPage accountsPage = new AccountsPage();

        public PayBillsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"the Pay Saved Payee tab is active")]
        public void WhenThePaySavedPayeeTabIsActive()
        {
            payBillsPage.IsPaySavedPayeeTabActive();
        }

        [When(@"I make a payment to a saved payee")]
        public void WhenIMakeAPaymentToASavedPayee(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            payBillsPage.FillPaymentForm((string)data.Payee, (string)data.Account, (int)data.Amount, (string)data.Date, (string)data.Description);
        }

        [Then(@"a payment success message is displayed")]
        public void ThenAPaymentSuccessMessageIsDisplayed()
        {
            PayBillsAckPage payBillsAckPage = new PayBillsAckPage();
            payBillsAckPage.VerifySuccessMessage();
        }



    }
}
