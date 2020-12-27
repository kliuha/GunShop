namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gun", "Warehouses_Id", "dbo.Warehouse");
            DropIndex("dbo.Gun", new[] { "Warehouses_Id" });
            AddColumn("dbo.Gun", "WarehousesId", c => c.Int(nullable: false));
            DropColumn("dbo.Gun", "Warehouses_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gun", "Warehouses_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Gun", "WarehousesId");
            CreateIndex("dbo.Gun", "Warehouses_Id");
            AddForeignKey("dbo.Gun", "Warehouses_Id", "dbo.Warehouse", "Id", cascadeDelete: true);
        }
    }
}
