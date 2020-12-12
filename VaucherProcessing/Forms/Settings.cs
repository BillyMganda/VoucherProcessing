using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace VaucherProcessing.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        static string connectionstring = ConfigurationManager.ConnectionStrings["VaucherProcessing.Properties.Settings.clientSetting"].ConnectionString;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //TEST
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string onnectionString = string.Format("Data Source={0};  User ID={1}; Password={2};", txtSQLServer.Text, txtUsername.Text, txtPassword.Text);
            try
            {
                SQLHelper helper = new SQLHelper(onnectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Test connection successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //populate dropdown with all databases                
                if (txtSQLServer.Text != null && txtSQLServer.Text != "")
                {
                    ServerConnection srvcon = new ServerConnection(txtSQLServer.Text);
                    srvcon.LoginSecure = false;
                    srvcon.Login = txtUsername.Text;
                    srvcon.Password = txtPassword.Text;
                    Microsoft.SqlServer.Management.Smo.Server srv = new Microsoft.SqlServer.Management.Smo.Server(srvcon);
                    foreach (Database db in srv.Databases)
                    {
                        comboDatabase.Items.Add(db.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //SAVE
        private void btnSaveConnection_Click(object sender, EventArgs e)
        {
            if (txtSQLServer.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || comboDatabase.Text == "")
                MessageBox.Show("Fill all database entries to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                saveToDatabase();
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["VaucherProcessing.Properties.Settings.mySetting"].ConnectionString = "Data Source='" + txtSQLServer.Text + "'; Initial Catalog='" + comboDatabase.Text + "'; Persist Security Info=True; UID='" + txtUsername.Text + "'; password='" + txtPassword.Text + "'";
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
                MessageBox.Show("Connection successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        //save
        public void saveToDatabase()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("WIZ_Voucher_Settings_Add", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SQLServer", txtSQLServer.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Database_Name", comboDatabase.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Settings saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();

                    VaucherProcessing vts = new VaucherProcessing();
                    vts.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD DATA TO FORM
        public void loadAllDataToForm()
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(connectionstring);
                DataTable dt = new DataTable();
                sqlcon.Open();
                SqlDataReader myReader = null;
                string query = "SELECT SQLServer FROM WIZ_Voucher_Settings";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                myReader = sqlcmd.ExecuteReader();
                while (myReader.Read())
                {
                    txtSQLServer.Text = (myReader["SQLServer"].ToString());
                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LOAD
        private void Settings_Load(object sender, EventArgs e)
        {
            loadAllDataToForm();
            if (txtSQLServer.Text == "")
            {
                //do nothing
            }
            else
            {
                Voucher_Processing_Form vpf = new Voucher_Processing_Form();
                vpf.ShowDialog();
                this.Hide();
                this.ShowInTaskbar = false;
            }
        }
    }
}
