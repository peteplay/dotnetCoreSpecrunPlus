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
    class PayBillsPage : Drivers.DriverHelper
    {
        //IWebElement tabPayBills => Driver.FindElement(By.XPath("//li[@id='pay_bills_tab']"));
        IList<IWebElement> tabsPayment => Driver.FindElements(By.ClassName("ui-state-default"));
        IWebElement drpPayee = Driver.FindElement(By.XPath("//select[@id='sp_payee']"), 10);
        //IWebElement drpPayee = Driver.FindElement(By.Id("sp_payee"));
        IWebElement drpSavings = Driver.FindElement(By.Id("sp_account"));
        IWebElement txtAmount = Driver.FindElement(By.Id("sp_amount"));
        IWebElement txtDate = Driver.FindElement(By.Id("sp_date"));
        IWebElement txtDescription = Driver.FindElement(By.Id("sp_description"));
        IWebElement btnPay = Driver.FindElement(By.XPath("//input[@type='submit']"));
        

        //public void ClickPayBillsTab() => tabPayBills.Click();

        public void IsPaySavedPayeeTabActive()
        {
            string isTabActive = tabsPayment[0].GetAttribute("class");
            //Console.WriteLine("The class value is " + isTabActive);
            isTabActive.Should().Contain("ui-state-active");
        }

        public void FillPaymentForm(string payee, string creditCard, int amount, string date, string description)
        {
            // select the payee
            SelectElement payeeOption = new SelectElement(drpPayee);
            payeeOption.SelectByText(payee);
            drpPayee.Click();

            // select the account
            SelectElement savingsOption = new SelectElement(drpSavings);
            savingsOption.SelectByText(creditCard);
            drpPayee.Click();

            // enter an amount
            txtAmount.SendKeys(amount.ToString());

            // enter today +1 day
            //var payeeDate = DateTime.Today.AddDays(1).ToString("YYYY-MM-dd");
            var payeeDate = DateTime.Now.Date.AddDays(+1).ToString("yyyy-MM-dd");
            txtDate.SendKeys(payeeDate);

            // enter a description
            txtDescription.SendKeys(description);
            //Thread.Sleep(5000);

            // click Pay
            btnPay.Click();
        }

        


    }


}
