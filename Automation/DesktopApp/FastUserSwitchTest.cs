using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralUtilities;
using Microsoft.VisualStudio.TestTools.UITesting;
using System.Threading;
using System.Drawing;

namespace DesktopApp
{
    class FastUserSwitchTest
    {
        private static string[] userNameAry = { "RDULGWOJIEHW02\\Tester", "RDULGWOJIEHW02\\Joker", "RDULGWOJIEHW02\\Joker", "RDULGWOJIEHW02\\Tester", "RDULGWOJIEHW02\\Tester" };
        private static string pwd = "Test1234";

        public static void FusTest()
        {
            GeneralUtilities.LoginConnectUtil.ConnectHost("Tester");

            Mouse.Click();  // take me out when whole sequence is executed

            int loopCnt = 10;
            Logger.log.Info("****!!!!  Running FUS test " + loopCnt + " times  !!!!****");

            for (int i = 1; i <= loopCnt; i++)
            {
                RunFUS(i);
            }

            GeneralUtilities.LoginConnectUtil.DisconnectHost();
        }

        public static void RunFUS(int loopCnt)
        {
            Logger.log.Info("******  Start RunFUS() with loopCnt = " + loopCnt + "  ********");

            bool isSwitching = false;
            if (loopCnt % 2 == 0)
                isSwitching = true;

            GeneralUtilities.FunctionalButtonsUtil.ClickCtrlAltDelButton();

            // click Switch User
            // Mouse.Location = new Point(908, 560);   // sing out,  win10
            // Mouse.Location = new Point(938, 480);   // switch user,  win10
            // Mouse.Location = new Point(968, 650);   // switch user, win7
            Thread.Sleep(1000);
            if (isSwitching)
            {
                Mouse.Click(new Point(938, 480));
                Logger.log.Info("    ===  Start switching user, wait for 30 seconds  === ");
                Thread.Sleep(30000);
            }
            else
            {
                Mouse.Click(new Point(908, 560));
                Logger.log.Info("    ===  Start signing out, wait for 30 seconds  === ");
                Thread.Sleep(5000);
                Mouse.Location = new Point(650, 940);
                Mouse.Click(new Point(650, 940));   // close applications
                Thread.Sleep(30000);
            }
            
            Mouse.Click();   // need this for "Sign Out"
            Thread.Sleep(1000);

            // logon notice
            Mouse.Location = new Point(700, 740);  
            Thread.Sleep(1000);
            Mouse.Click(new Point(700, 740));

            // Login credentials
            int idx = loopCnt % userNameAry.Length;
            string uName = userNameAry[idx];
            Logger.log.Info("    ===  Connect to Host with user name : " + uName + "  === ");

            Thread.Sleep(3000);
            Keyboard.SendKeys(uName);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}"); // jump to pwd
            Keyboard.SendKeys(pwd);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(3000);

            //following is non-sense for this particular win10 laptop
            Keyboard.SendKeys("{TAB}");
            Keyboard.SendKeys("{TAB}");
            Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");

            // wait for 30 seconds, should log back in again 
            Logger.log.Info("    ===  Logged back in, wait for 30 seconds  === ");
            Thread.Sleep(30000);

            //GeneralUtilities.FileTransferUtil.OpenFileTransfer();
            //Thread.Sleep(5000);
            //GeneralUtilities.FileTransferUtil.CloseFileTransfer();
            Thread.Sleep(1000);

            Logger.log.Info("******  End RunFUS()  with loopCnt = " + loopCnt + "  ********");

        }
    }
}
