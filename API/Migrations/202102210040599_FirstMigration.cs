namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Tb_M_Supplier", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Tb_M_Supplier",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Item", "SupplierId", "dbo.Tb_M_Supplier");
            DropIndex("dbo.Tb_M_Item", new[] { "SupplierId" });
            DropTable("dbo.Tb_M_Supplier");
            DropTable("dbo.Tb_M_Item");
        }
    }
}
