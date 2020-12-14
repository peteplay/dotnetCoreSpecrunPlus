using TechTalk.SpecFlow;
using WebApp.Pages;

namespace WebApp.Steps
{
    [Binding]
    public sealed class NavigationSteps
    {

        private HomePage homePage = new HomePage();

        [Given(@"I have navigated to the Feedback page")]
        public void GivenIHaveNavigatedToTheFeedbackPage()
        {
            homePage.NavigateToFeedbackPage();
        }


    }
}
