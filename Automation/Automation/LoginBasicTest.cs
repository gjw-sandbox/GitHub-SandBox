using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesktopApp
{
    class LoginBasicTest
    {
        public static void DA_Login_Logout_Test()
        {
            GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA();    // will use defaults if no arg provided.
            GeneralUtilities.LoginConnectUtil.LogoutDA();
            GeneralUtilities.LoginConnectUtil.CloseDA();
        }

        public static void DA_Login_Error_Test()
        {
            GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA_Faileure("gjwin7@grr.la", "1111");
            GeneralUtilities.LoginConnectUtil.LoginDA_Faileure("abcd@grr.la", "2222");
            GeneralUtilities.LoginConnectUtil.CloseDA();
        }

        public static void DA_Login_Company_Credential_Test()
        {
            //GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA_CompanyCredential();    
        }

        public static void DA_Login_Forgot_Password_Test()
        {
            //GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA_ForgotPassword();
        }

        public static void DA_Login_LoginDA_Privacy_Policy_Test()
        {
            //GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA_PrivacyPolicyHyperlink();
        }

        
        public static void Host_Connect_Disconnect_Test()
        {
            GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA();
            GeneralUtilities.LoginConnectUtil.CancelConnectHost();
            GeneralUtilities.LoginConnectUtil.ConnectHost("Joker");
            GeneralUtilities.LoginConnectUtil.DisconnectHost();
            GeneralUtilities.LoginConnectUtil.LogoutDA();
            GeneralUtilities.LoginConnectUtil.CloseDA();
        }

        public static void Host_Connect_Use_Controls_Test()
        {
            //GeneralUtilities.LoginConnectUtil.LaunchDA();
            //GeneralUtilities.LoginConnectUtil.LoginDA();
            //GeneralUtilities.LoginConnectUtil.CancelConnectHost();
            GeneralUtilities.LoginConnectUtil.ConnectHostWithControls("Joker");
            GeneralUtilities.LoginConnectUtil.DisconnectHost();
            //GeneralUtilities.LoginConnectUtil.LogoutDA();
            //GeneralUtilities.LoginConnectUtil.CloseDA();
        }
    }
}
