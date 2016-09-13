using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralUtilities
{
    public class loginViewUtil
    {
        public static void ConnectHostLoginView()
        {
            Logger.log.Info("******  Start ConnectHostLoginView() ********");

            WpfCustom settingBladeCustom = DesktopAppControls.GetSettingBladeCustom();

            Thread.Sleep(1000);
            Mouse.Click(settingBladeCustom, new Point(44, 114));  // win10
            // Mouse.Click(settingBladeCustom, new Point(62, 157));   // win7
            Thread.Sleep(8000);

            // hamburger
            WpfImage hamburgerImageImage = LoginViewControls.GetHamburgerImageImage();
            Mouse.Click(hamburgerImageImage);
            Thread.Sleep(2000);

            // user name
            WpfComboBox userListComboBox = LoginViewControls.GetUserListComboBox();
            Mouse.Click(userListComboBox);
            Thread.Sleep(2000);

            // pwd
            WpfEdit passwordFieldEdit = LoginViewControls.GetPasswordFieldEdit();
            Mouse.Click(passwordFieldEdit);
            Thread.Sleep(2000);

            // login button
            WpfButton logInButton = LoginViewControls.GetLogInButton();
            Mouse.Click(logInButton);
            Thread.Sleep(2000);

            // pwd
            WpfButton cancelButton = LoginViewControls.GetCancelButton();
            Mouse.Click(cancelButton);
            Thread.Sleep(2000);


            Logger.log.Info("******  End ConnectHostLoginView() ********");
        }

    }
}
