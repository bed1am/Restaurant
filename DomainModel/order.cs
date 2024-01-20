namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            deliveries = new HashSet<delivery>();
            dish_string = new HashSet<dish_string>();
        }

        public int? summ { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(8000)]
        public string order_status { get; set; }

        public int? id_stol { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(8000)]
        public string dish { get; set; }

        public bool? pay_summ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<delivery> deliveries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dish_string> dish_string { get; set; }

        public virtual stol stol { get; set; }
    }
}
