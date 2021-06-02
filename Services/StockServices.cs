using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class StockServices
    {
        static IStockRepository stockRepo;

        static StockServices()
        {
            stockRepo = new StockRepository();
        }

        /// <summary>
        /// Gets all the stock from database
        /// 
        /// Usage: Refresh dataGridView
        /// </summary>
        /// <returns></returns>
        public static List<Stock> GetAll()
        {
            return stockRepo.GetAll();
        }

        /// <summary>
        /// Returns the stock with the matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Stock GetById(int id)
        {
            return stockRepo.GetById(id);
        }

        /// <summary>
        /// Returns a list of all the stock containing the stated parameter inside their name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<Stock> GetAllByName(string name)
        {
            return stockRepo.GetAllByName(name);
        }

        /// <summary>
        /// Adds new stock into database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Stock Insert(Stock obj)
        {
            if (obj.STOCK_COUNT == null)
            {
                obj.STOCK_COUNT = 0;
            }
            try
            {
                Validations.ValidateStockInfo(obj);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

            return stockRepo.Insert(obj);
        }

        /// <summary>
        /// Updates the stock
        /// </summary>
        /// <param name="obj"></param>
        public static void Update(Stock obj)
        {
            if (obj.STOCK_COUNT == null)
            {
                obj.STOCK_COUNT = 0;
            }
            try
            {
                Validations.ValidateStockInfo(obj);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            stockRepo.Update(obj);
        }

        /// <summary>
        /// Deletes the stock
        /// </summary>
        /// <param name="obj"></param>
        public static void Delete(Stock obj)
        {
            stockRepo.Delete(obj);
        }
    }
}
