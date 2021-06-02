using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Storage
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string textBoxUsername = txtUserName.Text;
            string textBoxPassword = txtPassword.Text;

            string ConnectionString =
               "Server=localhost;Integrated security=SSPI;database=global";
            SqlConnection login = new SqlConnection(ConnectionString);
            SqlCommand test = new SqlCommand("SELECT Password FROM Users WHERE Username = '" + textBoxUsername + "'", login);

            try
            {
                using (login)
                {
                    login.Open();
                    string pass = (string)test.ExecuteScalar();
                    if (textBoxPassword == pass)
                    {
                        MainForm mf = new MainForm();
                        mf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not connected to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
