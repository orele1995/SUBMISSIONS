using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseManager
{
    public class PricesContext : DbContext
    {

        public PricesContext() : base("PricesContext")
        {
        }

        public DbSet<Chain> StoresChains { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .Property(s => s.City)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Store>().Property(s => s.City).HasMaxLength(50);
        }

    }
}
