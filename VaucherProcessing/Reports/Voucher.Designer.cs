namespace VaucherProcessing.Reports
{
    partial class Voucher
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label_Printer = new System.Windows.Forms.Label();
            this.label_DocNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowCopyButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowZoomButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 514);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label_Printer
            // 
            this.label_Printer.AutoSize = true;
            this.label_Printer.Location = new System.Drawing.Point(325, 256);
            this.label_Printer.Name = "label_Printer";
            this.label_Printer.Size = new System.Drawing.Size(37, 13);
            this.label_Printer.TabIndex = 2;
            this.label_Printer.Text = "Printer";
            // 
            // label_DocNumber
            // 
            this.label_DocNumber.AutoSize = true;
            this.label_DocNumber.Location = new System.Drawing.Point(325, 158);
            this.label_DocNumber.Name = "label_DocNumber";
            this.label_DocNumber.Size = new System.Drawing.Size(64, 13);
            this.label_DocNumber.TabIndex = 3;
            this.label_DocNumber.Text = "DocNumber";
            // 
            // Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.label_Printer);
            this.Controls.Add(this.label_DocNumber);
            this.Name = "Voucher";
            this.Text = "Voucher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Voucher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label_Printer;
        private System.Windows.Forms.Label label_DocNumber;
    }
}