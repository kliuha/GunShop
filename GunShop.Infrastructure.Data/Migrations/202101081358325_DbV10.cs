namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ammunition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Guns_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gun", t => t.Guns_Id, cascadeDelete: true)
                .Index(t => t.Guns_Id);
            
            DropTable("dbo.Reservation");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Ammunition", "Guns_Id", "dbo.Gun");
            DropIndex("dbo.Ammunition", new[] { "Guns_Id" });
            DropTable("dbo.Ammunition");
        }
    }
}
