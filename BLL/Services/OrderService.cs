using BLL.DTO;
using DAL;
using DomainModel;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private Model1 db;
        private IDishStringService idhService;
        public OrderService(IDishStringService idhService)
        {
            db = new Model1();
            this.idhService = idhService;
        }
        Random rnd = new Random();
        public bool MakeOrder(int stolid)
        {
            List<KeyValuePair<int, dishDto>> list = idhService.GetBusketDishString(); 
            int sum = 0;
            string status = "cook";
            foreach (var orderedDish in list)
            {
                sum += (int)orderedDish.Value.price;
            }

            //применяем скидку
            sum = (int)new discount(0.1).GetDiscountedPrice(sum);

            order order = new order
            {
                id = (int)db.dishes.Local.ToBindingList().Max(x => x.id) + 1 + (rnd.Next() % 100),
                order_status = status,
                id_stol = stolid,
                date = DateTime.Now,
                summ = sum,

            };
            db.orders.Add(order);
            db.SaveChanges();

            list.ForEach(i => {
                idhService.CreateDishString(i.Value, order.id, i.Key);
            });
            idhService.ClearBusketDishString();
            db.SaveChanges();
            return true;

        }
       
       public List<dishDto> GetOrderedDishes()
        {
            List<dish> orderedDishes = new List<dish>();
            return orderedDishes.Select(i => new dishDto(i)).ToList();
        }
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
        public orderDto GetOrder(int Id)
        {
            return new orderDto(db.orders.Find(Id));
        }
        public void CreateOrder(orderDto p)
        {
            db.orders.Add(new order() { id_stol = p.id_stol, id = p.id, summ = p.summ, order_status = p.order_status});
            Save();
        }
        public void UpdateOrder(orderDto p)
        {
            order ph = db.orders.Find(p.id);
            if (p.id_stol != null)
            {
                ph.stol = db.stols.Find(p.id_stol);
            }
            else { 
                ph.stol = null;
            }
            ph.id_stol = p.id_stol;
            ph.summ = p.summ;
            ph.order_status = p.order_status;
            Save();
        }
        public void DeleteOrder(int id)
        {
            order p = db.orders.Find(id);
            if (p != null)
            {
                db.orders.Remove(p);
                Save();
            }
        }

        public List<orderDto> GetAllOrders()
        {
            var res = db.orders.ToList();
            return res.Select(i => new orderDto(i)).ToList();
        }
    }
}