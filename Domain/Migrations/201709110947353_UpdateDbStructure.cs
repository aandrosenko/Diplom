namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDbStructure : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventInfoes", newName: "EventInfo");
            RenameTable(name: "dbo.EventReviews", newName: "EventReview");
            RenameTable(name: "dbo.Users", newName: "User");
            RenameTable(name: "dbo.ShopInfoes", newName: "ShopInfo");
            RenameTable(name: "dbo.ShopReviews", newName: "ShopReview");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ShopReview", newName: "ShopReviews");
            RenameTable(name: "dbo.ShopInfo", newName: "ShopInfoes");
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.EventReview", newName: "EventReviews");
            RenameTable(name: "dbo.EventInfo", newName: "EventInfoes");
        }
    }
}
