using OpenQA.Selenium;
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

        public static void GoToSettings()
        {
            // Click "Settings"
            SCDriverChrome.driverChrome.FindElement(By.Id("topMenuLink")).Click();  // click this first to expose "Sign Out" and "Settings"
            Thread.Sleep(2000);
            SCDriverChrome.driverChrome.FindElement(By.LinkText("Settings")).Click();
            Thread.Sleep(2000);

            // Verify that Account Info page is displayed
            try
            {
                SCDriverChrome.driverChrome.FindElement(By.XPath("//label[text()='Account Information']"));
                //MessageBox.Show("Found it!");
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error!!!");
            }
        }

        public static void GoToComputers()
        {
            // Click "Computers"
            SCDriverChrome.driverChrome.FindElement(By.XPath("//*[@id='sidebar-wrapper']/div/ul[2]/li[1]")).Click();
            Thread.Sleep(3000);
        }

        public static void GoToDashboard()
        {
            // Click "Dashboard"
            SCDriverChrome.driverChrome.FindElement(By.XPath("//*[@id='sidebar-wrapper']/div/ul[3]/li[2]/a")).Click();
            Thread.Sleep(3000);

            // Verify that Account Info page is displayed
            try
            {
                SCDriverChrome.driverChrome.FindElement(By.XPath("//h2[text()='Dashboard']"));
                //MessageBox.Show("Found dashboard!");
            }
            catch (NoSuchElementException)
            {
                MessageBox.Show("Error!!! No Dashboard found!");
            }
        }

        public static void SignOut()
        {
            SCDriverChrome.driverChrome.FindElement(By.Id("topMenuLink")).Click();  // click this first to expose "Sign Out" and "Settings"
            SCDriverChrome.driverChrome.FindElement(By.LinkText("Sign Out")).Click();
        }

    }
}
