namespace BarcodeDesktopApp
{
    partial class BarcodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbScannedBarcode = new System.Windows.Forms.TextBox();
            this.lbScannedBarcodes = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbDecodedBarcode = new System.Windows.Forms.ListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbScannedBarcode
            // 
            this.tbScannedBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScannedBarcode.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScannedBarcode.ForeColor = System.Drawing.Color.Crimson;
            this.tbScannedBarcode.Location = new System.Drawing.Point(12, 12);
            this.tbScannedBarcode.Name = "tbScannedBarcode";
            this.tbScannedBarcode.Size = new System.Drawing.Size(631, 32);
            this.tbScannedBarcode.TabIndex = 0;
            this.tbScannedBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbScannedBarcode_KeyDown);
            // 
            // lbScannedBarcodes
            // 
            this.lbScannedBarcodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScannedBarcodes.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScannedBarcodes.FormattingEnabled = true;
            this.lbScannedBarcodes.ItemHeight = 22;
            this.lbScannedBarcodes.Location = new System.Drawing.Point(0, 0);
            this.lbScannedBarcodes.Name = "lbScannedBarcodes";
            this.lbScannedBarcodes.Size = new System.Drawing.Size(210, 512);
            this.lbScannedBarcodes.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbScannedBarcodes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbDecodedBarcode);
            this.splitContainer1.Size = new System.Drawing.Size(631, 512);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 2;
            // 
            // lbDecodedBarcode
            // 
            this.lbDecodedBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDecodedBarcode.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDecodedBarcode.FormattingEnabled = true;
            this.lbDecodedBarcode.ItemHeight = 22;
            this.lbDecodedBarcode.Location = new System.Drawing.Point(0, 0);
            this.lbDecodedBarcode.Name = "lbDecodedBarcode";
            this.lbDecodedBarcode.Size = new System.Drawing.Size(417, 512);
            this.lbDecodedBarcode.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(494, 568);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(149, 47);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // BarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 627);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tbScannedBarcode);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BarcodeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode App";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.ListBox lbScannedBarcodes;
        internal System.Windows.Forms.TextBox tbScannedBarcode;
        internal System.Windows.Forms.ListBox lbDecodedBarcode;
        private System.Windows.Forms.Button btnProcess;
    }
}

