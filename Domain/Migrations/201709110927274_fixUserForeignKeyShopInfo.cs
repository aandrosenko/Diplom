namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixUserForeignKeyShopInfo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ShopInfoes", "UserId");
            RenameColumn(table: "dbo.ShopInfoes", name: "Owner_UserId", newName: "UserId");
            RenameIndex(table: "dbo.ShopInfoes", name: "IX_Owner_UserId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ShopInfoes", name: "IX_UserId", newName: "IX_Owner_UserId");
            RenameColumn(table: "dbo.ShopInfoes", name: "UserId", newName: "Owner_UserId");
            AddColumn("dbo.ShopInfoes", "UserId", c => c.Int(nullable: false));
        }
    }
}
