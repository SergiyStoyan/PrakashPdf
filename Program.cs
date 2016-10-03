//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Cliver.PrakashPdf
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                InternetDateTime.CHECK_TEST_PERIOD_VALIDITY(2016, 10, 5, false);
                MainForm mf = new MainForm();
                Application.Run(mf);
            }
            catch (Exception e)
            {
                Message.Error(e);
            }
        }
    }
}