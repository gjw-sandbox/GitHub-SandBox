using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    class SCWebPage
    {
        public SCWebPage()
        {
            PageFactory.InitElements(SCDriverChrome.driverChrome, this);
        }

        [FindsBy(How = How.Id, Using = "signin")]
        public IWebElement SignInBtn { set; get; }

        [FindsBy(How = How.Id, Using = "RegFormSubmit")]
        public IWebElement SignUpBtn { set; get; }

        [FindsBy(How = How.Id, Using = "RegFirstName")]
        public IWebElement firstNameTxt { set; get; }

        // add more stuff here for last name... etc



        public SCSignInPage SignInToSC()
        {
            // this will bring user to the sign-in page
            SignInBtn.Click();

            return new SCSignInPage();
        }

        public void SignUpSC(string emailAdr, string pwd)
        {
            firstNameTxt.SendKeys("Tester1");
            //.... and more 

            SignUpBtn.Click();
        }
    }
}
