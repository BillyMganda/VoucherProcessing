using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;

namespace VaucherProcessing.Reports
{
    public partial class Processed_Voucher_Report : Form
    {
        ReportDocument crystal = new ReportDocument();
        
        public Processed_Voucher_Report()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }
        static string connectionstring = ConfigurationManager.ConnectionStrings["VaucherProcessing.Properties.Settings.clientSetting"].ConnectionString;

        //LOAD
        private void Processed_Voucher_Report_Load(object sender, EventArgs e)
        {
            label_DocumentID.Text = Forms.Processed_vouchers.document_Identifier;
            label_Printer.Text = Forms.Processed_vouchers.document_printer;
            //print voucher
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM WIZ_Voucher_Transaction WHERE CashSaleNumber = '" + label_DocumentID.Text + "' ", con);
                    DataSet dst = new DataSet();
                    sda.Fill(dst, "WIZ_Voucher_Transaction");
                    crystal.Load(@"C:\VoucherProcessing\Receipt.rpt");
                    crystal.SetDataSource(dst);
                    crystalReportViewer1.ReportSource = crystal;
                    crystal.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    crystal.SummaryInfo.ReportTitle = label_DocumentID.Text;
                    crystal.PrintOptions.PaperSize = PaperSize.PaperA5;
                    crystal.PrintToPrinter(1, false, 0, 0);
                    crystal.PrintOptions.NoPrinter = false;
                    crystal.PrintOptions.PrinterName = label_Printer.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
