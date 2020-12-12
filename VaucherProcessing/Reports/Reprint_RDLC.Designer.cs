namespace VaucherProcessing.Reports
{
    partial class Reprint_RDLC
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
            this.lbl_DocID = new System.Windows.Forms.Label();
            this.lbl_Printer = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // lbl_DocID
            // 
            this.lbl_DocID.AutoSize = true;
            this.lbl_DocID.Location = new System.Drawing.Point(383, 121);
            this.lbl_DocID.Name = "lbl_DocID";
            this.lbl_DocID.Size = new System.Drawing.Size(44, 13);
            this.lbl_DocID.TabIndex = 0;
            this.lbl_DocID.Text = "Doc_ID";
            // 
            // lbl_Printer
            // 
            this.lbl_Printer.AutoSize = true;
            this.lbl_Printer.Location = new System.Drawing.Point(383, 170);
            this.lbl_Printer.Name = "lbl_Printer";
            this.lbl_Printer.Size = new System.Drawing.Size(37, 13);
            this.lbl_Printer.TabIndex = 1;
            this.lbl_Printer.Text = "Printer";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // Reprint_RDLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 401);
            this.Controls.Add(this.lbl_Printer);
            this.Controls.Add(this.lbl_DocID);
            this.Name = "Reprint_RDLC";
            this.Text = "Reprint_RDLC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reprint_RDLC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_DocID;
        private System.Windows.Forms.Label lbl_Printer;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}