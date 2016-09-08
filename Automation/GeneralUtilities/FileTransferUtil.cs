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

namespace GeneralUtilities
{
    public class FileTransferUtil
    {
        public static void OpenFileTransfer()
        {
            Logger.log.Info("******  Start OpenFileTransfer() ********");

            Mouse.Location = new Point(1500, 100);  // file transfer
            Thread.Sleep(1000);
            Mouse.Click(new Point(1500, 100));
            Thread.Sleep(3000);

            Logger.log.Info("******  End OpenFileTransfer() ********");
        }

        public static void CloseFileTransfer()
        {
            WinButton closeButton = FileTransferControls.GetCloseButton();

            Mouse.Click(closeButton, new Point(19, 11));
            Thread.Sleep(1000);
        }
    }
}
