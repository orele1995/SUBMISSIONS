﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace DatabaseManager
{
    public class PricesContext : DbContext
    {        
        public PricesContext() : base("PricesContext") { }

        public DbSet<Chain> Chains { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chain>()
               .Property(c => c.ChainID)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Item>()
             .Property(i => i.ItemID)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }

        public void addOrUpdateStore (Store store)
        {
            if (Stores.Find(store) == null)
                Stores.AddOrUpdate(store);
            SaveChanges();
        }
        public void addOrUpdateChain( Chain chain)
        {
            if (Chains.Find(chain) == null)
                Chains.AddOrUpdate(chain);
            SaveChanges();
        }
        public void addOrUpdateItem(Item item)
        {
            if (Items.Find(item) == null)
                if(item.ItemID>1000000000)
                Items.AddOrUpdate(item);
            SaveChanges();
        }

    }
}
