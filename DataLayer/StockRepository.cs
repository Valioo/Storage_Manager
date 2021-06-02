using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public class StockRepository : IStockRepository
    {
        public void Delete(Stock obj)
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                db.Stock.Attach(obj);
                db.Stock.Remove(obj);
                db.SaveChanges();
            }
        }

        public List<Stock> GetAll()
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                return db.Stock.ToList();
            }
        }

        public Stock GetById(int id)
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                return db.Stock.Find(id);
            }
        }
        public List<Stock> GetAllByName(string name)
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                return db.Stock.Where(n => n.NAME.Contains(name.Trim()) || n.TYPE.Contains(name.Trim())).ToList();
            }
        }

        public Stock Insert(Stock obj)
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                db.Stock.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public void Update(Stock obj)
        {
            using (ClientStockEntities db = new ClientStockEntities())
            {
                db.Stock.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
