using Services;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Storage
{
    public partial class AddEditClientForm : Form
    {
        bool IsNew;
        public AddEditClientForm(Clients obj)
        {
            InitializeComponent();
            if (obj==null)
            {
                clientsBindingSource.DataSource = new Clients();
                IsNew = true;
            }
            else
            {
                clientsBindingSource.DataSource = obj;
                IsNew = false;
            }
        }

        /// <summary>
        /// Adds or edits client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DialogResult == DialogResult.OK)
                {
                    Clients cl = clientsBindingSource.Current as Clients;
                    if (IsNew)
                    {
                        ClientServices.Insert(cl);
                        LogWriter.WriteToLog($"Added client: {cl.FIRST_NAME} {cl.LAST_NAME}\n");
                    }
                    else
                    {
                        ClientServices.Update(cl);
                        LogWriter.WriteToLog($"Updated client: {cl.FIRST_NAME} {cl.LAST_NAME}\n");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                LogWriter.WriteToLog($"Unsuccessfull update/delete \n");
                MessageBox.Show($"Error: {ex.Message}", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
