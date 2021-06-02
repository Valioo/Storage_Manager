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
    public partial class AddEditStockForm : Form
    {
        bool IsNew;
        public AddEditStockForm(Stock obj)
        {
            InitializeComponent();
            if (obj == null)
            {
                stockBindingSource.DataSource = new Stock();
                IsNew = true;
            }
            else
            {
                stockBindingSource.DataSource = obj;
                IsNew = false;
            }
        }

        /// <summary>
        /// Adds or edits stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEDitStockForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DialogResult == DialogResult.OK)
                {
                    Stock st = stockBindingSource.Current as Stock;
                    if (IsNew)
                    {
                        StockServices.Insert(st);
                        LogWriter.WriteToLog($"Added stock: {st.NAME}, :{st.TYPE}\n");
                    }
                    else
                    {
                        StockServices.Update(st);
                        LogWriter.WriteToLog($"Updated stock: {st.NAME}, :{st.TYPE}\n");
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
