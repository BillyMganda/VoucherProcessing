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
using VaucherProcessing.Reports;
using System.Drawing.Printing;

namespace VaucherProcessing.Forms
{
    public partial class VaucherProcessing : Form
    {
        public VaucherProcessing()
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //LOAD DATA
        public void loadClients()
        {
            try
            {
                using(SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Client";
                    dr = cmd.ExecuteReader();                   
                    while(dr.Read())
                    {
                        comboClient.Items.Add(dr["Name"]);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        private void VaucherProcessing_Load(object sender, EventArgs e)
        {
            loadClients();
            loadType();
            loadPrinters();
            //randomNumber();            
        }
        //POPULATE TEXTBOXES
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
                    cmd.CommandText = "SELECT * FROM Client WHERE NAME = '"+comboClient.Text+"' ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {                        
                        txtClientID.Text = (dr["DCLink"].ToString());
                        txtAccount.Text = (dr["Account"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
        //LOAD TYPE
        public void loadType()
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
                    cmd.CommandText = "SELECT DocName FROM WIZ_Voucher_Type WHERE Active = 'True' ";
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
                    cmd.CommandText = "SELECT MIN(PreFix) AS PreFix FROM WIZ_Voucher_Type WHERE DocName = '" + comboType.Text+ "' ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtProcessingID.Text = (dr["PreFix"].ToString()) + label_NextNumber.Text.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //CLEAR
        public void Clear()
        {            
            numericIn.Value = 0;            
            txtProcessingID.Text = ""; 
            comboType.Text = "";
        }       
        //PROCESSED VOUCHERS
        private void button1_Click(object sender, EventArgs e)
        {
            Processed_vouchers pv = new Processed_vouchers();
            pv.ShowDialog();
        }
        //FILL PROCESSING ID ON COMBOBOX CHANGE
        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadNextNumber();
            processingID();
        }
        //PROCESS TRANSACTION
        public static string ReportID = "";
        public static string printer = "";
        private void btnProcessFull_Click(object sender, EventArgs e)
        {
            if (comboClient.Text == "" || comboType.Text == "")
            {
                MessageBox.Show("Fill all necessary fields to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand cmd = new SqlCommand("WIZ_Voucher_Tx_Add", sqlcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientName", comboClient.Text);
                        cmd.Parameters.AddWithValue("@ClientID", Convert.ToInt32(txtClientID.Text));
                        cmd.Parameters.AddWithValue("@Account", txtAccount.Text);
                        cmd.Parameters.AddWithValue("@VoucherName", comboType.Text);
                        cmd.Parameters.AddWithValue("@ProcessingDate", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@ProcessingID", txtProcessingID.Text);
                        cmd.Parameters.AddWithValue("@Payment", numericIn.Value);
                        cmd.Parameters.AddWithValue("@Desc1", txtDesc1.Text);
                        cmd.Parameters.AddWithValue("@Desc2", txtDesc2.Text);
                        cmd.Parameters.AddWithValue("@Desc3", txtDesc3.Text);
                        cmd.ExecuteNonQuery();

                        //change processing id
                        insertToVoucherType();
                        loadNextNumber();
                        processingID();
                        
                        printer = comboPrinter.Text;
                        ReportID = txtProcessingID.Text;
                        Voucher vo = new Voucher();
                        vo.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    cmd.CommandText = "SELECT MAX(NextNumber)+1 AS Next_Number FROM WIZ_Voucher_Type WHERE DocName = '"+ comboType.Text+ "' ";
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
        //RANDOM NUMBER
        public void randomNumber()
        {
            Random r = new Random();
            int rInt = r.Next(0, 1000000);
            label_NextNumber.Text = rInt.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Voucher_Type_Settings vts = new Voucher_Type_Settings();
            vts.ShowDialog();
        }
    }
}
