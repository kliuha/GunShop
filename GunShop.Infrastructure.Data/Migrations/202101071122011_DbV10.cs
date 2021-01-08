namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        GunId = c.Int(nullable: false),
                        OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gun", t => t.GunId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .Index(t => t.GunId)
                .Index(t => t.OrderId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservation", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.Reservation", "GunId", "dbo.Gun");
            DropIndex("dbo.Reservation", new[] { "Order_Id" });
            DropIndex("dbo.Reservation", new[] { "GunId" });
            DropTable("dbo.Reservation");
        }
    }
}
