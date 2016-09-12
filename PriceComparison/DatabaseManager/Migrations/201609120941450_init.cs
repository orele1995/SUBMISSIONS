namespace DatabaseManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chains",
                c => new
                    {
                        ChainID = c.Long(nullable: false),
                        ChainName = c.String(),
                    })
                .PrimaryKey(t => t.ChainID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        StoreCode = c.Int(nullable: false),
                        ChainID = c.Long(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.StoreID)
                .ForeignKey("dbo.Chains", t => t.ChainID, cascadeDelete: true)
                .Index(t => t.ChainID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceID = c.Long(nullable: false, identity: true),
                        ItemID = c.Long(nullable: false),
                        StoreID = c.Int(nullable: false),
                        ItemPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PriceID)
                .ForeignKey("dbo.Stores", t => t.StoreID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Long(nullable: false),
                        ItemName = c.String(),
                        ManufacturerName = c.String(),
                        Quantity = c.String(),
                    })
                .PrimaryKey(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Stores", "ChainID", "dbo.Chains");
            DropForeignKey("dbo.Prices", "StoreID", "dbo.Stores");
            DropIndex("dbo.Prices", new[] { "StoreID" });
            DropIndex("dbo.Prices", new[] { "ItemID" });
            DropIndex("dbo.Stores", new[] { "ChainID" });
            DropTable("dbo.Items");
            DropTable("dbo.Prices");
            DropTable("dbo.Stores");
            DropTable("dbo.Chains");
        }
    }
}
