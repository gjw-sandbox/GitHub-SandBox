using Microsoft.VisualStudio.TestTools.UITesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesktopApp
{
    class FunctionButtonsBasicTest
    {
        public static void Click_FileTransfer_Button()
        {
            //GeneralUtilities.FunctionalButtonsUtil.OpenFileTransfer();
            //GeneralUtilities.FunctionalButtonsUtil.CloseFileTransfer();
        }

        public static void Click_FullScreen_Button()
        {
            GeneralUtilities.FunctionalButtonsUtil.ClickFullScreenButton();
        }

        public static void Click_ExitFullScreen_Button()
        {
            GeneralUtilities.FunctionalButtonsUtil.ClickExitFullScreenButton();
        }

        public static void Click_ZoomOut_Button()
        {
            GeneralUtilities.FunctionalButtonsUtil.ClickZoomOutButton();
        }

        public static void Click_ZoomIn_Button()
        {
            GeneralUtilities.FunctionalButtonsUtil.ClickZoomInButton();
        }

        public static void Click_SizeToFit_Button()
        {
            GeneralUtilities.FunctionalButtonsUtil.ClickSizeToFitButton();
        }

        public static void Click_CtrlAltDel_Button()
        {
            GeneralUtilities.FunctionalButtonsUtil.ClickCtrlAltDelButton();
        }

    }
}
