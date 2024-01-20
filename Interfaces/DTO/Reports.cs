using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class SPResult
    {
        public int? id { get; set; }
        public string order_status { get; set; }
        public int summ { get; set; }
        public string adress { get; set; }
        public string dish { get; set; }
        public int delivery_price { get; set; }
        public int number_cli { get; set; }

    }
    public class ReportData
    {
        public string Dish { get; set; }
        public int? Summ { get; set; }
        public string adress { get; set; }
        public int? id_order { get; set; }
        public string number_cli { get; set; }

    }
}
