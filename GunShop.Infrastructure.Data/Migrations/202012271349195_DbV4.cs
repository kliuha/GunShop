namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "GunId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "GunId");
        }
    }
}
