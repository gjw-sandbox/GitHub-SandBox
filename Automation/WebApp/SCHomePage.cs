using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebApp
{
    class SCHomePage
    {
        public SCHomePage()
        {
            PageFactory.InitElements(SCDriverChrome.driverChrome, this);
        }

        [FindsBy(How = How.Id, Using = "topMenuLink")]
        public IWebElement user { set; get; }

        [FindsBy(How = How.LinkText, Using = "Sign Out")]
        public IWebElement signout { set; get; }

        [FindsBy(How = How.LinkText, Using = "Settings")]
        public IWebElement settings { set; get; }

        [FindsBy(How = How.LinkText, Using = "Computers")]
        public IWebElement computers { set; get; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='sidebar-wrapper']/div/ul[3]/li[2]/a")]
        //public IWebElement dashboard { set; get; }

        [FindsBy(How = How.LinkText, Using = "Manage Users")]
        public IWebElement ManageUsers { set; get; }


        public void SignOutSC()
        {
            user.Click();
            Thread.Sleep(1000);

            signout.Click();
            Thread.Sleep(1000);
        }

        public void GoToSettings()
        {
            // Click "Settings"
            user.Click();
            Thread.Sleep(1000);

            settings.Click();
            Thread.Sleep(2000);

            // Verify that Account Info page is displayed
            // Should create an Account Info page
            try
            {
                SCDriverChrome.driverChrome.FindElement(By.XPath("//label[text()='Account Information']"));
                //MessageBox.Show("Found it!");
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error!!! annot find Account Information page");
            }
        }

        public ComputersPage GoToComputers()
        {
            // Click "Computers"
            computers.Click();
            Thread.Sleep(2000);

            return new ComputersPage();
        }

        //public void GoToDashboard()
        //{
        //    // Click "Dashboard"
        //    dashboard.Click();
        //    Thread.Sleep(3000);

        //    // Verify that Account Info page is displayed
        //    try
        //    {
        //        SCDriverChrome.driverChrome.FindElement(By.XPath("//h2[text()='Dashboard']"));
        //        //MessageBox.Show("Found dashboard!");
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        MessageBox.Show("Error!!! No Dashboard found!");
        //    }
        //}

        public void GotoManageUsers()
        {
            // Click "Manage Users"
            ManageUsers.Click();
            Thread.Sleep(2000);

        }

        public void SignOut()
        {
            // Click "Settings"
            user.Click();
            Thread.Sleep(1000);

            signout.Click();
            Thread.Sleep(2000);
        }

    }
}
