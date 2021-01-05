namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gun", "InStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gun", "InStock");
        }
    }
}
