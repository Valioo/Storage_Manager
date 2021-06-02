using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public interface IClientRepository
    {
        /// <summary>
        /// Gets all the clients from database
        /// -----------
        /// Usage: Refresh dataGridView
        /// </summary>
        /// <returns></returns>
        List<Clients> GetAll();

        /// <summary>
        /// Returns the client with the matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Clients GetById(int id);

        /// <summary>
        /// Returns a list of all the clients containing the stated parameter inside their name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Clients> GetAllByName(string name);

        /// <summary>
        /// Adds new client into database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Clients Insert(Clients obj);

        /// <summary>
        /// Updates client
        /// </summary>
        /// <param name="obj"></param>
        void Update(Clients obj);

        /// <summary>
        /// Deletes client
        /// </summary>
        /// <param name="obj"></param>
        void Delete(Clients obj);
    }
}