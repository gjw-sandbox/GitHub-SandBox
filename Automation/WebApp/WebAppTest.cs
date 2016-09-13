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

    [TestFixture]
    public class WebAppTest
    {
        private IWebDriver driverChrome;
        private WebDriverWait driverChromeWait;

        [SetUp]
        public void Init()
        {
            driverChrome = SCDriverChrome.driverChrome;
            driverChromeWait = SCDriverChrome.driverChromeWait;
        }

        [Test]
        public void WebApp_SignIn()
        {
            SCWebPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
                                 GeneralUtilities.ConstantsUtil.defaultUserPwd);

            SCHomePage.SignOut();


            //string x = driverChrome.PageSource;
            //Logger.log.Info(x);
        }

        [Test]
        public void WebApp_VerifySettings()
        {
            SCWebPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
                                 GeneralUtilities.ConstantsUtil.defaultUserPwd);

            SCHomePage.GoToSettings();

            SCHomePage.SignOut();
        }

        [Test]
        public void WebApp_VerifyComputers()
        {
            SCWebPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
                                 GeneralUtilities.ConstantsUtil.defaultUserPwd);

            SCHomePage.GoToComputers();

            SCHomePage.SignOut();
        }

        [Test]
        public void WebApp_VerifyDashboard()
        {
            SCWebPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
                                 GeneralUtilities.ConstantsUtil.defaultUserPwd);

            SCHomePage.GoToDashboard();

            SCHomePage.SignOut();
        }

        [Test]
        public void WebApp_VerifySignOut()
        {
            SCWebPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
                                 GeneralUtilities.ConstantsUtil.defaultUserPwd);

            SCHomePage.SignOut();
        }

        [Test]
        public void WebApp_SignUp()
        {
        }

        [TearDown]
        public void CleanUp()
        {
            driverChrome.Quit();
        }

    }
}
