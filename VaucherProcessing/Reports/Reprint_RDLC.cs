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
using Microsoft.Reporting.WinForms;

namespace VaucherProcessing.Reports
{
    public partial class Reprint_RDLC : Form
    {
        public Reprint_RDLC()
        {
            InitializeComponent();            
        }
        static string connectionstring = ConfigurationManager.ConnectionStrings["VaucherProcessing.Properties.Settings.clientSetting"].ConnectionString;

        //LOAD
        private void Reprint_RDLC_Load(object sender, EventArgs e)
        {
            lbl_DocID.Text = Forms.Processed_vouchers.document_Identifier;
            lbl_Printer.Text = Forms.Processed_vouchers.document_printer;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM WIZ_Voucher_Transaction WHERE CashSaleNumber = '" + lbl_DocID.Text + "' ", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ReportDataSource rds = new ReportDataSource("Final_Dataset", dt);
                    reportViewer1.LocalReport.ReportPath = @"C:\VoucherProcessing\Reprint_Report.rdlc";
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.RefreshReport();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
