using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using WebApp.Drivers;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;

namespace WebApp.Pages
{
    class TransferFundsPage : Drivers.DriverHelper
    {
        IWebElement txtTransferHeader => Driver.FindElement(By.ClassName("board-header"), 10);
        //IWebElement drpFromAccount => Driver.FindElement(By.XPath("//select[@id='tf_fromAccountId']"));
        IWebElement drpFromAccount => Driver.FindElement(By.Id("tf_fromAccountId"), 10);
        IWebElement drpToAccount => Driver.FindElement(By.XPath("//select[@id='tf_toAccountId']"));
        IWebElement txtAmount => Driver.FindElement(By.XPath("//input[@id='tf_amount']"));
        //IWebElement txtAmount => Driver.FindElement(By.Id("tf_amount"));
        //IWebElement txtDescription => Driver.FindElement(By.XPath("//input[@id='tf_description']"));
        IWebElement txtDescription => Driver.FindElement(By.Id("tf_description"));
        IWebElement btnSubmit => Driver.FindElement(By.XPath("//button[@type='submit']"));
        IWebElement txtTitle => Driver.FindElement(By.ClassName("board-header"));
        IWebElement txtBoardInstruction => Driver.FindElement(By.ClassName("board-content"));
        IWebElement txtSuccessMessage => Driver.FindElement(By.ClassName("alert-success"));
        IList<IWebElement> usernameToggle => Driver.FindElements(By.ClassName("dropdown-toggle"));
        IWebElement lnkLogout => Driver.FindElement(By.Id("logout_link"));


        public bool IsTransferHeaderDisplayed() => txtTransferHeader.Displayed;

        public void SelectFromAccount(int fromAccount)
        {
            SelectElement option = new SelectElement(drpFromAccount);
            option.SelectByIndex(fromAccount);
            drpFromAccount.Click();
        }

        public void SelectToAccount(int ToAccount)
        {
            SelectElement option = new SelectElement(drpToAccount);
            option.SelectByIndex(ToAccount);
            drpFromAccount.Click();
        }

        public void EnterAmount(string amount) => txtAmount.SendKeys(amount);
        public void EnterDescription(string description) => txtDescription.SendKeys(description);
        public void ClickContinueButton() => btnSubmit.Click();
        public void VerifyTitle() => txtTitle.Text.Should().Be("Transfer Money & Make Payments - Verify");
        public void VerifyInstruction() => txtBoardInstruction.Text.Should().Contain("Please verify that the following transaction is correct by selecting the Submit button below");
        public void ClickSubmit() => btnSubmit.Click();
        public void VerifySuccessMessage() => txtSuccessMessage.Text.Should().Be("You successfully submitted your transaction.");
        public void ClickUsername() => usernameToggle[1].Click();
        public void ClickLogout() => lnkLogout.Click();

    }
}
