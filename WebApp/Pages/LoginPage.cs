using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using OpenQA.Selenium;
using WebApp.Drivers;

namespace WebApp.Pages
{
    class LoginPage : Drivers.DriverHelper
    {
        IWebElement txtLogin => Driver.FindElement(By.Id("user_login"), 10);
        IWebElement txtPassword => Driver.FindElement(By.Id("user_password"));
        IWebElement btnSignIn => Driver.FindElement(By.XPath("//input[@type='submit']"));

        public void EnterUserNameAndPassword(string username, string password)
        {
            txtLogin.SendKeys(username);
            txtPassword.SendKeys(password);
        }

        public void ClickSubmit() => btnSignIn.Click();

    }
}
