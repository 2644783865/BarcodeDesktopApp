﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeDesktopApp
{
    public partial class BarcodeForm : Form
    {



        public EventHandler<BarcodeEventArgs> BarcodeScanned;

        protected virtual void OnBarcodeScanned(string barCode)
        {
            // Check if there are any Subscribers
            if (BarcodeScanned != null)
            {
                // Call the Event
                BarcodeScanned(this, new BarcodeEventArgs() { Barcode = barCode } );
            }
        }

        public BarcodeForm()
        {
            InitializeComponent();
        }

        private void tbScannedBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            string barcode = "";
            if (e.KeyCode.ToString() == "Return")
            {
                barcode = this.tbScannedBarcode.Text.ToString();
                OnBarcodeScanned(barcode);
            }
        }

        // #####################################  INSTANCE  ##################

        private static BarcodeForm bcForm = null;

        // No need for locking - you'll be doing all this on the UI thread...
        public static BarcodeForm GetInstance()
        {
            if (bcForm == null)
            {
                bcForm = new BarcodeForm();
                bcForm.FormClosed += delegate { bcForm = null; };
            }
            return bcForm;
        }


    }
}