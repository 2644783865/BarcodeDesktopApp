using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarcodeDesktopApp
{
    public class BarcodeScannedEvents
    {
        internal void OnBarcodeScanned(object sender, BarcodeEventArgs e)
        {
            BarcodeForm bcInstance = BarcodeForm.GetInstance();
            if (e.Barcode != "9916" && e.Barcode != "9918" && e.Barcode != "9917" && e.Barcode != "9999") { 
                bcInstance.lbScannedBarcodes.Items.Add(e.Barcode);
                Task.Factory.StartNew(() => LookupBarcode(e.Barcode));
            }
            bcInstance.tbScannedBarcode.Text = "";
        }

       
        private void LookupBarcode(string barcode)
        {      
                this.SetText(barcode);            
        }

        delegate void SetTextCallback(string text);
       

        private void SetText(string text)
        {
            if (BarcodeForm.GetInstance().lbDecodedBarcode.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                BarcodeForm.GetInstance().Invoke(d, new object[] { text });
            }
            else
            {
                BarcodeForm.GetInstance().lbDecodedBarcode.Items.Add(text);
            }
        }


    }



    public class BarcodeEventArgs : EventArgs
    {
        public string Barcode { get; set; }
    }


}
