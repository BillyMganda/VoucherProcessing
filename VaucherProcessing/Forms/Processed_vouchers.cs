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
using VaucherProcessing.Reports;
using System.Drawing.Printing;

namespace VaucherProcessing.Forms
{
    public partial class Processed_vouchers : Form
    {
        public Processed_vouchers()
        {
            InitializeComponent();
        }
        static string connectionstring = ConfigurationManager.ConnectionStrings["VaucherProcessing.Properties.Settings.clientSetting"].ConnectionString;

     
        //LOAD BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    string query = "SELECT CashSaleNumber,ClientName,ClientAccount,DocType,Date,Amount FROM WIZ_Voucher_Transaction WHERE Date = '" +Convert.ToDateTime(dateTimePicker1.Text)+ "' ";
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    sqlData.Fill(ds, "WIZ_Voucher_Transaction");
                    dataGridView1.DataSource = ds.Tables["WIZ_Voucher_Transaction"].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
        //LOAD TRANSACTIONS
        public void loadAllTransactions()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    string query = "SELECT CashSaleNumber,ClientName,ClientAccount,DocType,Date,Amount FROM WIZ_Voucher_Transaction ORDER BY Date DESC";
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    sqlData.Fill(ds, "WIZ_Voucher_Transaction");
                    dataGridView1.DataSource = ds.Tables["WIZ_Voucher_Transaction"].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD PRINTERS
        public void loadPrinters()
        {
           try
            {
                PrintDocument prtdoc = new PrintDocument();
                string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
                foreach (String strPrinter in PrinterSettings.InstalledPrinters)
                {
                    comboPrinter.Items.Add(strPrinter);
                    if (strPrinter == strDefaultPrinter)
                    {
                        comboPrinter.SelectedIndex = comboPrinter.Items.IndexOf(strPrinter);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD FORM
        private void Processed_vouchers_Load_1(object sender, EventArgs e)
        {
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            loadPrinters();
            loadAllTransactions();
        }
        //SINGLE CLICK TO PRINT       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
        }

        //PRINT      
        public static string document_Identifier = "";
        public static string document_printer = "";
        private int rowIndex = 0;
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {                
                document_Identifier = label_ID.Text;
                document_printer = comboPrinter.Text;

                //Reprint_RDLC RDLC = new Reprint_RDLC();
                //RDLC.Show();

                Processed_Voucher_Report _Report = new Processed_Voucher_Report();
                _Report.Show();
            }
        }
    }
}
