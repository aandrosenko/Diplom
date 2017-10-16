namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDoubleForeignKeyShopInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShopInfo", "FK_dbo.ShopInfoes_dbo.Users_User_UserId");
            DropIndex("dbo.ShopInfo", new[] { "User_UserId" });
            DropColumn("dbo.ShopInfo", "User_UserId");
        }

        public override void Down()
        {
            AddColumn("dbo.ShopInfo", "User_UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShopInfo", "User_UserId");
            AddForeignKey("dbo.ShopInfo", "UserId", "dbo.User", "UserId", false, "FK_dbo.ShopInfoes_dbo.Users_User_UserId");
        }
    }
}
