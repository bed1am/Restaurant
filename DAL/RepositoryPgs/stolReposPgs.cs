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
    public class stolReposPgs : IRepository<stol>
    {
        private Model1 db;

        public stolReposPgs(Model1 dbcontext)
        {
            this.db = dbcontext;
        }

        public List<stol> GetList()
        {
            return db.stols.ToList();
        }

        public stol GetItem(int id)
        {
            return db.stols.Find(id);
        }

        public void Create(stol stol)
        {
            db.stols.Add(stol);
        }

        public void Update(stol stol)
        {
            db.Entry(stol).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            stol stol = db.stols.Find(id);
            if (stol != null)
                db.stols.Remove(stol);
        }
    }
}
