using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using WebApp.Drivers;
using System.Threading;

namespace WebApp.Pages
{
    class PayBillsAckPage : Drivers.DriverHelper
    {
        IWebElement msgPaymentSuccess = Driver.FindElement(By.Id("alert_content"), 10);

        public void VerifySuccessMessage() => msgPaymentSuccess.Text.Should().Be("The payment was successfully submitted.");
    }


}
