using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeDesktopApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Start());

            BarcodeForm bcScanner = BarcodeForm.GetInstance(); // Publisher
            BarcodeScannedEvents eventHelper = new BarcodeScannedEvents(); // Subscriber

            bcScanner.BarcodeScanned += eventHelper.OnBarcodeScanned;
            bcScanner.ShowDialog();
        }
    }
}
