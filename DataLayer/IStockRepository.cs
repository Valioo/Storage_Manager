using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public interface IStockRepository
    {
        /// <summary>
        /// Gets all the stock from database
        /// 
        /// Usage: Refresh dataGridView
        /// </summary>
        /// <returns></returns>
        List<Stock> GetAll();

        /// <summary>
        /// Returns the stock with the matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Stock GetById(int id);

        /// <summary>
        /// Returns a list of all the stock containing the stated parameter inside their name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Stock> GetAllByName(string name);

        /// <summary>
        /// Adds new stock into database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Stock Insert(Stock obj);

        /// <summary>
        /// Updates stock
        /// </summary>
        /// <param name="obj"></param>
        void Update(Stock obj);

        /// <summary>
        /// Deletes stock
        /// </summary>
        /// <param name="obj"></param>
        void Delete(Stock obj);
    }
}
