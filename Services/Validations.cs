using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Validations
    {
        /// <summary>
        /// Checks if stock has correct information
        /// </summary>
        /// <param name="obj"></param>
        public static void ValidateStockInfo(Stock obj)
        {
            if (String.IsNullOrEmpty(obj.NAME) || String.IsNullOrEmpty(obj.TYPE) || obj.PRICE < 0 || obj.STOCK_COUNT < 0)
            {
                throw new ArgumentException("Please enter valid data");
            }
        }

        /// <summary>
        /// Checks if client has correct information
        /// </summary>
        /// <param name="obj"></param>
        public static void ValidateClientInfo(Clients obj)
        {
            if (String.IsNullOrEmpty(obj.FIRST_NAME) || String.IsNullOrEmpty(obj.LAST_NAME) || obj.BIRTHDAY.Equals(null) || obj.EMAIL_ADDRESS.Equals(null))
            {
                throw new ArgumentException("Please enter valid data");
            }
        }
    }
}
