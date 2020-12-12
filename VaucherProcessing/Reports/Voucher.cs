using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using VaucherProcessing.Forms;

namespace VaucherProcessing.Reports
{
    public partial class Voucher : Form
    {
        ReportDocument crystal = new ReportDocument();
        public Voucher()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }
        static string connectionstring = ConfigurationManager.ConnectionStrings["VaucherProcessing.Properties.Settings.clientSetting"].ConnectionString;

        //LOAD
        private void Voucher_Load(object sender, EventArgs e)
        {
            label_DocNumber.Text = Voucher_Processing_Form.document_number;
            label_Printer.Text = Voucher_Processing_Form.printer_name;
            //print voucher
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM WIZ_Voucher_Transaction WHERE CashSaleNumber = '"+ label_DocNumber.Text + "' ", con);
                    DataSet dst = new DataSet();
                    sda.Fill(dst, "WIZ_Voucher_Transaction");
                    crystal.Load(@"C:\VoucherProcessing\Voucher_Report.rpt");
                    crystal.SetDataSource(dst);
                    crystalReportViewer1.ReportSource = crystal;
                    crystal.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    crystal.SummaryInfo.ReportTitle = label_DocNumber.Text;
                    crystal.PrintOptions.PaperSize = PaperSize.PaperA5;
                    crystal.PrintToPrinter(1, false, 0, 0);
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
