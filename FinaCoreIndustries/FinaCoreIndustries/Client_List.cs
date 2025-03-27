using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;

namespace FinaCoreIndustries
{
    public partial class Client_List : Form
    {
        public Client_List()
        {
            InitializeComponent();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnSOA_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {

        }

        private void FillDGV()
        {
            string connectionString = "User Id=finacore;Password=finacoreindustries;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SID=xe)));";

            try
            {
                using (Oracle.DataAccess.Client.OracleConnection con = new Oracle.DataAccess.Client.OracleConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT * FROM CLIENT_USERS";
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
            
            }

         }

        private void Client_List_Load(object sender, EventArgs e)
        {
            FillDGV();
        }

        private void btnAddClient_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnInvoice_Click_1(object sender, EventArgs e)
        {

        }

        private void btn1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

       
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string connectionString = "User Id=finacore;Password=finacoreindustries;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SID=xe)));";

            string clientID = txtID.Text;
            string clientName = txtName.Text;
            string clientCode = txtCode.Text;
            string contact = txtContact.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string status = cmbStatus.Text;
            DateTime dateAdded = dateTimePicker1.Value;

            try
            {
                using (Oracle.DataAccess.Client.OracleConnection con = new Oracle.DataAccess.Client.OracleConnection(connectionString))
                {
                    con.Open();

                    // SQL query to insert the client data into COMPANY_CLIENTS table
                    string query = "INSERT INTO COMPANY_CLIENTS (CLIENT_ID, CLIENT_NAME,CLIENT_CODE, CONTACT, EMAIL, ADDRESS, STATUS, CLIENT_DATE) " +
                                   "VALUES (:ClientID, :ClientName, :ClientCode, :Contact, :Email, :Address, :Status, TO_DATE(:DateAdded, 'YYYY-MM-DD'))";

                    using (Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(query, con))
                    {
                        // Adding parameters to the query
                        cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter(":ClientID", clientID));
                        cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter(":ClientName", clientName));
                        cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter(":ClientCode", clientCode));
                        cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter(":Contact", contact));
                        cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter(":Email", email));
                        cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter(":Address", address));
                        cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter(":Status", status));
                        cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter(":DateAdded", Oracle.DataAccess.Client.OracleDbType.Date)).Value = dateAdded;

                        // Execute the query to insert the data
                        cmd.ExecuteNonQuery();
                    }

                    // Optionally show a message box to indicate success
                    MessageBox.Show("Client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear form fields (optional)
                    txtID.Clear();
                    txtName.Clear();
                    txtCode.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    txtAddress.Clear();
                    cmbStatus.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
