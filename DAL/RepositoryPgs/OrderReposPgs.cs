using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class OrderReposPgs : IRepository<order>
    {
        private Model1 db;

        public OrderReposPgs(Model1 dbcontext)
        {
            this.db = dbcontext;
        }

        public List<order> GetList()
        {
            return db.orders.ToList();
        }

        public order GetItem(int id)
        {
            return db.orders.Find(id);
        }

        public void Create(order Order)
        {
            db.orders.Add(Order);
        }

        public void Update(order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            order Order = db.orders.Find(id);
            if (Order != null)
                db.orders.Remove(Order);
        }
    }
}
