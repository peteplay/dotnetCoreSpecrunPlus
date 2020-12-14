using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApp.DataTables;
using WebApp.Pages;

namespace WebApp.Steps
{
    [Binding]
    public sealed class FeedbackStepDefinition
    {
        private FeedbackPage feedbackPage = new FeedbackPage();

        [When(@"I enter the following data into the feedback form")]
        public void WhenIEnterTheFollowingDataIntoTheFeedbackForm(Table table)
        {
            var feedbackData = table.CreateInstance<FeedbackData>();
            feedbackPage.FillFeedbackForm(feedbackData.Name, feedbackData.EmailAddress, feedbackData.Subject, feedbackData.Question);

            //dynamic data = table.CreateDynamicInstance();
            //feedbackPage.FillFeedbackForm((string)data.Name, (string)data.EmailAddress, (string)data.Subject, (string)data.Question);
        }

        [When(@"I click the Send Message button")]
        public void WhenIClickTheSendMessageButton()
        {
            FeedbackPage feedbackPage = new FeedbackPage();
            feedbackPage.ClickSendMessageButton();
        }

        [Then(@"an acknowledgement screen and text are displayed")]
        public void ThenAnAcknowledgementScreenAndTextAreDisplayed()
        {
            FeedbackAckPage feedbackAckPage = new FeedbackAckPage();
            feedbackAckPage.VerifyFeedbackTitle();
            feedbackAckPage.VerifyFeedbackMessage();
        }




    }
}
