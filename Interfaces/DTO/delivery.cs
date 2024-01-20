using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class deliveryDto
    {
        [StringLength(8000)]
        public string adress { get; set; }

        public int? id_order { get; set; }

        public int? delivery_price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(8000)]
        public string number_cli { get; set; }
    }
}
