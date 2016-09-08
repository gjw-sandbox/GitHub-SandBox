using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralUtilities;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace WebApp
{
    public static class Logger
    {
        public static log4net.ILog log = SCLogHelper.Logger(System.Reflection.MethodBase.GetCurrentMethod());
    }

    [TestFixture]
    public class WebAppTest
    {
        IWebDriver driverChrome;

        [SetUp]
        public void Init()
        {
            driverChrome = new ChromeDriver();
        }

        [Test]
        public void WebApp_TestMethod1()
        {
            driverChrome.Navigate().GoToUrl("http://app1.shareconnectdev.com");
            Thread.Sleep(5000); 
        }

        [TearDown]
        public void CleanUp()
        {
            driverChrome.Close();
        }

    }
}
