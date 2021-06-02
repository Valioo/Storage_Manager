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
    public partial class CheckoutForm : Form
    {
        public CheckoutForm()
        {
            InitializeComponent();
        }

        public static bool HasChanged = false;

        /// <summary>
        /// Refreshes dataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            checkoutStockBindingSource.DataSource = Checkout.listStock;

            if (Checkout.client != null)
            {
                lblBuyer.Text = $"{Checkout.client.FIRST_NAME} {Checkout.client.LAST_NAME}";
            }
            else
            {
                lblBuyer.Text = "";
            }

            decimal priceTotal = 0;
            if (Checkout.listStock.Count > 0)
            {
                foreach (var item in Checkout.listStock)
                {
                    priceTotal += item.PRICE * item.STOCK_COUNT;
                }
            }

            lblPrice.Text = Math.Round(priceTotal, 2).ToString();
        }

        /// <summary>
        /// Deducts selected item quantity by 1, if 0 deletes it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (checkoutStockBindingSource.Current == null)
                return;

            CheckoutStock stockCurrent = checkoutStockBindingSource.Current as CheckoutStock;
            Stock cl = StockServices.GetById(stockCurrent.ID);
            cl.STOCK_COUNT++;
            StockServices.Update(cl);
            foreach (var item in Checkout.listStock)
            {
                if (item.ID == stockCurrent.ID)
                {
                    if (item.STOCK_COUNT == 1)
                    {
                        Checkout.listStock.Remove(item);
                        lblPrice.Text = Math.Round((decimal.Parse(lblPrice.Text) - item.PRICE), 2).ToString();
                        break;
                    }
                    item.STOCK_COUNT--;
                    lblPrice.Text = Math.Round((decimal.Parse(lblPrice.Text) - item.PRICE), 2).ToString();
                }
            }

            checkoutStockBindingSource.ResetBindings(HasChanged);
        }

        /// <summary>
        /// Finalizes purchase, deletes items from list and checkout client, refreshes dataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinalize_Click(object sender, EventArgs e)
        {
            if (lblBuyer.Text == "" || Checkout.listStock.Count == 0)
            {
                MessageBox.Show("Please enter items or buyer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            StringBuilder str = new StringBuilder();
            decimal totalPrice = decimal.Parse(lblPrice.Text);
            string buyer = lblBuyer.Text;
            HasChanged = true;

            str.Append($"Sold stock costing {Math.Round(totalPrice, 2)}$ to {buyer}. ----------------- ITEMS:\n");
            foreach (var item in Checkout.listStock)
            {
                str.Append($"Item name: {item.NAME}, Item type: {item.TYPE}, Item price per stock: ${Math.Round(item.PRICE, 2)}, Sold quantity: {item.STOCK_COUNT}\n");
            }

            Checkout.listStock.Clear();
            Checkout.client = null;
            lblPrice.Text = "";
            lblBuyer.Text = "";
            checkoutStockBindingSource.ResetBindings(HasChanged);

            LogWriter.WriteToLog(str.ToString());
        }
    }
}
