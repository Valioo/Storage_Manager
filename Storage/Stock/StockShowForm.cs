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
    public partial class StockShowForm : Form
    {
        public StockShowForm()
        {
            InitializeComponent();
        }

        private void StockShowForm_Load(object sender, EventArgs e)
        {
            stockBindingSource.DataSource = StockServices.GetAll();
        }

        /// <summary>
        /// Adds stock to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditStockForm frm = new AddEditStockForm(null))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    stockBindingSource.DataSource = StockServices.GetAll();
                }
            }
        }
        
        /// <summary>
        /// Edits the selected stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (stockBindingSource.Current == null)
                return;
            using (AddEditStockForm frm = new AddEditStockForm(stockBindingSource.Current as Stock))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    stockBindingSource.DataSource = StockServices.GetAll();
                }
            }
        }

        /// <summary>
        /// Deletes the selected stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (stockBindingSource.Current == null)
                return;

            if (MessageBox.Show("Are you sure you want to delete this stock?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Stock st = stockBindingSource.Current as Stock;
                LogWriter.WriteToLog($"Deleted TYPE: {st.TYPE}, NAME: {st.NAME} from stock\n");
                StockServices.Delete(st);
                stockBindingSource.RemoveCurrent();
            }
        }

        /// <summary>
        /// Adds 1 to the selected stock's quantity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToStock1_Click(object sender, EventArgs e)
        {
            if (stockBindingSource.Current == null)
                return;

            Stock st = stockBindingSource.Current as Stock;
            st.STOCK_COUNT++;
            StockServices.Update(st);

            LogWriter.WriteToLog($"Added +1 quantity to TYPE: {st.TYPE}, NAME: {st.NAME}\n");

            stockBindingSource.DataSource = StockServices.GetAll();
        }

        /// <summary>
        /// Deducts the selected stock's quantity by 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeductBy1_Click(object sender, EventArgs e)
        {
            if (stockBindingSource.Current == null)
                return;

            Stock st = stockBindingSource.Current as Stock;

            if (st.STOCK_COUNT <= 0)
            {
                st.STOCK_COUNT = 0;
                StockServices.Update(st);
                stockBindingSource.DataSource = StockServices.GetAll();
                MessageBox.Show("Stock count cannot be less than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            st.STOCK_COUNT--;
            StockServices.Update(st);

            LogWriter.WriteToLog($"TYPE: {st.TYPE}, NAME: {st.NAME}'s stock quantity has been deducted by 1\n");

            stockBindingSource.DataSource = StockServices.GetAll();
        }

        /// <summary>
        /// Sets selected stock's quantity to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetTo0_Click(object sender, EventArgs e)
        {
            if (stockBindingSource.Current == null)
                return;


            if (MessageBox.Show("Are you sure you want to set stock to 0", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            Stock st = stockBindingSource.Current as Stock;

            st.STOCK_COUNT = 0;
            StockServices.Update(st);

            LogWriter.WriteToLog($"Set TYPE: {st.TYPE}, NAME: {st.NAME}'s quantity to 0\n");

            stockBindingSource.DataSource = StockServices.GetAll();
        }

        /// <summary>
        /// Searches for item in id/type and name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string nameOrId = txtChoice.Text;
            if (nameOrId == "")
            {
                stockBindingSource.DataSource = StockServices.GetAll();
                return;
            }

            if (cbChoice.Text == "id")
            {
                if (nameOrId.All(char.IsDigit) == false)
                {
                    MessageBox.Show("Please enter valid id", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stockBindingSource.DataSource = StockServices.GetAll();
                    return;
                }
                stockBindingSource.DataSource = StockServices.GetById(int.Parse(nameOrId));
            }
            else if (cbChoice.Text == "name")
            {
                stockBindingSource.DataSource = StockServices.GetAllByName(nameOrId);
            }
            else
            {
                MessageBox.Show("Please select an item from the dropdown menu", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Adds the selected stock to checkout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToCheckout_Click(object sender, EventArgs e)
        {
            if (stockBindingSource.Current == null)
                return;

            
            var stock = stockBindingSource.Current as Stock;
            if (stock.STOCK_COUNT <= 0)
            {
                MessageBox.Show("Not enough stock", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CheckoutForm.HasChanged = true;

            var nesw = stock;
            Checkout.AddItemToStock(nesw);

            stock.STOCK_COUNT--;
            StockServices.Update(stock);

            stockBindingSource.DataSource = StockServices.GetAll();
        }
    }
}
