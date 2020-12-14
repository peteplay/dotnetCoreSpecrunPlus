using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using OpenQA.Selenium;
using WebApp.Drivers;

namespace WebApp.Pages
{
    class FeedbackPage : Drivers.DriverHelper
    {
        IWebElement txtName = Driver.FindElement(By.Id("name"));
        IWebElement txtEmail = Driver.FindElement(By.Id("email"));
        IWebElement txtSubject = Driver.FindElement(By.Id("subject"));
        IWebElement txtComment = Driver.FindElement(By.Id("comment"));
        IWebElement btnSendMessage = Driver.FindElement(By.XPath("//input[@type='submit']"));
        IWebElement msgFeedbackHeader = Driver.FindElement(By.Id("feedback-title"), 10);
        IWebElement msgFeedbackText = Driver.FindElement(By.ClassName("offset3"), 10);

        public void FillFeedbackForm(string name, string email, string subject, string comment)
        {
            txtName.SendKeys(name);
            txtEmail.SendKeys(email);
            txtSubject.SendKeys(email);
            txtComment.SendKeys(comment);
        }

        public void ClickSendMessageButton() => btnSendMessage.Click();
        public void VerifyFeedbackTitle() => msgFeedbackHeader.Text.Should().Contain("Feedback");
        public void VerifyFeedbackMessage() => msgFeedbackText.Text.Should().Contain("Thank you for your comments");
    }
}
