using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;


namespace FinaCoreIndustries
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            roundedBtn(btnLogin, 5);

            roundedPanel(panelUsername, 5);
            roundedPanel(panelPassword, 5);

            labelWelcome.BringToFront();
        }

        public static void roundedBtn(Button button, int radius)
        {
            if (button.Height < radius * 2) radius = button.Height / 2;
            if (button.Width < radius * 2) radius = button.Width / 2;

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddLine(radius, 0, button.Width - radius, 0);
            path.AddArc(button.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddLine(button.Width, radius, button.Width, button.Height - radius);
            path.AddArc(button.Width - radius * 2, button.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(button.Width - radius, button.Height, radius, button.Height);
            path.AddArc(0, button.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            button.Region = new Region(path);
        }


        public void roundedPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddLine(radius, 0, panel.Width - radius, 0);
            path.AddArc(panel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddLine(panel.Width, radius, panel.Width, panel.Height - radius);
            path.AddArc(panel.Width - radius * 2, panel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(panel.Width - radius, panel.Height, radius, panel.Height);
            path.AddArc(0, panel.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=finacore;Password=finacoreindustries;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SID=xe)));";


            using (Oracle.ManagedDataAccess.Client.OracleConnection con = new Oracle.ManagedDataAccess.Client.OracleConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT  COUNT (*) FROM Login_User WHERE USERNAME = :username AND PASS = :password";

                    using (Oracle.ManagedDataAccess.Client.OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand(query, con))
                    {
                        cmd.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("username", txtUsername.Text));
                        cmd.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("password", txtPassword.Text));

                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("Login Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Form formDashboard = new Dashboard();
                            formDashboard.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //Clear all the fields
                        txtUsername.Clear();
                        txtPassword.Clear();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
