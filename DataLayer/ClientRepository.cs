using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public class ClientRepository : IClientRepository
    {
        public void Delete(Clients obj)
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                db.Clients.Attach(obj);
                db.Clients.Remove(obj);
                db.SaveChanges();
            }
        }

        public List<Clients> GetAll()
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                return db.Clients.ToList();
            }
        }

        public Clients GetById(int id)
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                return db.Clients.Find(id);
            }
        }

        public List<Clients> GetAllByName(string name)
        {
            using(ClientStockEntities db = new ClientStockEntities())
            {
                return db.Clients.Where(n => n.FIRST_NAME.Trim().Contains(name.Trim()) || n.LAST_NAME.Contains(name.Trim())).ToList();
            }
        }

        public Clients Insert(Clients obj)
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                db.Clients.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public void Update(Clients obj)
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                db.Clients.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
