namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV7 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Gun", "WarehousesId", "dbo.Warehouse", "Id", cascadeDelete: true);
          
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gun", "WarehousesId", "dbo.Warehouse");
            
        }
    }
}
