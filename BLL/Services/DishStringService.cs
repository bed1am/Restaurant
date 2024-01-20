using BLL.DTO;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DishStringService : IDishStringService
    {
        private List<KeyValuePair<int, dishDto>> busket = new List<KeyValuePair<int, dishDto>>();
        private Model1 db;
        public DishStringService()
        {
            db = new Model1();
        }

        public bool MakeDishString(dishstringDto dishstringDto)
        {
            dish_string DishString = new dish_string
            {
                id = dishstringDto.id,
                id_dish = dishstringDto.id_dish,
                id_order = dishstringDto.id_order,
                numb_dish = dishstringDto.numb_dish,
                price = dishstringDto.price,



            };
            db.dish_string.Add(DishString);
            if (db.SaveChanges() > 0)
                return true;
            return false;

        }
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
        public dishstringDto GetDishString(int Id)
        {
            return new dishstringDto(db.dish_string.Find(Id));
        }
        public void CreateDishString(dishDto p, int id_order, int number)
        {
            db.dish_string.Add(new dish_string() { numb_dish = number, id_dish = p.id, id_order = id_order, price = p.price * number });
            Save();
        }
        public void PutToBusketDishString(dishDto p, int number) {
            busket.Add(new KeyValuePair<int, dishDto>(number, p));
        }
        public List<KeyValuePair<int, dishDto>> GetBusketDishString() {
            return busket.Select(i => i).ToList();
        }
        public void ClearBusketDishString() {
            busket.Clear();
        }
        public void UpdateDishString(dishstringDto p)
        {
            dish_string ds = db.dish_string.Find(p.id);
            ds.id_dish = p.id_dish;
            ds.id_order = p.id_order;
            ds.numb_dish = p.numb_dish;
            ds.price = p.price;
            Save();
        }
        public void DeleteDishString(int id)
        {
            dish_string p = db.dish_string.Find(id);
            if (p != null)
            {
                db.dish_string.Remove(p);
                Save();
            }
        }

        public List<dishstringDto> GetAllDishString()
        {
            db.dish_string.ToList();
            var res = db.dish_string.ToList();
            return res.Select(i => new dishstringDto(i)).ToList();
        }
    }
}
