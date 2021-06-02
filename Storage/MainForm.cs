using Services;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Storage
{
    public partial class MainForm : Form
    {
        ClientsShowForm clfrm;
        StockShowForm stfrm;
        CheckoutForm cofrm;

        Color selectedClr = Color.FromArgb(255, 119, 234, 185);
        Color normalClr = Color.FromArgb(255, 0, 192, 192);

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clfrm != null)
                {
                    clfrm.Close();
                }
                if (stfrm != null)
                {
                    stfrm.Close();
                }
                if (cofrm != null)
                {
                    cofrm.Close();
                }
                LogWriter.WriteToLog("Application closed\n");
                Application.Exit();
            }
        }

        /// <summary>
        /// Opens clients form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cLIENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cLIENTSToolStripMenuItem.BackColor = selectedClr;
            sTOCKToolStripMenuItem.BackColor = normalClr;
            cARTToolStripMenuItem.BackColor = normalClr;

            if (clfrm != null)
            {
                clfrm.Close();
            }
            if (stfrm != null)
            {
                stfrm.Close();
            }
            if (cofrm != null)
            {
                cofrm.Close();
            }
            try
            {
                clfrm = new ClientsShowForm();
                clfrm.Left = 0;
                clfrm.Top = 0;
                Rectangle recNew = new Rectangle();
                recNew = this.ClientRectangle;
                clfrm.Size = recNew.Size;
                clfrm.MdiParent = this;
                clfrm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Opens stock form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sTOCKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cLIENTSToolStripMenuItem.BackColor = normalClr;
            sTOCKToolStripMenuItem.BackColor = selectedClr;
            cARTToolStripMenuItem.BackColor = normalClr;

            if (clfrm != null)
            {
                clfrm.Close();
            }
            if (stfrm != null)
            {
                stfrm.Close();
            }
            if (cofrm != null)
            {
                cofrm.Close();
            }
            try
            {
                stfrm = new StockShowForm();
                stfrm.Left = 0;
                stfrm.Top = 0;
                Rectangle recNew = new Rectangle();
                recNew = this.ClientRectangle;
                stfrm.Size = recNew.Size;
                stfrm.MdiParent = this;
                stfrm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// On event - form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Checkout.RemoveAllItemsFromStock();
        }

        /// <summary>
        /// Opens checkout form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cLIENTSToolStripMenuItem.BackColor = normalClr;
            sTOCKToolStripMenuItem.BackColor = normalClr;
            cARTToolStripMenuItem.BackColor = selectedClr;

            if (clfrm != null)
            {
                clfrm.Close();
            }
            if (stfrm != null)
            {
                stfrm.Close();
            }
            if (cofrm != null)
            {
                cofrm.Close();
            }
            try
            {
                cofrm = new CheckoutForm();
                cofrm.Left = 0;
                cofrm.Top = 0;
                Rectangle recNew = new Rectangle();
                recNew = this.ClientRectangle;
                cofrm.Size = recNew.Size;
                cofrm.MdiParent = this;
                cofrm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogWriter.WriteToLog("Application opened\n");
        }
    }
}
