namespace VaucherProcessing.Reports
{
    partial class Processed_Voucher_Report
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
            this.label_DocumentID = new System.Windows.Forms.Label();
            this.label_Printer = new System.Windows.Forms.Label();
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
            this.crystalReportViewer1.Size = new System.Drawing.Size(768, 523);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label_DocumentID
            // 
            this.label_DocumentID.AutoSize = true;
            this.label_DocumentID.Location = new System.Drawing.Point(379, 152);
            this.label_DocumentID.Name = "label_DocumentID";
            this.label_DocumentID.Size = new System.Drawing.Size(67, 13);
            this.label_DocumentID.TabIndex = 1;
            this.label_DocumentID.Text = "DocumentID";
            // 
            // label_Printer
            // 
            this.label_Printer.AutoSize = true;
            this.label_Printer.Location = new System.Drawing.Point(447, 235);
            this.label_Printer.Name = "label_Printer";
            this.label_Printer.Size = new System.Drawing.Size(37, 13);
            this.label_Printer.TabIndex = 2;
            this.label_Printer.Text = "Printer";
            // 
            // Processed_Voucher_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 523);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.label_DocumentID);
            this.Controls.Add(this.label_Printer);
            this.Name = "Processed_Voucher_Report";
            this.Text = "Processed_Voucher_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Processed_Voucher_Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label_DocumentID;
        private System.Windows.Forms.Label label_Printer;
    }
}