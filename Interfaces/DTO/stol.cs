using DomainModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interfaces.DTO
{
    public class stolDto
    {
        public int id { get; set; }

        public int? number_stol { get; set; }

        public bool? status { get; set; }
        public stolDto() { }
        public stolDto(stol o)
        {
            id = o.id;
            number_stol = o.number_stol;
            status = o.status;
        }
    }
}
