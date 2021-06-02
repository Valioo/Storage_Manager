using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class CheckoutStock
    {
        public int ID { get; set; }
        public string TYPE { get; set; }
        public string NAME { get; set; }
        public decimal PRICE { get; set; }
        public int STOCK_COUNT { get; set; }

        public CheckoutStock(int id, string type, string name, decimal price, int stock_count)
        {
            this.ID = id;
            this.TYPE = type;
            this.NAME = name;
            this.PRICE = price;
            this.STOCK_COUNT = stock_count;
        }

        public CheckoutStock()
        {

        }
    }
}
