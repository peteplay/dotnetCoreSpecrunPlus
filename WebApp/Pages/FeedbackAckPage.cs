using FluentAssertions;
using OpenQA.Selenium;
using WebApp.Drivers;

namespace WebApp.Pages
{
    class FeedbackAckPage : Drivers.DriverHelper
    {
        IWebElement msgFeedbackHeader = Driver.FindElement(By.Id("feedback-title"), 10);
        IWebElement msgFeedbackText = Driver.FindElement(By.ClassName("offset3"), 10);

        public void VerifyFeedbackTitle() => msgFeedbackHeader.Text.Should().Contain("Feedback");
        public void VerifyFeedbackMessage() => msgFeedbackText.Text.Should().Contain("Thank you for your comments");
    }
}
