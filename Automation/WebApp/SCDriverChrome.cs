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
        public static IWebDriver driverChrome { get; set; }

        public static WebDriverWait driverChromeWait { get; set; }

        static SCDriverChrome()
        {
            driverChrome = new ChromeDriver();
            driverChromeWait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(30));
        }
    }
}
