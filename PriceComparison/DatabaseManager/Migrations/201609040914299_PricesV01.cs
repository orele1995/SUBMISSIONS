namespace DatabaseManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PricesV01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chains",
                c => new
                    {
                        ChainID = c.Long(nullable: false),
                        Chain_name = c.String(),
                    })
                .PrimaryKey(t => t.ChainID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        Store_code = c.Int(nullable: false),
                        Chain_id = c.Long(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Chain_ChainID = c.Long(),
                    })
                .PrimaryKey(t => t.StoreID)
                .ForeignKey("dbo.Chains", t => t.Chain_ChainID)
                .Index(t => t.Chain_ChainID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        ItemName = c.String(),
                        ManufacturerName = c.String(),
                        Store_StoreID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Stores", t => t.Store_StoreID)
                .Index(t => t.Store_StoreID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        UnitQty = c.String(),
                        Quantity = c.String(),
                        UnitOfMeasure = c.String(),
                        ItemPrice = c.Double(nullable: false),
                        UnitOfMeasurePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PriceID)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "Chain_ChainID", "dbo.Chains");
            DropForeignKey("dbo.Items", "Store_StoreID", "dbo.Stores");
            DropForeignKey("dbo.Prices", "ItemID", "dbo.Items");
            DropIndex("dbo.Prices", new[] { "ItemID" });
            DropIndex("dbo.Items", new[] { "Store_StoreID" });
            DropIndex("dbo.Stores", new[] { "Chain_ChainID" });
            DropTable("dbo.Prices");
            DropTable("dbo.Items");
            DropTable("dbo.Stores");
            DropTable("dbo.Chains");
        }
    }
}
