using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralUtilities
{
    public class FunctionalButtonsUtil
    {
        public static void ClickFullScreenButton()
        {
            Mouse.Location = new Point(1550, 100);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1550, 100));
            Thread.Sleep(1000);
        }

        public static void ClickExitFullScreenButton()
        {
            Mouse.Location = new Point(1550, 30);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1550, 30)); 
            Thread.Sleep(1000);
        }

        public static void ClickZoomOutButton()
        {
            Mouse.Location = new Point(1600, 100);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1600, 100));
            Thread.Sleep(1000);
        }

        public static void ClickZoomInButton()
        {
            Mouse.Location = new Point(1670, 100);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1670, 100));
            Thread.Sleep(1000);
        }

        public static void ClickSizeToFitButton()
        {
            Mouse.Location = new Point(1730, 100);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1730, 100));
            Thread.Sleep(1000);
        }

        public static void ClickCtrlAltDelButton()
        {
            Mouse.Location = new Point(1785, 100);
            Thread.Sleep(1000);
            Mouse.Click(new Point(1785, 100));
            Thread.Sleep(1000);
        }
    }
}
