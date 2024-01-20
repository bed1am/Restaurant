using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DomainModel
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<delivery> deliveries { get; set; }
        public virtual DbSet<dish> dishes { get; set; }
        public virtual DbSet<dish_string> dish_string { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<stol> stols { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dish>()
                .HasMany(e => e.dish_string)
                .WithOptional(e => e.dish)
                .HasForeignKey(e => e.id_dish);

            modelBuilder.Entity<order>()
                .HasMany(e => e.deliveries)
                .WithOptional(e => e.order)
                .HasForeignKey(e => e.id_order);

            modelBuilder.Entity<order>()
                .HasMany(e => e.dish_string)
                .WithOptional(e => e.order)
                .HasForeignKey(e => e.id_order);

            modelBuilder.Entity<stol>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.stol)
                .HasForeignKey(e => e.id_stol);
        }
    }
}
