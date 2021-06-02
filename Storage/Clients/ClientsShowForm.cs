using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using Model;

namespace Storage
{
    public partial class ClientsShowForm : Form
    {
        public ClientsShowForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On form load - refreshes dataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientsShowForm_Load(object sender, EventArgs e)
        {
            clientsBindingSource.DataSource = ClientServices.GetAll();
        }

        /// <summary>
        /// Add new client to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditClientForm frm = new AddEditClientForm(null))
            {
                
                if (frm.ShowDialog()==DialogResult.OK)
                {
                    clientsBindingSource.DataSource = ClientServices.GetAll();
                }
            }
        }

        /// <summary>
        /// Edits the selected client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (clientsBindingSource.Current == null)
                return;
            using (AddEditClientForm frm = new AddEditClientForm(clientsBindingSource.Current as Clients))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    clientsBindingSource.DataSource = ClientServices.GetAll();
                }
            }
        }

        /// <summary>
        /// Deletes the selected client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (clientsBindingSource.Current == null)
                return;

            if (MessageBox.Show("Are you sure you want to delete this client?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Clients cl = clientsBindingSource.Current as Clients;
                LogWriter.WriteToLog($"Deleted client NAME: {cl.FIRST_NAME} {cl.LAST_NAME}\n");
                ClientServices.Delete(cl);
                clientsBindingSource.RemoveCurrent();
            }
        }

        /// <summary>
        /// Searches for the selected client by id/first and last name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string nameOrId = txtChoice.Text;

            if (nameOrId == "")
            {
                clientsBindingSource.DataSource = ClientServices.GetAll();
                return;
            }

            if (cbChoice.Text == "id")
            {
                if (nameOrId.All(char.IsDigit) == false)
                {
                    MessageBox.Show("Please enter valid id", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    clientsBindingSource.DataSource = ClientServices.GetAll();
                    return;
                }
                clientsBindingSource.DataSource = ClientServices.GetById(int.Parse(nameOrId));
            }
            else if (cbChoice.Text == "name")
            {
                clientsBindingSource.DataSource = ClientServices.GetAllByName(nameOrId);
            }
            else
            {
                MessageBox.Show("Please select an item from the dropdown menu", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Sets the client to checkout client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (clientsBindingSource.Current == null)
                return;

            CheckoutForm.HasChanged = true;
            Checkout.SetClientToCheckout(clientsBindingSource.Current as Clients);
        }
    }
}
