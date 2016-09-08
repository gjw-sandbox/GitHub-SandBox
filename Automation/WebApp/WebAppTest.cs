using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralUtilities;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;

namespace WebApp
{
    public static class Logger
    {
        public static log4net.ILog log = SCLogHelper.Logger(System.Reflection.MethodBase.GetCurrentMethod());
    }
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }

    [TestFixture]
    public class WebAppTest
    {
        IWebDriver driverChrome;
        WebDriverWait driverChromeWait;

        [SetUp]
        public void Init()
        {
            driverChrome = new ChromeDriver();
            driverChromeWait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(10));

            //driverChrome.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
        }

        [Test]
        public void WebApp_SignInOut()
        {
            driverChrome.Navigate().GoToUrl("http://app1.shareconnectdev.com");
            
            driverChrome.FindElement(By.Id("signin")).Click();
            WebDriverExtensions.FindElement(driverChrome, By.Id("credentials-email"), 10);

            driverChrome.FindElement(By.Id("credentials-email")).SendKeys("gjwin10@grr.la");
            driverChrome.FindElement(By.Id("credentials-password")).SendKeys("Test1234");
            driverChrome.FindElement(By.Id("start-button")).Click();

            Thread.Sleep(10000);
            driverChrome.FindElement(By.Id("topMenuLink")).Click();  // click this first to expose "Sign Out" and "Settings"
            Thread.Sleep(3000);
            driverChrome.FindElement(By.LinkText("Settings")).Click();           
            Thread.Sleep(3000);

            try
            {
                driverChrome.FindElement(By.XPath("//label[text()='Account Information']"));
                //MessageBox.Show("Found it!");
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error!!!");
            }

            //string x = driverChrome.PageSource;
            //Logger.log.Info(x);

            driverChrome.FindElement(By.Id("topMenuLink")).Click();  // click this first to expose "Sign Out" and "Settings"
            driverChrome.FindElement(By.LinkText("Sign Out")).Click();
            Thread.Sleep(1000);

        }

        [TearDown]
        public void CleanUp()
        {
            driverChrome.Quit();
        }

    }
}
