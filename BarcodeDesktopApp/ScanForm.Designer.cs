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
            this.gbScanWhere = new System.Windows.Forms.GroupBox();
            this.rbRigging = new System.Windows.Forms.RadioButton();
            this.rbDispatch = new System.Windows.Forms.RadioButton();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.lbStockStatus = new System.Windows.Forms.ListBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbScanWhere.SuspendLayout();
            this.gbStatus.SuspendLayout();
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
            this.tbScannedBarcode.Size = new System.Drawing.Size(657, 32);
            this.tbScannedBarcode.TabIndex = 0;
            this.tbScannedBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbScannedBarcode_KeyDown);
            this.tbScannedBarcode.Leave += new System.EventHandler(this.tbScannedBarcode_Leave);
            // 
            // lbScannedBarcodes
            // 
            this.lbScannedBarcodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScannedBarcodes.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScannedBarcodes.FormattingEnabled = true;
            this.lbScannedBarcodes.ItemHeight = 22;
            this.lbScannedBarcodes.Location = new System.Drawing.Point(0, 0);
            this.lbScannedBarcodes.Name = "lbScannedBarcodes";
            this.lbScannedBarcodes.Size = new System.Drawing.Size(218, 474);
            this.lbScannedBarcodes.TabIndex = 1;
            this.lbScannedBarcodes.TabStop = false;
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
            this.splitContainer1.Size = new System.Drawing.Size(657, 474);
            this.splitContainer1.SplitterDistance = 218;
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
            this.lbDecodedBarcode.Size = new System.Drawing.Size(435, 474);
            this.lbDecodedBarcode.TabIndex = 0;
            this.lbDecodedBarcode.TabStop = false;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(907, 571);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(149, 47);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // gbScanWhere
            // 
            this.gbScanWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbScanWhere.BackColor = System.Drawing.Color.Transparent;
            this.gbScanWhere.Controls.Add(this.rbRigging);
            this.gbScanWhere.Controls.Add(this.rbDispatch);
            this.gbScanWhere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbScanWhere.Location = new System.Drawing.Point(12, 530);
            this.gbScanWhere.Name = "gbScanWhere";
            this.gbScanWhere.Size = new System.Drawing.Size(171, 88);
            this.gbScanWhere.TabIndex = 5;
            this.gbScanWhere.TabStop = false;
            this.gbScanWhere.Text = "Scan Type";
            // 
            // rbRigging
            // 
            this.rbRigging.AutoSize = true;
            this.rbRigging.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRigging.Location = new System.Drawing.Point(17, 56);
            this.rbRigging.Name = "rbRigging";
            this.rbRigging.Size = new System.Drawing.Size(62, 20);
            this.rbRigging.TabIndex = 4;
            this.rbRigging.Text = "Rigging";
            this.rbRigging.UseVisualStyleBackColor = true;
            // 
            // rbDispatch
            // 
            this.rbDispatch.AutoSize = true;
            this.rbDispatch.Checked = true;
            this.rbDispatch.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDispatch.Location = new System.Drawing.Point(17, 30);
            this.rbDispatch.Name = "rbDispatch";
            this.rbDispatch.Size = new System.Drawing.Size(70, 20);
            this.rbDispatch.TabIndex = 3;
            this.rbDispatch.TabStop = true;
            this.rbDispatch.Text = "Dispatch";
            this.rbDispatch.UseVisualStyleBackColor = true;
            // 
            // gbStatus
            // 
            this.gbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatus.Controls.Add(this.btnCalculate);
            this.gbStatus.Controls.Add(this.lbStockStatus);
            this.gbStatus.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStatus.Location = new System.Drawing.Point(675, 12);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(380, 512);
            this.gbStatus.TabIndex = 6;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Stock Status";
            // 
            // lbStockStatus
            // 
            this.lbStockStatus.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStockStatus.FormattingEnabled = true;
            this.lbStockStatus.ItemHeight = 22;
            this.lbStockStatus.Location = new System.Drawing.Point(17, 38);
            this.lbStockStatus.Name = "lbStockStatus";
            this.lbStockStatus.Size = new System.Drawing.Size(343, 400);
            this.lbStockStatus.TabIndex = 0;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(211, 450);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(149, 47);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // BarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 630);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.gbScanWhere);
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
            this.gbScanWhere.ResumeLayout(false);
            this.gbScanWhere.PerformLayout();
            this.gbStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.ListBox lbScannedBarcodes;
        internal System.Windows.Forms.TextBox tbScannedBarcode;
        internal System.Windows.Forms.ListBox lbDecodedBarcode;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.GroupBox gbScanWhere;
        private System.Windows.Forms.RadioButton rbRigging;
        private System.Windows.Forms.RadioButton rbDispatch;
        private System.Windows.Forms.GroupBox gbStatus;
        internal System.Windows.Forms.ListBox lbStockStatus;
        private System.Windows.Forms.Button btnCalculate;
    }
}

