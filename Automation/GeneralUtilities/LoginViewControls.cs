using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralUtilities
{
    public class LoginViewControls
    {
        // **** cannot identify the hamburger below
        private static WpfTabList _mainTabControlTabList = null;
        private static WpfTabPage _win10awsTabPage = null;
        private static WpfPane _winformHostPane = null;
        private static WinClient _itemClient = null;
        private static WpfWindow _wpfWindow = null;
        private static WpfCustom _itemCustom = null;
        private static WpfImage _hamburgerImageImage = null;
        private static WpfComboBox _userListComboBox = null;
        private static WpfEdit _passwordFieldEdit = null;
        private static WpfButton _logInButton = null;
        private static WpfButton _cancelButton = null;


        public static WpfTabList GetMainTabControlTabList()
        {
            if (_mainTabControlTabList == null)
            {
                _mainTabControlTabList = new WpfTabList(DesktopAppControls.GetShareConnectWindow());
                _mainTabControlTabList.SearchProperties[WpfTabList.PropertyNames.AutomationId] = "MainTabControl";
            }
            return _mainTabControlTabList;
        }

        public static WpfTabPage GetWin10awsTabPage()
        {
            if (_win10awsTabPage == null)
            {
                _win10awsTabPage = new WpfTabPage(GetMainTabControlTabList());
                _win10awsTabPage.SearchProperties[WpfTabPage.PropertyNames.Name] = "win10 aws";
            }
            return _win10awsTabPage;
        }

        public static WpfPane GetWinformHostPane()
        {
            if (_winformHostPane == null)
            {
                _winformHostPane = new WpfPane(GetWin10awsTabPage());
                _winformHostPane.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.WindowsFormsHost";
                _winformHostPane.SearchProperties[WpfPane.PropertyNames.AutomationId] = "WinformHost";
            }
            return _winformHostPane;
        }

        public static WinClient GetItemClient()
        {
            if (_itemClient == null)
            {
                _itemClient = new WinClient(GetWinformHostPane());
            }
            return _itemClient;
        }

        public static WpfWindow GetWpfWindow()
        {
            if (_wpfWindow == null)
            {
                _wpfWindow = new WpfWindow(GetItemClient());
                _wpfWindow.SearchProperties[WpfWindow.PropertyNames.Name] = "Login to your server";
            }
            return _wpfWindow;
        }

        public static WpfCustom GetItemCustom()
        {
            if (_itemCustom == null)
            {
                _itemCustom = new WpfCustom(GetWpfWindow());
                _itemCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.ComputerLoginControl";
            }
            return _itemCustom;
        }

        public static WpfImage GetHamburgerImageImage()
        {
            if (_hamburgerImageImage == null)
            {
                _hamburgerImageImage = new WpfImage(GetItemCustom());
                _hamburgerImageImage.SearchProperties[WpfImage.PropertyNames.AutomationId] = "HamburgerImage";
            }
            return _hamburgerImageImage;
        }

        public static WpfComboBox GetUserListComboBox()
        {
            if (_userListComboBox == null)
            {
                _userListComboBox = new WpfComboBox(GetItemCustom());
                _userListComboBox.SearchProperties[WpfComboBox.PropertyNames.AutomationId] = "UserList";
            }
            return _userListComboBox;
        }

        public static WpfEdit GetPasswordFieldEdit()
        {
            if (_passwordFieldEdit == null)
            {
                _passwordFieldEdit = new WpfEdit(GetItemCustom());
                _passwordFieldEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "PasswordField";
            }
            return _passwordFieldEdit;
        }

        public static WpfButton GetLogInButton()
        {
            if (_logInButton == null)
            {
                _logInButton = new WpfButton(GetItemCustom());
                _logInButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "LoginButton";
            }
            return _logInButton;
        }

        public static WpfButton GetCancelButton()
        {
            if (_cancelButton == null)
            {
                _cancelButton = new WpfButton(GetItemCustom());
                _cancelButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "CancelButton";
            }
            return _cancelButton;
        }

    }
}
