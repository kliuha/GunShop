namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Order", "CreatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
