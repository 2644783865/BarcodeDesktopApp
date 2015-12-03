using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeDesktopApp
{
    public class BarcodeScannedEvents
    {
        internal void OnBarcodeScanned(object sender, BarcodeEventArgs e)
        {
            BarcodeForm bcInstance = BarcodeForm.GetInstance();
            bcInstance.lbScannedBarcodes.Items.Add(e.Barcode);
            bcInstance.tbScannedBarcode.Text = "";

            Task.Factory.StartNew(() => LookupBarcode(e.Barcode));
        }

        private static void LookupBarcode(string barcode)
        {
            BarcodeForm.GetInstance().lbDecodedBarcode.Items.Add(barcode);
        }


    }

    

    public class BarcodeEventArgs : EventArgs
    {
        public string Barcode { get; set; }
    }


}
