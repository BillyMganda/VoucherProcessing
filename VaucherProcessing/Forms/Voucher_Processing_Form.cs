using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaucherProcessing.Reports;

namespace VaucherProcessing.Forms
{
    public partial class Voucher_Processing_Form : Form
    {
        public Voucher_Processing_Form()
        {
            InitializeComponent();
        }
        static string connectionstring = ConfigurationManager.ConnectionStrings["VaucherProcessing.Properties.Settings.clientSetting"].ConnectionString;
        //LOAD PRINTERS
        public void loadPrinters()
        {
            try
            {
                PrintDocument prtdoc = new PrintDocument();
                string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
                foreach (String strPrinter in PrinterSettings.InstalledPrinters)
                {
                    comboPrinters.Items.Add(strPrinter);
                    if (strPrinter == strDefaultPrinter)
                    {
                        comboPrinters.SelectedIndex = comboPrinters.Items.IndexOf(strPrinter);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD SERVICE
        public void loadService()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT AccountLink, Description from Accounts Where iAllowICSales = 1 and ActiveAccount = 1 Order By Description";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboSource.Items.Add(dr["Description"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD PAYMENT MODES
        public void loadPaymentModes()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT DISTINCT PaymentMode FROM WIZ_Voucher_PmtModes";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboPaymentMode.Items.Add(dr["PaymentMode"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD CUSTOMER
        public void loadCustomer()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Client";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboClient.Items.Add(dr["Name"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD DOC TYPE
        public void loadDocumentType()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT DISTINCT DocName FROM WIZ_Voucher_Type WHERE Active = 'True' ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboType.Items.Add(dr["DocName"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD FORM
        private void Voucher_Processing_Form_Load(object sender, EventArgs e)
        {
            loadDocumentType();
            loadPrinters();
            loadService();
            loadCustomer();
            loadPaymentModes();
        }
        //ADD BUTTON
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(comboClient.Text == "" || comboSource.Text == "" || txtAWB.Text == "" || comboType.Text == "")
            {
                MessageBox.Show("Fill all necessary fields to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string[] row = { comboClient.Text, comboSource.Text, label_ServiceLink.Text, numericAmount.Value.ToString() };
                    dataGridView1.Rows.Add(row);
                    calculationInDatagrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //DELETE ROW ITEM
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
                this.dataGridView1.Rows.RemoveAt(this.rowIndex);
                calculationInDatagrid();
            }
        }      

        private void comboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillServiceLink();
            //loadNextNumber();
            //processingID();            
        }
        //ENQUIRE
        private void btnEnquire_Click(object sender, EventArgs e)
        {
            Processed_vouchers pv = new Processed_vouchers();
            pv.ShowDialog();
        }
        //ADD NEW
        private void btnAddNew_Click(object sender, EventArgs e)
        {            
            txtDesc1.Text = "";
            txtDesc2.Text = "";
            txtDesc3.Text = "";            
            txtAWB.Text = "";
            numericAmount.Value = 0;            
            txtReference.Text = "";
            txtTotal.Text = "";
            dataGridView1.Rows.Clear();
            comboClient.Items.Clear();
            loadCustomer();
            comboSource.Items.Clear();
            loadService();
            comboPaymentMode.Items.Clear();
            loadPaymentModes();
            comboType.Text = "";
            //loadDocumentType();
            //move cash sale number to next
        }       
        //SETTINGS
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Voucher_Type_Settings vtp = new Voucher_Type_Settings();
            vtp.ShowDialog();
        }       
     
        //WHEN CUSTOMER NAME CHANGES
        private void comboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Client WHERE Name = '"+ comboClient.Text + "' ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {                        
                        label_CustAccount.Text = (dr["Account"]).ToString();
                        label_DLink.Text = (dr["DCLink"]).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FILL LINK ON SERVICE CHANGE
        public void fillServiceLink()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT AccountLink FROM Accounts WHERE Description = '"+ comboSource.Text+ "' ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {                        
                        label_ServiceLink.Text = (dr["AccountLink"]).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //INSERT TO VOUCHER TYPE
        public void insertToVoucherType()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    string query = "INSERT INTO WIZ_Voucher_Type(DocName,NextNumber) VALUES(@DocName,@NextNumber)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@DocName", comboType.Text);
                    cmd.Parameters.AddWithValue("@NextNumber", int.Parse(label_NextNumber.Text));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //CALCULATION IN DATAGRID
        public void calculationInDatagrid()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns["Amount"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["Amount"].Index].Value) * 1);
                }
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["Amount"].Value);
                }
                txtTotal.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD NEXT NUMBER
        public void loadNextNumber()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT MAX(NextNumber)+1 AS Next_Number FROM WIZ_Voucher_Type WHERE DocName = '" + comboType.Text + "' ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        label_NextNumber.Text = (dr["Next_Number"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //PROCESSING ID
        public void processingID()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT MIN(PreFix) AS PreFix FROM WIZ_Voucher_Type WHERE DocName = '" + comboType.Text + "' ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtPrefix.Text = (dr["PreFix"].ToString()) +"00"+ label_NextNumber.Text.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //FILL CASH SALE NUMBER WHEN TYPE CHANGES
        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadNextNumber();
            processingID();

            txtCashSaleNumber.Text = txtPrefix.Text;
        }        
        //PROCESS  -- SAVE                                                                              
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if(comboClient.Text == ""|| txtCashSaleNumber.Text == ""|| txtTotal.Text == "" || comboPaymentMode.Text == "" || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Fill all necessary fields to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    foreach (DataGridViewRow grid in dataGridView1.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("WIZ_Voucher_Transaction_Add", sqlcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientName", comboClient.Text);
                        cmd.Parameters.AddWithValue("@ClientAccount", label_CustAccount.Text);
                        cmd.Parameters.AddWithValue("@ClientDCLink", Convert.ToInt32(label_DLink.Text));
                        cmd.Parameters.AddWithValue("@Ref1", txtDesc1.Text);
                        cmd.Parameters.AddWithValue("@Ref2", txtDesc2.Text);
                        cmd.Parameters.AddWithValue("@Ref3", txtDesc3.Text);
                        cmd.Parameters.AddWithValue("@SelectedService", grid.Cells["ServiceDescription"].Value);
                        cmd.Parameters.AddWithValue("@SelectedServiceLink", grid.Cells["AccountLink"].Value);
                        cmd.Parameters.AddWithValue("@CashSaleNumber", txtCashSaleNumber.Text);
                        cmd.Parameters.AddWithValue("@AWB", txtAWB.Text);
                        cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTimePicker1.Text));
                        cmd.Parameters.AddWithValue("@DocType", comboType.Text);
                        cmd.Parameters.AddWithValue("@Amount", Convert.ToDouble(grid.Cells["Amount"].Value));
                        cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDouble(txtTotal.Text));
                        cmd.Parameters.AddWithValue("@PaymentMode", comboPaymentMode.Text);
                        cmd.Parameters.AddWithValue("@Reference", txtReference.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Payment processed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                insertToVoucherType();                
            }           

        }
        //PRINT
        public static string document_number = "";
        public static string printer_name = "";
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(txtCashSaleNumber.Text == "")
            {
                MessageBox.Show("No active selection to print", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                document_number = txtCashSaleNumber.Text;
                printer_name = comboPrinters.Text;
                Voucher v = new Voucher();
                v.Show();

                //comboType.Text = "";                
            }
        }
    }
    
}
