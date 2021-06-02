using Services;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public static class Checkout
    {
        public static List<CheckoutStock> listStock = new List<CheckoutStock>();
        public static Clients client;


        /// <summary>
        /// Adds an item to the checkout stock
        /// </summary>
        /// <param name="obj"></param>
        public static void AddItemToStock(Stock obj)
        {
            foreach (var item in listStock)
            {
                if (item.ID == obj.ID)
                {
                    item.STOCK_COUNT++;
                    return;
                }
            }
            CheckoutStock st = new CheckoutStock();
            st.ID = obj.ID;
            st.TYPE = obj.TYPE;
            st.NAME = obj.NAME;
            st.PRICE = obj.PRICE;
            st.STOCK_COUNT = 1;
            listStock.Add(st);
        }

        /// <summary>
        /// Clears the checkout list
        /// </summary>
        public static void RemoveAllItemsFromStock()
        {
            if (listStock.Count == 0)
            {
                return;
            }
            else
            {
                foreach (var stock in listStock)
                {
                    if (stock.STOCK_COUNT == 0)
                    {
                        continue;
                    }
                    Stock st = new Stock();
                    st.ID = stock.ID;
                    st.TYPE = stock.TYPE;
                    st.NAME = stock.NAME;
                    st.PRICE = stock.PRICE;
                    st.STOCK_COUNT = stock.STOCK_COUNT;
                    Stock checkcount = StockServices.GetById(st.ID);
                    st.STOCK_COUNT = checkcount.STOCK_COUNT + st.STOCK_COUNT;
                    StockServices.Update(st);
                }
            }
        }

        /// <summary>
        /// Sets the checkout client
        /// </summary>
        /// <param name="obj"></param>
        public static void SetClientToCheckout(Clients obj)
        {
            client = obj;
        }
    }
}
