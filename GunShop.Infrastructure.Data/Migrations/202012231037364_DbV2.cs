namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Gun", "Warehouses_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Gun", "Warehouses_Id");
            AddForeignKey("dbo.Gun", "Warehouses_Id", "dbo.Warehouse", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gun", "Warehouses_Id", "dbo.Warehouse");
            DropIndex("dbo.Gun", new[] { "Warehouses_Id" });
            DropColumn("dbo.Gun", "Warehouses_Id");
            DropTable("dbo.Warehouse");
        }
    }
}
