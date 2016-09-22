using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp
{
    class ComputersPage
    {
        public ComputersPage()
        {
            PageFactory.InitElements(SCDriverChrome.driverChrome, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='sidebar-wrapper']/div/ul[2]/li[1]")]
        public IWebElement Computers { set; get; }

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div[9]/div/div[3]/div[3]/a[2]/div[2]/div[1]/h3")]
        public IWebElement win10Aws { set; get; }

        public void ClickWin10Aws()
        {
            win10Aws.Click();
        }
    }
}
