﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using PriceComperationModel;

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
    }
}
