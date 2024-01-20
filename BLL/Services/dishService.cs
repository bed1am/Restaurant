using BLL.DTO;
using DAL;
using DomainModel;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class dishService : IdishService
    {
        private Model1 db;
        public dishService()
        {
            db = new Model1();
        }

        public bool MakeDish(dishDto DishDto)
        {
            dish Dish = new dish
            {
                name = DishDto.name,
                id = DishDto.id,
                weight = DishDto.weight,
                price = DishDto.price,
                time_cook = DishDto.time_cook,
                category = DishDto.category


            };
            db.dishes.Add(Dish);
            if (db.SaveChanges() > 0)
                return true;
            return false;

        }
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
        public dishDto GetDish(int Id)
        {
            return new dishDto(db.dishes.Find(Id));
        }
        public void CreateDish(dishDto p)
        {
            db.dishes.Add(new dish() { name = p.name, id = p.id, weight = p.weight, price = p.price, time_cook = p.time_cook, category = p.category });
            Save();
        }
        public void UpdateDish(dishDto p)
        {
            dish dish = db.dishes.Find(p.id);
            dish.name = p.name;
            dish.weight = p.weight;
            dish.price = p.price;
            dish.time_cook = p.time_cook;
            dish.category = p.category;
            Save();
        }
        public void DeleteDish(int id)
        {
            dish p = db.dishes.Find(id);
            if (p != null)
            {
                db.dishes.Remove(p);
                Save();
            }
        }

        public List<dishDto> GetAllDishes()
        {
            var res = db.dishes.ToList();
            return res.Select(i => new dishDto(i)).ToList();
        }
    }
}
