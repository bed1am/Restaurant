using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class dishDto
    {
        
            [StringLength(8000)]
            public string name { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int id { get; set; }

            public int? weight { get; set; }

            public int? price { get; set; }

            public int? time_cook { get; set; }

            [StringLength(8000)]
            public string category { get; set; }
            public dishDto() { }
            public dishDto(dish o)
            {
                name = o.name;
                id = o.id;
                weight = o.weight;
                price = o.price;
                time_cook = o.time_cook;
                category = o.category;
            }
    }
}
