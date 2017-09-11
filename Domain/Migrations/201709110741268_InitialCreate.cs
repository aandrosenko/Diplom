namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventInfoes",
                c => new
                    {
                        EventInfoId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        LogoUrl = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ShopInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventInfoId)
                .ForeignKey("dbo.ShopInfoes", t => t.ShopInfoId, cascadeDelete: true)
                .Index(t => t.ShopInfoId);
            
            CreateTable(
                "dbo.EventReviews",
                c => new
                    {
                        EventReviewId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EventInfoId = c.Int(nullable: false),
                        Text = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventReviewId)
                .ForeignKey("dbo.EventInfoes", t => t.EventInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EventInfoId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ShopInfoes",
                c => new
                    {
                        ShopInfoId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Logo = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                        Owner_UserId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ShopInfoId)
                .ForeignKey("dbo.Users", t => t.Owner_UserId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Owner_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.ShopReviews",
                c => new
                    {
                        ShopReviewId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ShopInfoId = c.Int(nullable: false),
                        Text = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShopReviewId)
                .ForeignKey("dbo.ShopInfoes", t => t.ShopInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ShopInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.ShopInfoes", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.ShopReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.ShopReviews", "ShopInfoId", "dbo.ShopInfoes");
            DropForeignKey("dbo.ShopInfoes", "Owner_UserId", "dbo.Users");
            DropForeignKey("dbo.EventInfoes", "ShopInfoId", "dbo.ShopInfoes");
            DropForeignKey("dbo.EventReviews", "EventInfoId", "dbo.EventInfoes");
            DropIndex("dbo.ShopReviews", new[] { "ShopInfoId" });
            DropIndex("dbo.ShopReviews", new[] { "UserId" });
            DropIndex("dbo.ShopInfoes", new[] { "User_UserId" });
            DropIndex("dbo.ShopInfoes", new[] { "Owner_UserId" });
            DropIndex("dbo.EventReviews", new[] { "EventInfoId" });
            DropIndex("dbo.EventReviews", new[] { "UserId" });
            DropIndex("dbo.EventInfoes", new[] { "ShopInfoId" });
            DropTable("dbo.ShopReviews");
            DropTable("dbo.ShopInfoes");
            DropTable("dbo.Users");
            DropTable("dbo.EventReviews");
            DropTable("dbo.EventInfoes");
        }
    }
}
