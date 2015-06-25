using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RSDLCTagger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException
 += delegate(object sender, UnhandledExceptionEventArgs args)
 {
     var exception = (Exception)args.ExceptionObject;
     MessageBox.Show("Exception: " + exception);
 };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
