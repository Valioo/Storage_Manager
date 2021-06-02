using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Model;

namespace Services
{
    public static class ClientServices
    {
        static IClientRepository clientRepo;

        static ClientServices()
        {
            clientRepo = new ClientRepository();
        }

        /// <summary>
        /// Gets all the clients from database
        /// 
        /// Usage: Refresh dataGridView
        /// </summary>
        /// <returns></returns>
        public static List<Clients> GetAll()
        {
            return clientRepo.GetAll();
        }

        /// <summary>
        /// Returns the client with the matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Clients GetById(int id)
        {
            return clientRepo.GetById(id);
        }

        /// <summary>
        /// Returns a list of all the clients containing the stated parameter inside their name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<Clients> GetAllByName(string name)
        {
            return clientRepo.GetAllByName(name);
        }

        /// <summary>
        /// Adds new client into database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Clients Insert(Clients obj)
        {
            try
            {
                Validations.ValidateClientInfo(obj);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

            return clientRepo.Insert(obj);
        }

        /// <summary>
        /// Updates the client
        /// </summary>
        /// <param name="obj"></param>
        public static void Update(Clients obj)
        {
            try
            {
                Validations.ValidateClientInfo(obj);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

            clientRepo.Update(obj);
        }

        /// <summary>
        /// Deletes the client
        /// </summary>
        /// <param name="obj"></param>
        public static void Delete(Clients obj)
        {
            clientRepo.Delete(obj);
        }
    }
}
