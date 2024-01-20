namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dish_string
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? id_dish { get; set; }

        public int? id_order { get; set; }

        public int? numb_dish { get; set; }

        public int? price { get; set; }

        public virtual dish dish { get; set; }

        public virtual order order { get; set; }
    }
}
