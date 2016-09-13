using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp
{
    class SCDriverChrome
    {
        private static IWebDriver driverChrome;
        private static WebDriverWait driverChromeWait;

        static SCDriverChrome()
        {
            driverChrome = new ChromeDriver();
            driverChromeWait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(15));
        }
        public static IWebDriver Driver()
        {
            return driverChrome;
        }

        public static WebDriverWait DriverWait()
        {
            return driverChromeWait;
        }

    }
}
