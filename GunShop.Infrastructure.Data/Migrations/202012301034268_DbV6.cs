namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PriceComponent", "OrderId", "dbo.Order");
            DropIndex("dbo.PriceComponent", new[] { "OrderId" });
            DropTable("dbo.PriceComponent");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PriceComponent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PriceComponent", "OrderId");
            AddForeignKey("dbo.PriceComponent", "OrderId", "dbo.Order", "Id", cascadeDelete: true);
            
        }
    }
}
