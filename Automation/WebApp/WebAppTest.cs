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
        private SCWebPage scWebPage;

        [SetUp]
        public void Init()
        {
            scWebPage = new SCWebPage();
        }

        [Test]
        public void WebApp_SignIn()
        {
            SCDriverChrome.driverChrome.Navigate().GoToUrl("http://app1.shareconnectdev.com");

            // this clicks the "Sign In" and goes to the SC login in page 
            SCSignInPage scSignInPage = scWebPage.SignInToSC();

            Thread.Sleep(3000);

            // This is to sign in the SC account
            SCHomePage scHomePage = scSignInPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
                                                            GeneralUtilities.ConstantsUtil.defaultUserPwd);

            Thread.Sleep(3000);

            scHomePage.SignOutSC();
            
            //string x = driverChrome.PageSource;
            //Logger.log.Info(x);
        }

        [Test]
        public void WebApp_VerifySettings()
        {
            SCDriverChrome.driverChrome.Navigate().GoToUrl("http://app1.shareconnectdev.com");

            // this clicks the "Sign In" and goes to the SC login in page 
            SCSignInPage scSignInPage = scWebPage.SignInToSC();

            Thread.Sleep(3000);

            // This is to sign in the SC account
            SCHomePage scHomePage = scSignInPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
                                                            GeneralUtilities.ConstantsUtil.defaultUserPwd);
            
            Thread.Sleep(3000);
            scHomePage.GoToSettings();

            scHomePage.SignOutSC();
        }

        [Test]
        public void WebApp_VerifyComputers()
        {
            //scWebPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
            //                     GeneralUtilities.ConstantsUtil.defaultUserPwd);

            //SCHomePage.GoToComputers();

            //SCHomePage.SignOut();
        }

        [Test]
        public void WebApp_VerifyDashboard()
        {
            //scWebPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
            //                     GeneralUtilities.ConstantsUtil.defaultUserPwd);

            //SCHomePage.GoToDashboard();

            //SCHomePage.SignOut();
        }

        [Test]
        public void WebApp_VerifySignOut()
        {
            //scWebPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
            //                     GeneralUtilities.ConstantsUtil.defaultUserPwd);

            //SCHomePage.SignOut();
        }

        [Test]
        public void WebApp_SignUp()
        {
        }

        [TearDown]
        public void CleanUp()
        {
            // need to check why xxxx   running more than 1 test cases will cause trouble.
            SCDriverChrome.driverChrome.Quit();
        }

    }
}
