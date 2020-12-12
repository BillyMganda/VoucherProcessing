namespace VaucherProcessing.Forms
{
    partial class Voucher_Processing_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Voucher_Processing_Form));
            this.comboClient = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc1 = new System.Windows.Forms.TextBox();
            this.txtDesc2 = new System.Windows.Forms.TextBox();
            this.txtDesc3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCashSaleNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAWB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboSource = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboPaymentMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEnquire = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.numericAmount = new System.Windows.Forms.NumericUpDown();
            this.comboPrinters = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPrefix = new System.Windows.Forms.Label();
            this.label_NextNumber = new System.Windows.Forms.Label();
            this.label_CustAccount = new System.Windows.Forms.Label();
            this.label_DLink = new System.Windows.Forms.Label();
            this.label_ServiceLink = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAmount)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboClient
            // 
            this.comboClient.FormattingEnabled = true;
            this.comboClient.Location = new System.Drawing.Point(15, 34);
            this.comboClient.Name = "comboClient";
            this.comboClient.Size = new System.Drawing.Size(296, 21);
            this.comboClient.TabIndex = 18;
            this.comboClient.SelectedIndexChanged += new System.EventHandler(this.comboClient_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Select Customer";
            // 
            // txtDesc1
            // 
            this.txtDesc1.Location = new System.Drawing.Point(15, 61);
            this.txtDesc1.Name = "txtDesc1";
            this.txtDesc1.Size = new System.Drawing.Size(296, 20);
            this.txtDesc1.TabIndex = 19;
            // 
            // txtDesc2
            // 
            this.txtDesc2.Location = new System.Drawing.Point(15, 87);
            this.txtDesc2.Name = "txtDesc2";
            this.txtDesc2.Size = new System.Drawing.Size(296, 20);
            this.txtDesc2.TabIndex = 20;
            // 
            // txtDesc3
            // 
            this.txtDesc3.Location = new System.Drawing.Point(15, 113);
            this.txtDesc3.Name = "txtDesc3";
            this.txtDesc3.Size = new System.Drawing.Size(296, 20);
            this.txtDesc3.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Cash Sale Number";
            // 
            // txtCashSaleNumber
            // 
            this.txtCashSaleNumber.Location = new System.Drawing.Point(359, 35);
            this.txtCashSaleNumber.Name = "txtCashSaleNumber";
            this.txtCashSaleNumber.ReadOnly = true;
            this.txtCashSaleNumber.Size = new System.Drawing.Size(265, 20);
            this.txtCashSaleNumber.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "AWB";
            // 
            // txtAWB
            // 
            this.txtAWB.Location = new System.Drawing.Point(359, 61);
            this.txtAWB.Name = "txtAWB";
            this.txtAWB.Size = new System.Drawing.Size(265, 20);
            this.txtAWB.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(359, 87);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 20);
            this.dateTimePicker1.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Select Service";
            // 
            // comboSource
            // 
            this.comboSource.FormattingEnabled = true;
            this.comboSource.Location = new System.Drawing.Point(15, 172);
            this.comboSource.Name = "comboSource";
            this.comboSource.Size = new System.Drawing.Size(296, 21);
            this.comboSource.TabIndex = 37;
            this.comboSource.SelectedIndexChanged += new System.EventHandler(this.comboSource_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Amount";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(570, 169);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 26);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Client,
            this.ServiceDescription,
            this.AccountLink,
            this.Amount});
            this.dataGridView1.Location = new System.Drawing.Point(15, 202);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(609, 135);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            // 
            // comboPaymentMode
            // 
            this.comboPaymentMode.FormattingEnabled = true;
            this.comboPaymentMode.Location = new System.Drawing.Point(107, 343);
            this.comboPaymentMode.Name = "comboPaymentMode";
            this.comboPaymentMode.Size = new System.Drawing.Size(204, 21);
            this.comboPaymentMode.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Payment Mode";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(107, 370);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(204, 20);
            this.txtReference.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 374);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Reference";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(451, 343);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(173, 20);
            this.txtTotal.TabIndex = 46;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(413, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Total";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(171, 405);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(79, 26);
            this.btnAddNew.TabIndex = 48;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(265, 405);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(79, 26);
            this.btnProcess.TabIndex = 49;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(359, 405);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(79, 26);
            this.btnPrint.TabIndex = 50;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEnquire
            // 
            this.btnEnquire.Location = new System.Drawing.Point(451, 405);
            this.btnEnquire.Name = "btnEnquire";
            this.btnEnquire.Size = new System.Drawing.Size(79, 26);
            this.btnEnquire.TabIndex = 51;
            this.btnEnquire.Text = "Enquire";
            this.btnEnquire.UseVisualStyleBackColor = true;
            this.btnEnquire.Click += new System.EventHandler(this.btnEnquire_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(545, 405);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(79, 26);
            this.btnSettings.TabIndex = 52;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // numericAmount
            // 
            this.numericAmount.Location = new System.Drawing.Point(359, 172);
            this.numericAmount.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numericAmount.Name = "numericAmount";
            this.numericAmount.Size = new System.Drawing.Size(204, 20);
            this.numericAmount.TabIndex = 53;
            // 
            // comboPrinters
            // 
            this.comboPrinters.FormattingEnabled = true;
            this.comboPrinters.Location = new System.Drawing.Point(451, 369);
            this.comboPrinters.Name = "comboPrinters";
            this.comboPrinters.Size = new System.Drawing.Size(173, 21);
            this.comboPrinters.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(402, 373);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Printers";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 26);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteRowToolStripMenuItem.Image")));
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            // 
            // txtPrefix
            // 
            this.txtPrefix.AutoSize = true;
            this.txtPrefix.Location = new System.Drawing.Point(463, 18);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(33, 13);
            this.txtPrefix.TabIndex = 57;
            this.txtPrefix.Text = "Prefix";
            this.txtPrefix.Visible = false;
            // 
            // label_NextNumber
            // 
            this.label_NextNumber.AutoSize = true;
            this.label_NextNumber.Location = new System.Drawing.Point(545, 18);
            this.label_NextNumber.Name = "label_NextNumber";
            this.label_NextNumber.Size = new System.Drawing.Size(66, 13);
            this.label_NextNumber.TabIndex = 58;
            this.label_NextNumber.Text = "NextNumber";
            this.label_NextNumber.Visible = false;
            // 
            // label_CustAccount
            // 
            this.label_CustAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CustAccount.AutoSize = true;
            this.label_CustAccount.Location = new System.Drawing.Point(116, 18);
            this.label_CustAccount.Name = "label_CustAccount";
            this.label_CustAccount.Size = new System.Drawing.Size(47, 13);
            this.label_CustAccount.TabIndex = 59;
            this.label_CustAccount.Text = "Account";
            this.label_CustAccount.Visible = false;
            // 
            // label_DLink
            // 
            this.label_DLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DLink.AutoSize = true;
            this.label_DLink.Location = new System.Drawing.Point(203, 18);
            this.label_DLink.Name = "label_DLink";
            this.label_DLink.Size = new System.Drawing.Size(35, 13);
            this.label_DLink.TabIndex = 60;
            this.label_DLink.Text = "DLink";
            this.label_DLink.Visible = false;
            // 
            // label_ServiceLink
            // 
            this.label_ServiceLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ServiceLink.AutoSize = true;
            this.label_ServiceLink.Location = new System.Drawing.Point(129, 156);
            this.label_ServiceLink.Name = "label_ServiceLink";
            this.label_ServiceLink.Size = new System.Drawing.Size(27, 13);
            this.label_ServiceLink.TabIndex = 61;
            this.label_ServiceLink.Text = "Link";
            this.label_ServiceLink.Visible = false;
            // 
            // comboType
            // 
            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(357, 113);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(267, 21);
            this.comboType.TabIndex = 62;
            this.comboType.SelectedIndexChanged += new System.EventHandler(this.comboType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(322, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 63;
            this.label11.Text = "Type";
            // 
            // Client
            // 
            this.Client.DataPropertyName = "Client";
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            this.Client.Width = 210;
            // 
            // ServiceDescription
            // 
            this.ServiceDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServiceDescription.DataPropertyName = "ServiceDescription";
            this.ServiceDescription.HeaderText = "Service";
            this.ServiceDescription.Name = "ServiceDescription";
            this.ServiceDescription.ReadOnly = true;
            // 
            // AccountLink
            // 
            this.AccountLink.DataPropertyName = "AccountLink";
            this.AccountLink.HeaderText = "Link";
            this.AccountLink.Name = "AccountLink";
            this.AccountLink.ReadOnly = true;
            this.AccountLink.Width = 70;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 70;
            // 
            // Voucher_Processing_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 443);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.label_ServiceLink);
            this.Controls.Add(this.label_DLink);
            this.Controls.Add(this.label_CustAccount);
            this.Controls.Add(this.label_NextNumber);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboPrinters);
            this.Controls.Add(this.numericAmount);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnEnquire);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboPaymentMode);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboSource);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAWB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCashSaleNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDesc3);
            this.Controls.Add(this.txtDesc2);
            this.Controls.Add(this.txtDesc1);
            this.Controls.Add(this.comboClient);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Voucher_Processing_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CASHBOOK POSTING";
            this.Load += new System.EventHandler(this.Voucher_Processing_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAmount)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc1;
        private System.Windows.Forms.TextBox txtDesc2;
        private System.Windows.Forms.TextBox txtDesc3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCashSaleNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAWB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboPaymentMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEnquire;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.NumericUpDown numericAmount;
        private System.Windows.Forms.ComboBox comboPrinters;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.Label txtPrefix;
        private System.Windows.Forms.Label label_NextNumber;
        private System.Windows.Forms.Label label_CustAccount;
        private System.Windows.Forms.Label label_DLink;
        private System.Windows.Forms.Label label_ServiceLink;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}