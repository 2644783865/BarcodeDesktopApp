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
            bcInstance.lbScannedBarcodes.Items.Add(e.Barcode);
            bcInstance.tbScannedBarcode.Text = "";

            Task.Factory.StartNew(() => LookupBarcode(e.Barcode));


        }

        //static CancellationTokenSource cts = new CancellationTokenSource();

        //static TaskFactory factory = new TaskFactory(
        //   cts.Token,
        //   TaskCreationOptions.PreferFairness,
        //   TaskContinuationOptions.ExecuteSynchronously, 
        //   null);

        private void LookupBarcode(string barcode)
        {
            string res = "";
            for (long i = 0; i < 500000; i++)
            {
                Random rnd = new Random();
                int month = rnd.Next(1, 13);
                res = string.Format("Bacode{0} Rnd{1}", barcode, month);
            }
            this.SetText(res);
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
