using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralUtilities
{
    public class DesktopAppControls
    {
        // Desktop App window
        private static WinWindow _shareConnectWindow = null;
        private static WpfPane _loginFramePane = null;
        private static WpfPane _browserPanel = null;
        private static WinClient _itemClient = null;
        private static HtmlDocument _shareFileLoginDocument = null;
        private static HtmlEdit _credentialsEmailEdit = null;
        private static HtmlEdit _credentialsPasswordEdit = null;
        private static HtmlDiv _applicationHostPane = null;
        private static HtmlButton _signInButton = null;
        private static HtmlButton _loginwithmycompanycrButton = null;
        private static HtmlSpan _loginwithmycompanycrPane = null;
        private static HtmlButton _forgotPasswordButton = null;
        private static HtmlHyperlink _privacyPolicyHyperlink = null;


        private static WpfCustom _bladeViewControlCustom = null;
        private static WpfImage _settings_buttonImage = null;
        private static WpfCustom _settingBladeCustom = null;
        private static WpfCustom _aboutBladeCustom = null;
        private static WpfButton _confirmSignOutYesButton = null;

        private static WpfButton _closeButton = null;


        /*
         * 
         *  Desktop App windows
         *
         */

        public static WinWindow GetShareConnectWindow()
        {
            if (_shareConnectWindow == null)
            {
                _shareConnectWindow = new WinWindow();
                _shareConnectWindow.SearchProperties[WinWindow.PropertyNames.Name] = "ShareConnect";
                _shareConnectWindow.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            }
            return _shareConnectWindow;
        }

        public static WpfPane GetLoginFramePane()
        {
            if (_loginFramePane == null)
            {
                _loginFramePane = new WpfPane(GetShareConnectWindow());
                _loginFramePane.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.Frame";
                _loginFramePane.SearchProperties[WpfPane.PropertyNames.AutomationId] = "LoginFrame";

            }
            return _loginFramePane;
        }

        public static WpfPane GetBrowserPanel()
        {
            if (_browserPanel == null)
            {
                _browserPanel = new WpfPane(GetLoginFramePane());
                _browserPanel.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.HwndHost";
                _browserPanel.SearchProperties[WpfPane.PropertyNames.AutomationId] = "Browser";
            }
            return _browserPanel;
        }

        public static WinClient GetItemClient()
        {
            if (_itemClient == null)
            {
                _itemClient = new WinClient(GetBrowserPanel());
                _itemClient.SearchProperties[WinControl.PropertyNames.ClassName] = "Internet Explorer_Server";
            }
            return _itemClient;
        }

        public static HtmlDocument GetShareFileLoginDocument()
        {
            if (_shareFileLoginDocument == null)
            {
                _shareFileLoginDocument = new HtmlDocument(GetItemClient());
                _shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.Title] = "ShareFile Login";
                _shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/oauth/authorize";
                _shareFileLoginDocument.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "https://secure.sharefiletest.com/oauth/authorize?response_type=code&client_id=RrB" +
                    "QuHuM12dWToUvOHaEpNK3OTgmxGgd&redirect_uri=https:%2F%2Fi1app.sc.test.expertcity." +
                    "com%2Fmembers%2FsocialLogin.tmpl%3FauthProvider%3DshareFile&state=&theme=airtop";
            }
            return _shareFileLoginDocument;
        }

        public static HtmlEdit GetCredentialsEmailEdit()
        {
            if (_credentialsEmailEdit == null)
            {
                _credentialsEmailEdit = new HtmlEdit(GetShareFileLoginDocument());
                _credentialsEmailEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "credentials-email";
                _credentialsEmailEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "txtinput username input-item";
                _credentialsEmailEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "tabindex=\"1\" class=\"txtinput username in";
                _credentialsEmailEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "2";
            }
            return _credentialsEmailEdit;
        }

        public static HtmlEdit GetCredentialsPasswordEdit()
        {
            if (_credentialsPasswordEdit == null)
            {
                _credentialsPasswordEdit = new HtmlEdit(GetShareFileLoginDocument());
                _credentialsPasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "credentials-password";
                _credentialsPasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Type] = "PASSWORD";
                _credentialsPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "txtinput password input-item";
                _credentialsPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "tabindex=\"2\" class=\"txtinput password in";
                _credentialsPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "3";
            }
            return _credentialsPasswordEdit;
        }

        public static HtmlButton GetLoginwithmycompanycrButton()
        {
            if (_loginwithmycompanycrButton == null)
            {
                _loginwithmycompanycrButton = new HtmlButton(GetShareFileLoginDocument());
                _loginwithmycompanycrButton.SearchProperties[HtmlButton.PropertyNames.Id] = "link-company-credentials";
                _loginwithmycompanycrButton.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "Log in with my company credentials ";
                _loginwithmycompanycrButton.SearchProperties[HtmlButton.PropertyNames.Type] = "submit";
                _loginwithmycompanycrButton.FilterProperties[HtmlButton.PropertyNames.Class] = "tertiary-action-link txt";
                _loginwithmycompanycrButton.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "tabindex=\"4\" class=\"tertiary-action-link";
                _loginwithmycompanycrButton.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "3";
            }
            return _loginwithmycompanycrButton;
        }

        public static HtmlSpan GetLoginwithmycompanycrPane()
        {
            if (_loginwithmycompanycrPane == null)
            {
                _loginwithmycompanycrPane = new HtmlSpan(GetLoginwithmycompanycrButton());
                _loginwithmycompanycrPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Log in with my company credentials";
                _loginwithmycompanycrPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "data-i18n=\"company_credentials\"";
                _loginwithmycompanycrPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "4";
            }
            return _loginwithmycompanycrPane;
        }

        public static HtmlButton GetForgotPasswordButton()
        {
            if (_forgotPasswordButton == null)
            {
                _forgotPasswordButton = new HtmlButton(GetShareFileLoginDocument());
                _forgotPasswordButton.SearchProperties[HtmlButton.PropertyNames.Id] = "link-forgot-password";
                _forgotPasswordButton.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "Forgot Password?";
                _forgotPasswordButton.SearchProperties[HtmlButton.PropertyNames.Type] = "submit";
                _forgotPasswordButton.FilterProperties[HtmlButton.PropertyNames.Class] = "tertiary-action-link txt";
                _forgotPasswordButton.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "tabindex=\"5\" class=\"tertiary-action-link";
                _forgotPasswordButton.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "4";
            }
            return _forgotPasswordButton;
        }

        public static HtmlHyperlink GetPrivacyPolicyHyperlink()
        {
            if (_privacyPolicyHyperlink == null)
            {
                _privacyPolicyHyperlink = new HtmlHyperlink(GetShareFileLoginDocument());
                _privacyPolicyHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.Id] = "link-privacy-policy";
                _privacyPolicyHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.Target] = "_blank";
                _privacyPolicyHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "Privacy Policy";
                _privacyPolicyHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.AbsolutePath] = "/_Auth/PrivacyPolicy/en.html";
                _privacyPolicyHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.Href] = "https://secure.sharefiletest.com/_Auth/PrivacyPolicy/en.html";
                _privacyPolicyHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.Class] = "tertiary-action-link";
                _privacyPolicyHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.ControlDefinition] = "tabindex=\"6\" class=\"tertiary-action-link";
                _privacyPolicyHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.TagInstance] = "1";
            }
            return _privacyPolicyHyperlink;
        }


        public static HtmlDiv GetApplicationHostPane()
        {
            if (_applicationHostPane == null)
            {
                _applicationHostPane = new HtmlDiv(GetShareFileLoginDocument());
                _applicationHostPane.SearchProperties[HtmlDiv.PropertyNames.Id] = "applicationHost";
                _applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Sign In using your ShareFile account\r\n\r\n";
                _applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "id=\"applicationHost\"";
                _applicationHostPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "15";

            }
            return _applicationHostPane;
        }

        public static HtmlButton GetSignInButton()
        {
            if (_signInButton == null)
            {
                _signInButton = new HtmlButton(GetApplicationHostPane());
                _signInButton.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "Sign In  ";
                _signInButton.SearchProperties[HtmlButton.PropertyNames.Type] = "submit";
                _signInButton.FilterProperties[HtmlButton.PropertyNames.Class] = "navlink fwdlink";
                _signInButton.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "class=\"navlink fwdlink\" type=\"submit\" da";
                _signInButton.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "1";

            }
            return _signInButton;
        }

        public static WpfButton GetDesktopAppCloseButtonX()
        {
            if (_closeButton == null)
            {
                _closeButton = new WpfButton(GetShareConnectWindow());
                _closeButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "Close";
            }
            return _closeButton;
        }

        public static WpfCustom GetBladeViewControlCustom()
        {
            if (_bladeViewControlCustom == null)
            {
                _bladeViewControlCustom = new WpfCustom(GetShareConnectWindow());
                _bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.MultiSessionBladeView";
                _bladeViewControlCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "BladeViewControl";
            }
            return _bladeViewControlCustom;
        }

        public static WpfImage GetSettings_buttonImage()
        {
            if (_settings_buttonImage == null)
            {
                _settings_buttonImage = new WpfImage(GetBladeViewControlCustom());
                _settings_buttonImage.SearchProperties[WpfImage.PropertyNames.AutomationId] = "Settings_button";
            }
            return _settings_buttonImage;
        }

        public static WpfCustom GetSettingBladeCustom()
        {
            if (_settingBladeCustom == null)
            {
                _settingBladeCustom = new WpfCustom(GetShareConnectWindow());
                _settingBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.SettingsBlade";
                _settingBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "SettingBlade";
            }
            return _settingBladeCustom;
        }

        public static WpfCustom GetAboutBladeCustom()
        {
            if (_aboutBladeCustom == null)
            {
                _aboutBladeCustom = new WpfCustom(GetSettingBladeCustom());
                _aboutBladeCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.AboutBlade";
                _aboutBladeCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "AboutBlade";

            }
            return _aboutBladeCustom;
        }

        public static WpfButton GetConfirmSignOutYesButton()
        {
            if (_confirmSignOutYesButton == null)
            {
                _confirmSignOutYesButton = new WpfButton(GetShareConnectWindow());
                _confirmSignOutYesButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "OkButton";

            }
            return _confirmSignOutYesButton;
        }
        
    }
}
