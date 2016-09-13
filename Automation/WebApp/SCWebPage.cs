using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp
{
    class SCWebPage
    {
        private static IWebDriver driverChrome;
        private static WebDriverWait driverChromeWait;

        static SCWebPage()
        {
            driverChrome = SCDriverChrome.Driver();
            driverChromeWait = SCDriverChrome.DriverWait();
        }

        public static void SignInToSC(string emailAdr, string pwd)
        {
            driverChrome.Navigate().GoToUrl("http://app1.shareconnectdev.com");

            driverChrome.FindElement(By.Id("signin")).Click();

            SignInWithCredential(emailAdr, pwd);
        }

        private static void SignInWithCredential(string emailAdr, string pwd)
        {
            driverChromeWait.Until(ExpectedConditions.ElementExists(By.Id("credentials-email")));
            driverChrome.FindElement(By.Id("credentials-email")).SendKeys(emailAdr);
            driverChrome.FindElement(By.Id("credentials-password")).SendKeys(pwd);
            driverChrome.FindElement(By.Id("start-button")).Click();

            DismissDAInstaller();
        }

        private static void DismissDAInstaller()
        {
            // dis-miss "install DA"
            driverChromeWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[contains(@src, 'closeoverlay')]")));
            driverChrome.FindElement(By.XPath("//img[contains(@src, 'closeoverlay')]")).Click();
            Thread.Sleep(2000);
        }

    }
}
