using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralUtilities
{
    public static class Logger
    {
        public static log4net.ILog log = SCLogHelper.Logger(System.Reflection.MethodBase.GetCurrentMethod());
    }

    public class LoginConnectUtil
    {
        /// <summary>
        /// Launch '%LOCALAPPDATA%\Citrix\ShareConnectDesktopApp\ShareConnect.Client.WindowsDesktop.exe'
        /// </summary>
        private static string uIShareConnectWindowExePath = "C:\\Users\\gwojiehw\\AppData\\Local\\Citrix\\ShareConnectDesktopApp\\ShareConnect.Client" +
            ".WindowsDesktop.exe";

        /// <summary>
        /// Launch '%LOCALAPPDATA%\Citrix\ShareConnectDesktopApp\ShareConnect.Client.WindowsDesktop.exe'
        /// </summary>
        private static string uIShareConnectWindowAlternateExePath = "%LOCALAPPDATA%\\Citrix\\ShareConnectDesktopApp\\ShareConnect.Client.WindowsDesktop.e" +
            "xe";

        public static void LaunchDA()
        {
            Logger.log.Info("******  Start LaunchDA() ********");
            
            // Launch '%LOCALAPPDATA%\Citrix\ShareConnectDesktopApp\ShareConnect.Client.WindowsDesktop.exe'
            ApplicationUnderTest.Launch(uIShareConnectWindowExePath, uIShareConnectWindowAlternateExePath);

            Logger.log.Info("******  End LaunchDA() ********");
        }

        public static void LoginDA(string userEmail = "", string userPwd = "")
        {
            Logger.log.Info("******  Start LoginDA() ********");

            if (userEmail == "")
            {
                userEmail = ConstantsUtil.defaultUserEmail;
            }
            if (userPwd == "")
            {
                userPwd = ConstantsUtil.defaultUserPwd;
            }

            Logger.log.Debug(" === LoginDA uses user email : " + userEmail.ToString());

            HtmlEdit credentialsEmailEdit = DesktopAppControls.GetCredentialsEmailEdit();

            HtmlEdit credentialsPasswordEdit = DesktopAppControls.GetCredentialsPasswordEdit();

            HtmlButton signInButton = DesktopAppControls.GetSignInButton();


            // Type 'abc@gmail.com' in 'credentials-email' text box
            credentialsEmailEdit.Text = userEmail;

            // Type '********' in 'credentials-password' text box
            credentialsPasswordEdit.Text = userPwd;

            // Click 'Sign In' button
            Mouse.Click(signInButton, new Point(218, 21));
            Thread.Sleep(10000);

            Logger.log.Info("******  End LoginDA() ********");
        }

        public static void LoginDA_Faileure(string userEmail = "", string userPwd = "")
        {
            Logger.log.Info("******  Start LoginDA_Faileure() ********");

            if (userEmail == "")
            {
                userEmail = ConstantsUtil.defaultUserEmail;
            }
            if (userPwd == "")
            {
                userPwd = ConstantsUtil.defaultUserPwd;
            }

            Logger.log.Debug(" === LoginDA_Faileure uses user email : " + userEmail.ToString());

            HtmlEdit credentialsEmailEdit = DesktopAppControls.GetCredentialsEmailEdit();

            HtmlEdit credentialsPasswordEdit = DesktopAppControls.GetCredentialsPasswordEdit();

            HtmlDiv usernameorPasswordwaPane = new HtmlDiv(DesktopAppControls.GetApplicationHostPane());
            usernameorPasswordwaPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "error";
            usernameorPasswordwaPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"error\" data-bind=\"html: ErrorMessage\"";
            usernameorPasswordwaPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "22";

            HtmlButton signInButton = DesktopAppControls.GetSignInButton();


            // Type email in 'credentials-email' text box
            credentialsEmailEdit.Text = userEmail;

            // Type pwd in 'credentials-password' text box
            credentialsPasswordEdit.Text = userPwd;

            // Click 'Sign In' button
            Mouse.Click(signInButton, new Point(218, 21));
            Thread.Sleep(5000);

            Assert.AreEqual("Username or Password was incorrect.", usernameorPasswordwaPane.InnerText, "!!!! INCORRERCT ERROR MESSAGE !!!");

            Logger.log.Info("******  End LoginDA_Faileure() ********");
        }


        public static void LoginDA_CompanyCredential()
        {
            HtmlSpan loginButton = DesktopAppControls.GetLoginwithmycompanycrPane();
            Mouse.Click(loginButton);
        }

        public static void LoginDA_ForgotPassword()
        {
            HtmlButton forgotPwdButton = DesktopAppControls.GetForgotPasswordButton();
            Mouse.Click(forgotPwdButton);
        }

        public static void LoginDA_PrivacyPolicyHyperlink()
        {
            HtmlHyperlink privacyPolicyHyperlink = DesktopAppControls.GetPrivacyPolicyHyperlink();
            Mouse.Click(privacyPolicyHyperlink);
        }

        public static void LogoutDA()
        {
            Logger.log.Info("******  Start LogoutDA() ********");

            WpfImage settings_buttonImage = DesktopAppControls.GetSettings_buttonImage();

            Mouse.Click(settings_buttonImage, new Point(6, 6));
            Thread.Sleep(3000);

            WpfCustom aboutBladeCustom = DesktopAppControls.GetAboutBladeCustom();

            Mouse.Click(aboutBladeCustom, new Point(45, 330));
            Thread.Sleep(3000);

            // Click 'Yes' button
            WpfButton yesButton = DesktopAppControls.GetConfirmSignOutYesButton();

            Mouse.Click(yesButton, new Point(35, 21));
            Thread.Sleep(8000);

            Logger.log.Info("******  End LogoutDA() ********");
        }

        public static void CloseDA()
        {
            // Click 'Close' button
            WpfButton closeButton = DesktopAppControls.GetDesktopAppCloseButtonX();

            Mouse.Click(closeButton, new Point(35, 21));
        }

        public static void ConnectHost(string userName = "", string hostPwd = "")
        {
            Logger.log.Info("******  Start ConnectHost() ********");

            if (userName == "")
            {
                userName = ConstantsUtil.defaultHostName;
            }
            if (hostPwd == "")
            {
                hostPwd = ConstantsUtil.defaultHostPwd;
            }
            Logger.log.Debug("    ===  Connect to Host with user name : " + userName + "  === ");

            WpfCustom settingBladeCustom = DesktopAppControls.GetSettingBladeCustom();

            Thread.Sleep(1000);
            Mouse.Click(settingBladeCustom, new Point(44, 114));  // win10
//            Mouse.Click(settingBladeCustom, new Point(62, 157));   // win7
            Thread.Sleep(8000);

            Keyboard.SendKeys(userName);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}"); // jump to pwd
            Keyboard.SendKeys(hostPwd);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(20000);

            Mouse.Click(); // ??? need this
            Thread.Sleep(1000);

            Logger.log.Info("******  End ConnectHost() ********");
        }

        public static void ConnectHostWithControls(string userName = "", string hostPwd = "")
        {
            Logger.log.Info("******  Start ConnectHostWithControls() ********");

            if (userName == "")
            {
                userName = ConstantsUtil.defaultHostName;
            }
            if (hostPwd == "")
            {
                hostPwd = ConstantsUtil.defaultHostPwd;
            }
            Logger.log.Debug("    ===  Connect to Host with user name : " + userName + "  === ");

            WpfCustom settingBladeCustom = DesktopAppControls.GetSettingBladeCustom();

            Thread.Sleep(1000);
            Mouse.Click(settingBladeCustom, new Point(44, 114));  // win10
                                                                  // Mouse.Click(settingBladeCustom, new Point(62, 157));   // win7
            Thread.Sleep(8000);

            WpfImage hamburgerImageImage = DesktopAppControls.GetHamburgerImageImage();
            Mouse.Click(hamburgerImageImage);
            Thread.Sleep(2000);

            Mouse.Click(); // ??? need this
            Thread.Sleep(1000);

            Logger.log.Info("******  End ConnectHostWithControls() ********");
        }


        public static void CancelConnectHost()
        {
            Logger.log.Info("******  Start CancelConnectHost() ********");

            string userName = ConstantsUtil.defaultHostName;

            WpfCustom settingBladeCustom = DesktopAppControls.GetSettingBladeCustom();

            Thread.Sleep(1000);
            Mouse.Click(settingBladeCustom, new Point(44, 114));
            Thread.Sleep(8000);

 
            Keyboard.SendKeys(userName);
            Thread.Sleep(1000);
            Keyboard.SendKeys("{TAB}"); // jump to pwd
            Keyboard.SendKeys("{TAB}"); // jump to "Login" or to "Cancel" if no input of credentials
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(3000);

            // xxxx need to check bladeview is up again ??? is following working ???
            Assert.IsTrue(settingBladeCustom.GetProperty("Enabled").Equals(true));

            Logger.log.Info("******  End CancelConnectHost() ********");
        }

        public static void DisconnectHost()
        {
            Logger.log.Info("******  Start DisconnectHost() ********");

            WpfCustom bladeViewControlCustom = DesktopAppControls.GetBladeViewControlCustom();

            Mouse.Click(bladeViewControlCustom, new Point(1869, 18));

            Logger.log.Info("******  End DisconnectHost() ********");
        }


    }
}
