using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralUtilities;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UITesting;

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
            SCDriverChrome.driverChrome.Navigate().GoToUrl("http://app1.shareconnectdev.com");

            // this clicks the "Sign In" and goes to the SC login in page 
            SCSignInPage scSignInPage = scWebPage.SignInToSC();

            Thread.Sleep(3000);

            // This is to sign in the SC account
            SCHomePage scHomePage = scSignInPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
                                                            GeneralUtilities.ConstantsUtil.defaultUserPwd);
            Thread.Sleep(3000);

            ComputersPage computersPage = scHomePage.GoToComputers();
            Thread.Sleep(3000);

            scHomePage.SignOutSC();
        }

        [Test]
        public void WebApp_VerifyDashboard()
        {
            SCDriverChrome.driverChrome.Navigate().GoToUrl("http://app1.shareconnectdev.com");

            // this clicks the "Sign In" and goes to the SC login in page 
            SCSignInPage scSignInPage = scWebPage.SignInToSC();

            Thread.Sleep(3000);

            // This is to sign in the SC account
            SCHomePage scHomePage = scSignInPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
                                                            GeneralUtilities.ConstantsUtil.defaultUserPwd);
            Thread.Sleep(3000);

            scHomePage.GoToDashboard();

            scHomePage.SignOut();
        }

        [Test]
        public void WebApp_VerifySignOut()
        {
                SCDriverChrome.driverChrome.Navigate().GoToUrl("http://app1.shareconnectdev.com");

                // this clicks the "Sign In" and goes to the SC login in page 
                SCSignInPage scSignInPage = scWebPage.SignInToSC();

                Thread.Sleep(3000);

                // This is to sign in the SC account
                SCHomePage scHomePage = scSignInPage.SignInToSC(GeneralUtilities.ConstantsUtil.defaultUserEmail,
                                                                GeneralUtilities.ConstantsUtil.defaultUserPwd);
                Thread.Sleep(3000);

                scHomePage.SignOut();
        }

        [Test]
        public void WebApp_SignUp()
        {
        }

        [Test]
        public void WebApp_LoginHost()
        {
            // This is to connect to a Host machine
            // XXXX Need to see if this webApp can talk to Desktop App
            // Comment the below out first 

            //computersPage.ClickWin10Aws();
            //Thread.Sleep(20000);

            //Keyboard.SendKeys("Test");
            //Thread.Sleep(1000);
            //Keyboard.SendKeys("{TAB}"); // jump to pwd
            //Keyboard.SendKeys("Test1234");
            //Thread.Sleep(1000);
            //Keyboard.SendKeys("{ENTER}");
            //Thread.Sleep(20000);
            //GeneralUtilities.LoginConnectUtil.ConnectHost();
            //GeneralUtilities.LoginConnectUtil.DisconnectHost();
        }

        [TearDown]
        public void CleanUp()
        {
            // xxxx need to check why running more than 1 test cases will cause trouble.
            SCDriverChrome.driverChrome.Quit();
        }

    }
}
