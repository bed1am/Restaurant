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
    public class DishReposPgs : IRepository<dish>
    {
        private Model1 db;

        public DishReposPgs(Model1 dbcontext)
        {
            this.db = dbcontext;
        }

        public List<dish> GetList()
        {
            return db.dishes.ToList();
        }

        public dish GetItem(int id)
        {
            return db.dishes.Find(id);
        }

        public void Create(dish Dish)
        {
            db.dishes.Add(Dish);
        }

        public void Update(dish Dish)
        {
            db.Entry(Dish).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            dish Dish = db.dishes.Find(id);
            if (Dish != null)
                db.dishes.Remove(Dish);
        }
    }
}
