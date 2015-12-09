using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeDesktopApp
{
    public class BarcodeScannedEvents
    {

        internal Boolean InternalNoteStartScan = false;
        internal Boolean InternalNoteEndScan = false;

        internal void OnBarcodeScanned(object sender, BarcodeEventArgs e)
        {
            BarcodeForm bcInstance = BarcodeForm.GetInstance();
            if (e.Barcode != "9916" && e.Barcode != "9918" && e.Barcode != "9917" && e.Barcode != "9999")
            {
                bcInstance.lbScannedBarcodes.Items.Add(e.Barcode);
                Task.Factory.StartNew(() => LookupBarcode(e.Barcode));
            }
            bcInstance.tbScannedBarcode.Text = "";
        }

        internal void OnProcessScannedCodes(object sender, EventArgs e)
        {

            ScanObject scannedObject = null;

            try
            {
                foreach (var item in BarcodeForm.GetInstance().lbScannedBarcodes.Items)
                {
                    string barcode = (string)item;
                    string switch_on = barcode.Substring(0, 1);
                    switch (switch_on)
                    {
                        case "A": // Assembly scanned
                            if (!InternalNoteStartScan)
                            {
                                throw new System.InvalidOperationException("Missed scan of delivery/galvanising note!");
                            }

                            if (scannedObject.ScannedObjects == null)
                            {
                                scannedObject.ScannedObjects = new List<ScanObjectItem>();
                            }

                            scannedObject.ScannedObjects.Add(new ScanObjectItem { ObjectID = barcode });

                            break;

                        case "G": // Galv Note Scanned
                        case "D": // Delivery Note Scanned
                            if (InternalNoteStartScan == false)
                            {
                                InternalNoteStartScan = true;
                                scannedObject = new ScanObject("Delivery Note", barcode);
                            }
                            else if (InternalNoteStartScan == true)
                            {
                                if (scannedObject.ScanObjectIdentifier != barcode)
                                {
                                    throw new System.InvalidOperationException("Start and End note scans don't match!");
                                }
                                FinaliseScannedObject(scannedObject);
                                InternalNoteStartScan = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Barcode Utility", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FinaliseScannedObject(ScanObject o)
        {
            Console.WriteLine("");
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

    public class ScanObject
    {
        public ScanObject(string type, string identifier)
        {
            this.ScanObjectType = type;
            this.ScanObjectIdentifier = identifier;
        }

        public string ScanObjectType { get; set; }
        public string ScanObjectIdentifier { get; set; }
        public List<ScanObjectItem> ScannedObjects { get; set; }
    }

    public class ScanObjectItem
    {
        public string ObjectID { get; set; }
    }

}
