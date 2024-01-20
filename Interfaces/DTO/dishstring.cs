using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interfaces.DTO
{
    public class dishstringDto
    {
        public int id { get; set; }

        public int? id_dish { get; set; }

        public int? id_order { get; set; }

        public int? numb_dish { get; set; }

        public int? price { get; set; }

        public virtual dish dish { get; set; }

        public virtual order order { get; set; }
        public dishstringDto() { }
        public dishstringDto(dish_string o)
        {
            id = o.id;
            id_dish = o.id_dish;
            id_order = o.id_order;
            numb_dish = o.numb_dish;
            price = o.price;
        }
    }
}
