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
    public class DishStringReposPgs : IRepository<dish_string>
    {
        private Model1 db;

        public DishStringReposPgs(Model1 dbcontext)
        {
            this.db = dbcontext;
        }

        public List<dish_string> GetList()
        {
            return db.dish_string.ToList();
        }

        public dish_string GetItem(int id)
        {
            return db.dish_string.Find(id);
        }

        public void Create(dish_string dish_String)
        {
            db.dish_string.Add(dish_String);
        }

        public void Update(dish_string dish_String)
        {
            db.Entry(dish_String).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            dish_string dish_String = db.dish_string.Find(id);
            if (dish_String != null)
                db.dish_string.Remove(dish_String);
        }
    }
}
