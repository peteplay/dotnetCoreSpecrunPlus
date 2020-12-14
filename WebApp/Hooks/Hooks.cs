using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;
using WebApp.Pages;

namespace WebApp.Hooks1
{
    [Binding]

    public sealed class Hooks : Drivers.DriverHelper
    {
        private ScenarioContext _scenarioContext;

        [BeforeFeature(Order = 0)]
        public static void OpenBrowserAndNavigateToLandingPage()
        {
            switch (Environment.GetEnvironmentVariable("Test_Browser"))
            {
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(new List<string>() { "headless", "--start-maximized" });
                    //chromeOptions.AddArguments(new List<string>() { "--start-maximized" });
                    Driver = new ChromeDriver(chromeOptions);
                    break;
                //case "Firefox":
                //    var firefoxOptions = new FirefoxOptions();
                //    //firefoxOptions.AddArguments("--start-maximized", "--acceptInsecureCerts");
                //    firefoxOptions.SetPreference("AcceptInsecureCertificates", true);
                //    //firefoxOptions.AddArguments("--headless", "--start-maximized");
                //    Driver = new FirefoxDriver(firefoxOptions);
                //    break;
                //case "Edge":
                //    var edgeDriverService = Microsoft.Edge.SeleniumTools.EdgeDriverService.CreateChromiumService();
                //    var edgeOptions = new Microsoft.Edge.SeleniumTools.EdgeOptions();
                //    edgeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                //    edgeOptions.UseChromium = true;
                //    //edgeOptions.AddArguments("--headless");
                //    //edgeOptions.AddArguments("--start-maximized");
                //    edgeOptions.AddArguments(new List<string>() { "headless", "--start-maximized" });
                //    Driver = new Microsoft.Edge.SeleniumTools.EdgeDriver(edgeDriverService, edgeOptions);
                //    break;
            }

            var baseURL = Environment.GetEnvironmentVariable("__BaseUrl");
            Driver.Navigate().GoToUrl(baseURL);
        }

        [BeforeFeature(Order=1)]
        [Scope(Feature="TransferFunds")]
        [Scope(Feature = "PayBills")]
        public static void LoginToWebsite()
        {
            var username = Environment.GetEnvironmentVariable("__Username");
            var password = Environment.GetEnvironmentVariable("__Password");

            HomePage homePage = new HomePage();
            //LoginPage loginPage = new LoginPage();
            LoginPage loginPage = homePage.ClickLogin();
            loginPage.EnterUserNameAndPassword(username, password);
            loginPage.ClickSubmit();
        }


        [AfterScenario]
        public void Screenshots(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            if (_scenarioContext.TestError != null)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
                string fileName = $"{fileNameWithoutExtension}.png";
                string tempFileName = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(tempFileName, ScreenshotImageFormat.Png);

                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }
        }

        //[AfterScenario]
        //public void AfterScenario(ScenarioContext scenarioContext)
        //{
        //    Driver.Close();
        //}

        [AfterFeature]
        public static void AfterFeature()
        {
            Driver.Close();
        }
    }
}
