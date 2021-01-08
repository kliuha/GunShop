namespace GunShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ammunition", "Guns_Id", "dbo.Gun");
            DropIndex("dbo.Ammunition", new[] { "Guns_Id" });
            DropTable("dbo.Ammunition");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ammunition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Guns_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Ammunition", "Guns_Id");
            AddForeignKey("dbo.Ammunition", "Guns_Id", "dbo.Gun", "Id", cascadeDelete: true);
        }
    }
}
