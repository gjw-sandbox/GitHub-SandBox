using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralUtilities
{
    public class FileTransferControls
    {

        // Screen Sharing File Transfer window
        private static WinWindow _fileTransferWindow = null;
        private static WinButton _closeButton = null;
        private static WpfPane _contentFramePane = null;
        private static WpfCustom _contentAppBarCustom = null;
        private static WinWindow _selectFileWindow = null;
        private static WinWindow _selectFileCancelWindow = null;
        private static WinButton _selectFileCancelButton = null;
        private static WinWindow _selectFileItemWindow = null;
        private static WinListItem _selectFileAccountEndpointcsListItem = null;
        private static WinEdit _selectFileNameEdit = null;
        private static WinWindow _selectFileOpenWindow = null;
        private static WinButton _selectFileOpenButton = null;

        /*
         * 
         *  File Transfer windows
         *
         */

        public static WinWindow GetFileTransferWindow()
        {
            if (_fileTransferWindow == null)
            {
                _fileTransferWindow = new WinWindow();
                _fileTransferWindow.SearchProperties[WinWindow.PropertyNames.Name] = "win10 aws - File Transfer";
                _fileTransferWindow.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));

            }
            return _fileTransferWindow;
        }

        public static WinButton GetCloseButton()
        {
            if (_closeButton == null)
            {
                _closeButton = new WinButton(GetFileTransferWindow());
                _closeButton.SearchProperties[WinButton.PropertyNames.Name] = "Close";
            }
            return _closeButton;
        }

        public static WpfPane GetContentFramePane()
        {
            if (_contentFramePane == null)
            {
                _contentFramePane = new WpfPane(GetFileTransferWindow());
                _contentFramePane.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.Frame";
                _contentFramePane.SearchProperties[WpfPane.PropertyNames.AutomationId] = "ContentFrame";
            }
            return _contentFramePane;
        }

        public static WpfCustom GetAppBarCustom()
        {
            if (_contentAppBarCustom == null)
            {
                _contentAppBarCustom = new WpfCustom(GetContentFramePane());
                _contentAppBarCustom.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.AppBar";
                _contentAppBarCustom.SearchProperties[WpfControl.PropertyNames.AutomationId] = "AppBar";
            }
            return _contentAppBarCustom;
        }

        public static void ClearFileTransferControls()
        {
            _contentAppBarCustom = null;
            _contentFramePane = null;
            _closeButton = null;
            _fileTransferWindow = null;
        }

        public static WinWindow GetSelectFileWindow()
        {
            if (_selectFileWindow == null)
            {
                _selectFileWindow = new WinWindow();
                _selectFileWindow.SearchProperties[WinWindow.PropertyNames.Name] = "Select Files";
                _selectFileWindow.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32770";
            }
            return _selectFileWindow;
        }

        public static WinWindow GetSelectFileCancelWindow()
        {
            if (_selectFileCancelWindow == null)
            {
                _selectFileCancelWindow = new WinWindow(GetSelectFileWindow());
                _selectFileCancelWindow.SearchProperties[WinWindow.PropertyNames.ControlId] = "2";
            }
            return _selectFileCancelWindow;
        }

        public static WinButton GetSelectFileCancelButton()
        {
            if (_selectFileCancelButton == null)
            {
                _selectFileCancelButton = new WinButton(GetSelectFileCancelWindow());
                _selectFileCancelButton.SearchProperties[WinButton.PropertyNames.Name] = "Cancel";
            }
            return _selectFileCancelButton;
        }

        public static WinWindow GetSelectFileItemWindow()
        {
            if (_selectFileItemWindow == null)
            {
                _selectFileItemWindow = new WinWindow(GetSelectFileWindow());
                _selectFileItemWindow.SearchProperties[WinWindow.PropertyNames.AccessibleName] = "Items View";
                _selectFileItemWindow.SearchProperties[WinWindow.PropertyNames.ClassName] = "DirectUIHWND";
            }
            return _selectFileItemWindow;
        }

        public static WinListItem GetSelectFileAccountEndpointcsListItem()
        {
            if (_selectFileAccountEndpointcsListItem == null)
            {
                _selectFileAccountEndpointcsListItem = new WinListItem(GetSelectFileItemWindow());
                _selectFileAccountEndpointcsListItem.SearchProperties[WinListItem.PropertyNames.Name] = "AccountEndpoint.cs";
            }
            return _selectFileAccountEndpointcsListItem;
        }

        public static WinEdit GetSelectFileNameEdit()
        {
            if (_selectFileNameEdit == null)
            {
                _selectFileNameEdit = new WinEdit(GetSelectFileAccountEndpointcsListItem());
                _selectFileNameEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Name";
            }
            return _selectFileNameEdit;
        }

        public static WinWindow GetSelectFileOpenWindow()
        {
            if (_selectFileOpenWindow == null)
            {
                _selectFileOpenWindow = new WinWindow(GetSelectFileWindow());
                _selectFileOpenWindow.SearchProperties[WinWindow.PropertyNames.ControlId] = "1";
            }
            return _selectFileOpenWindow;
        }

        public static WinButton GetSelectFileOpenButton()
        {
            if (_selectFileOpenButton == null)
            {
                _selectFileOpenButton = new WinButton(GetSelectFileOpenWindow());
                _selectFileOpenButton.SearchProperties[WinButton.PropertyNames.Name] = "Open";
            }
            return _selectFileOpenButton;
        }



    }
}
