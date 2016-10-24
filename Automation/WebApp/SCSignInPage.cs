using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp
{
    class SCSignInPage
    {
        public SCSignInPage()
        {
            PageFactory.InitElements(SCDriverChrome.driverChrome, this);
        }

        [FindsBy(How = How.Id, Using = "credentials-email")]
        public IWebElement emailTxt { set; get; }

        [FindsBy(How = How.Id, Using = "credentials-password")]
        public IWebElement pwdTxt { set; get; }

        [FindsBy(How = How.Id, Using = "start-button")]
        public IWebElement signInBtn { set; get; }


        public SCHomePage SignInToSC(string emailAdr, string pwd)
        {
            emailTxt.SendKeys(emailAdr);
            pwdTxt.SendKeys(pwd);
            Thread.Sleep(1000);

            signInBtn.Click();

            //DismissDAInstaller();  // may not need this any more. This is for the DA installer stuff

            return new SCHomePage();
        }

        private static void DismissDAInstaller()
        {
            // dis-miss "install DA"
            SCDriverChrome.driverChromeWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[contains(@src, 'closeoverlay')]")));
            SCDriverChrome.driverChrome.FindElement(By.XPath("//img[contains(@src, 'closeoverlay')]")).Click();
            Thread.Sleep(1000);
        }
    }
}
