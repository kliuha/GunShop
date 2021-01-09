namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PriceComponent", "GunId", "dbo.Gun");
            DropIndex("dbo.PriceComponent", new[] { "GunId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.PriceComponent", "GunId");
            AddForeignKey("dbo.PriceComponent", "GunId", "dbo.Gun", "Id", cascadeDelete: true);
        }
    }
}
