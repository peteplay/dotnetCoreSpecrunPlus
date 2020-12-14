using TechTalk.SpecFlow;
using WebApp.Pages;

namespace WebApp.Steps
{
    [Binding]
    public sealed class TransferFundsStepDefinition
    {
        private TransferFundsPage transferFundsPage = new TransferFundsPage();

        [When(@"I select a From Account (.*)")]
        public void WhenISelectAFromAccount(int fromAccount)
        {
            transferFundsPage.SelectFromAccount(fromAccount);
        }

        [When(@"I select a To Account (.*)")]
        public void WhenISelectAToAccount(int toAccount)
        {
            transferFundsPage.SelectToAccount(toAccount);
        }

        [When(@"I enter an Amount (.*)")]
        public void WhenIEnterAnAmount(string amount)
        {
            transferFundsPage.EnterAmount(amount);
        }

        [When(@"I type a description (.*)")]
        public void WhenITypeADescription(string description)
        {
            transferFundsPage.EnterDescription(description);
        }

        [When(@"I click the Continue button")]
        public void WhenIClickTheContinueButton()
        {
            transferFundsPage.ClickContinueButton();
        }

        [Then(@"the verify screen is displayed")]
        public void ThenTheScreenIsDisplayed()
        {
            transferFundsPage.VerifyTitle();
            transferFundsPage.VerifyInstruction();
        }

        [When(@"I click the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            transferFundsPage.ClickSubmit();
        }

        [Then(@"a success message is displayed")]
        public void ThenASuccessMessageIsDisplayed()
        {
            transferFundsPage.VerifySuccessMessage();
        }

        //[When(@"I logout")]
        //public void WhenILogout()
        //{
        //    transferFundsPage.ClickUsername();
        //    transferFundsPage.ClickLogout();
        //}




    }
}
