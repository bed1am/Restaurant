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
    public class DeliveryReposPgs : IRepository<delivery>
    {
        private Model1 db;

        public DeliveryReposPgs(Model1 dbcontext)
        {
            this.db = dbcontext;
        }

        public List<delivery> GetList()
        {
            return db.deliveries.ToList();
        }

        public delivery GetItem(int id)
        {
            return db.deliveries.Find(id);
        }

        public void Create(delivery delivery)
        {
            db.deliveries.Add(delivery);
        }

        public void Update(delivery delivery)
        {
            db.Entry(delivery).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            delivery delivery = db.deliveries.Find(id);
            if (delivery != null)
                db.deliveries.Remove(delivery);
        }
    }
}
