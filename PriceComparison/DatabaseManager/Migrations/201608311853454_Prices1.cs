namespace DatabaseManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prices1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Item_type = c.Int(nullable: false),
                        Item_code = c.String(),
                        Chain_id = c.Int(nullable: false),
                        Store_StoreID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Stores", t => t.Store_StoreID)
                .Index(t => t.Store_StoreID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        Chain_id = c.Int(nullable: false),
                        Subchain_id = c.String(),
                        Address = c.String(),
                        City = c.String(maxLength: 50),
                        Zip_code = c.String(),
                        Chain_ChainID = c.Int(),
                    })
                .PrimaryKey(t => t.StoreID)
                .ForeignKey("dbo.Chains", t => t.Chain_ChainID)
                .Index(t => t.Chain_ChainID);
            
            CreateTable(
                "dbo.Chains",
                c => new
                    {
                        ChainID = c.Int(nullable: false, identity: true),
                        Chain_name = c.String(),
                    })
                .PrimaryKey(t => t.ChainID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "Chain_ChainID", "dbo.Chains");
            DropForeignKey("dbo.Items", "Store_StoreID", "dbo.Stores");
            DropIndex("dbo.Stores", new[] { "Chain_ChainID" });
            DropIndex("dbo.Items", new[] { "Store_StoreID" });
            DropTable("dbo.Chains");
            DropTable("dbo.Stores");
            DropTable("dbo.Items");
        }
    }
}
