namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class delivery
    {
        [StringLength(8000)]
        public string adress { get; set; }

        public int? id_order { get; set; }

        public int? delivery_price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(8000)]
        public string number_cli { get; set; }

        public virtual order order { get; set; }
    }
}
