namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceComponent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GunId = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gun", t => t.GunId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.GunId)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceComponent", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.PriceComponent", "GunId", "dbo.Gun");
            DropIndex("dbo.PriceComponent", new[] { "Order_Id" });
            DropIndex("dbo.PriceComponent", new[] { "GunId" });
            DropTable("dbo.PriceComponent");
        }
    }
}
