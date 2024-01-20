//using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Interfaces.DTO;
using System.Reflection;

namespace BLL.DTO
{
    public class orderDto
    {
        public int? summ { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(8000)]
        public string order_status { get; set; }

        public int? id_stol { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(8000)]
        public string OrderedDishes { get; set; }
        public List<int> OrderedDishesIds { get; set; }
        public orderDto() { }
        public orderDto(order o)
        {
            summ = o.summ;
            id = o.id;
            order_status = o.order_status;
            id_stol = o.id_stol;
            date = o.date;
            OrderedDishes = String.Join(",", o.dish_string.Select(i => i.dish.name).ToList());
            OrderedDishesIds = o.dish_string.Select(i => (int)i.id_dish).ToList();
        }
    }
}
