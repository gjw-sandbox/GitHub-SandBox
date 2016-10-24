using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp
{
    class ManageUsersPage
    {
        public ManageUsersPage()
        {
            PageFactory.InitElements(SCDriverChrome.driverChrome, this);
        }
    }
}
