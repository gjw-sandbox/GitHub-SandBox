using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITesting;
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

namespace DesktopApp
{
    class FileTransferTest
    {
        private static void ConnectToHost()
        {
            GeneralUtilities.LoginConnectUtil.LaunchDA();
            GeneralUtilities.LoginConnectUtil.LoginDA();
            GeneralUtilities.LoginConnectUtil.ConnectHost("Joker");

        }
        private static void DisconnectFromHost()
        {
            GeneralUtilities.LoginConnectUtil.DisconnectHost();
            GeneralUtilities.LoginConnectUtil.LogoutDA();
            GeneralUtilities.LoginConnectUtil.CloseDA();
        }

        public static void FileTransfer_Open_Close()
        {
            ConnectToHost();
            GeneralUtilities.FileTransferUtil.OpenFileTransfer();
            GeneralUtilities.FileTransferUtil.CloseFileTransfer();
            DisconnectFromHost();
        }

        public static void FileTransfer_Upload_Files()
        {
            ConnectToHost();

            GeneralUtilities.FileTransferUtil.OpenFileTransfer();

            WpfCustom appBarCustom = GeneralUtilities.FileTransferControls.GetAppBarCustom();
            Mouse.Click(appBarCustom, new Point(481, 28));
            Thread.Sleep(1000);

            // root folder that cannot have files uploaded
            WpfButton okButton = new WpfButton(GeneralUtilities.FileTransferControls.GetFileTransferWindow());
            okButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "OkButton";
            Thread.Sleep(1000);
            Mouse.Click(okButton, new Point(30, 19));

            // move to other folders, 1st level folder
            WpfCustom folderListCustom1 = new WpfCustom(GeneralUtilities.FileTransferControls.GetFileTransferWindow());
            folderListCustom1.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.FolderListControl";
            folderListCustom1.SearchProperties[WpfControl.PropertyNames.AutomationId] = "FolderList";

            WpfTable fullListTable = new WpfTable(folderListCustom1);
            fullListTable.SearchProperties[WpfTable.PropertyNames.AutomationId] = "FullList";

            WpfControl itemDataItem1 = new WpfControl(fullListTable);
            itemDataItem1.SearchProperties[WpfControl.PropertyNames.ControlType] = "DataItem";
            itemDataItem1.SearchProperties[WpfControl.PropertyNames.Instance] = "3";

            WpfCell itemCell = new WpfCell(itemDataItem1);
            itemCell.SearchProperties[WpfCell.PropertyNames.ColumnHeader] = "FILE NAME";

            Mouse.DoubleClick(itemCell, new Point(37, 18));
            Thread.Sleep(2000);

            // 2nd level folder, **** need to clean the old controls (the way CodedUI/SC do) and start new ones as following
            GeneralUtilities.FileTransferControls.ClearFileTransferControls();

            WpfCustom folderListCustom2 = new WpfCustom(GeneralUtilities.FileTransferControls.GetFileTransferWindow());
            folderListCustom2.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.FolderListControl";
            folderListCustom2.SearchProperties[WpfControl.PropertyNames.AutomationId] = "FolderList";

            WpfTable fullListTable2 = new WpfTable(folderListCustom2);
            fullListTable2.SearchProperties[WpfTable.PropertyNames.AutomationId] = "FullList";

            WpfControl itemDataItem2 = new WpfControl(fullListTable2);
            itemDataItem2.SearchProperties[WpfControl.PropertyNames.ControlType] = "DataItem";

            WpfCell itemCell2 = new WpfCell(itemDataItem2);
            itemCell2.SearchProperties[WpfCell.PropertyNames.ColumnHeader] = "FILE NAME";
   
            Mouse.DoubleClick(itemCell2, new Point(59, 15));
            Thread.Sleep(2000);

            // click Upload button
            appBarCustom = GeneralUtilities.FileTransferControls.GetAppBarCustom();
            Mouse.Click(appBarCustom, new Point(481, 28));
            Thread.Sleep(1000);

            // make sure "Select File" window is up
            WinWindow selectFilesWindow = GeneralUtilities.FileTransferControls.GetSelectFileWindow();
            Thread.Sleep(1000);
            Assert.IsTrue(selectFilesWindow.Exists, "Select File Window does not show up!");

            // Select a file
            WinEdit nameEdit = GeneralUtilities.FileTransferControls.GetSelectFileNameEdit();
            Mouse.Click(nameEdit, new Point(123, 15));

            // Open/load the file
            WinButton openButton = GeneralUtilities.FileTransferControls.GetSelectFileOpenButton();
            Mouse.Click(openButton, new Point(24, 9));
            Thread.Sleep(3000);

            // xxxx make sure the file is there, may use FT window move arounf directories then come back to verify it

            WpfButton homeButton = new WpfButton(GeneralUtilities.FileTransferControls.GetFileTransferWindow());
            homeButton.SearchProperties[WpfButton.PropertyNames.Name] = "Home";
            Mouse.Click(homeButton, new Point(14, 9));
            Thread.Sleep(2000);

            GeneralUtilities.FileTransferUtil.CloseFileTransfer();
            Thread.Sleep(1000);

            // Clean up the files under the upload directory
            // launch command window on host and run batch
            Keyboard.SendKeys("R", System.Windows.Input.ModifierKeys.Windows);
            Thread.Sleep(1000);
            Keyboard.SendKeys("cmd");
            Thread.Sleep(1000);
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(1000);
            Keyboard.SendKeys("cd C:\\ShareConnect");
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(1000);
            Keyboard.SendKeys("DeleteFiles.bat");
            Keyboard.SendKeys("{ENTER}");
            Thread.Sleep(1000);
            Keyboard.SendKeys("exit");
            Keyboard.SendKeys("{ENTER}");

            DisconnectFromHost();
        }


        public static void FileTransfer_Download_files()
        {
            ConnectToHost();
            GeneralUtilities.FileTransferUtil.OpenFileTransfer();



            GeneralUtilities.FileTransferUtil.CloseFileTransfer();
            Thread.Sleep(1000);

            DisconnectFromHost();
        }

    }
}
