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
        private static PricesContext theDB;

        public static PricesContext TheDB
        {
            get
            {
                if (theDB == null)
                {
                    theDB = new PricesContext();
                }
                return theDB;
            }
        }
        
        private PricesContext() : base("PricesContext") { }

        public DbSet<Chain> Chains { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .Property(s => s.City)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Store>().Property(s => s.City).HasMaxLength(50);
        }

        public void addStore (Store store)
        {
            if (Stores.Find(store) == null)
                Stores.Add(store);
            SaveChanges();
        }
        public void addChain( Chain chain)
        {
            if (Chains.Find(chain) == null)
                Chains.Add(chain);
            SaveChanges();
        }
        public void addItem(Item item)
        {
            if (Items.Find(item) == null)
                Items.Add(item);
            SaveChanges();
        }

    }
}
