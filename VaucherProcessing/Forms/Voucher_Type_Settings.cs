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

namespace VaucherProcessing.Forms
{
    public partial class Voucher_Type_Settings : Form
    {
        public Voucher_Type_Settings()
        {
            InitializeComponent();
        }
        static string connectionstring = ConfigurationManager.ConnectionStrings["VaucherProcessing.Properties.Settings.clientSetting"].ConnectionString;       
      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        string active_ = "";

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            active_ = "True";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            active_ = "False";
        }      
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
                    cmd.CommandText = "SELECT MAX(DocType)+1 AS Reference_Number FROM WIZ_Voucher_Type";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtDocumentType.Text = (dr["Reference_Number"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadNextNumber()
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
                    cmd.CommandText = "SELECT MAX(NextNumber)+1 AS Reference_Number FROM WIZ_Voucher_Type";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtNextNumber.Text = (dr["Reference_Number"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD
        private void Voucher_Type_Settings_Load(object sender, EventArgs e)
        {
            loadDocumentType();
            loadNextNumber();
            loadToCashbook();
        }
        //LOAD TO CASHBOOK COMBOBOX
        public void loadToCashbook()
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
                    cmd.CommandText = "Select idBatches, cBatchDesc from _btblCbBatches";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboPaymentMode.Items.Add(dr["cBatchDesc"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //CHANGE CODE
        private void comboPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
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
                    cmd.CommandText = "Select idBatches FROM _btblCbBatches WHERE cBatchDesc = '"+ comboPaymentMode.Text+ "' ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        label_Code.Text = (dr["idBatches"]).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //ADD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || comboPaymentMode.Text == "")
            {
                MessageBox.Show("Fill all details to add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
            else
            {
                string[] row = { textBox1.Text, comboPaymentMode.Text, label_Code.Text };
                dataGridView1.Rows.Add(row);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //SAVE TO PAYMENT MODES
        public void savePaymentModes()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    foreach(DataGridViewRow grid in dataGridView1.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("WIZ_Voucher_PmtModes_Add", sqlcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PaymentMode", grid.Cells["PaymentMode"].Value.ToString());
                        cmd.Parameters.AddWithValue("@idBatches", Convert.ToInt32(grid.Cells["Code"].Value));
                        cmd.Parameters.AddWithValue("@cBatchDesc", grid.Cells["Cashbook"].Value.ToString());
                        cmd.ExecuteNonQuery();
                    }                    
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //SAVE VOUCHER TYPES
        public void saveVoucherTypes()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    foreach (DataGridViewRow gridrow in dataGridView1.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("WIZ_Voucher_Type_Add", sqlcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PaymentMode", gridrow.Cells["PaymentMode"].Value.ToString());
                        cmd.Parameters.AddWithValue("@idBatches", Convert.ToInt32(gridrow.Cells["Code"].Value));
                        cmd.Parameters.AddWithValue("@cBatchDesc", gridrow.Cells["Cashbook"].Value.ToString());
                        cmd.Parameters.AddWithValue("@DocType", Convert.ToInt32(txtDocumentType.Text));
                        cmd.Parameters.AddWithValue("@DocName", txtDocumentName.Text);
                        cmd.Parameters.AddWithValue("@Active", active_);
                        cmd.Parameters.AddWithValue("@PreFix", txtPrefix.Text);
                        cmd.Parameters.AddWithValue("@PostFix", txtPostFix.Text);
                        cmd.Parameters.AddWithValue("@NextNumber", Convert.ToInt32(txtNextNumber.Text));
                        cmd.Parameters.AddWithValue("@PaddingSize", Convert.ToInt32(txtPadding.Text));
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //SAVE
        private void button2_Click(object sender, EventArgs e)
        {
            if(txtDocumentType.Text == ""|| txtDocumentName.Text == ""|| txtPrefix.Text==""|| txtPostFix.Text=="" || txtNextNumber.Text=="")
            {
                MessageBox.Show("Fill all fields to save", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    savePaymentModes();
                    saveVoucherTypes();
                    MessageBox.Show("Settings saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
        //DELETE ROW
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
            }
        }
        //ONLY ACCEPT NUMBERS
        private void txtDocumentType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }      

    }
}
