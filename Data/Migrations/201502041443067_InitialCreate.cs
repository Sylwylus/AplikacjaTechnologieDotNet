namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PublishedDate = c.DateTime(nullable: false),
                        Publisher = c.String(),
                        PlayingTime = c.Int(nullable: false),
                        MinNumberOfPlayers = c.Int(nullable: false),
                        MaxNumberOfPlayers = c.Int(nullable: false),
                        SuggestedAge = c.Int(nullable: false),
                        Description = c.String(),
                        Photo = c.Binary(),
                        Accepted = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublishedDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        GameId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Moderator = c.Boolean(nullable: false),
                        Administrator = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        UserName = c.String(nullable: false, maxLength: 256),
                        DateOfBirth = c.DateTime(nullable: false),
                        Photo = c.Binary(),
                        RegisterDate = c.DateTime(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Gameplay",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublishedDate = c.DateTime(nullable: false),
                        GameId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublishedDate = c.DateTime(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        PublishedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublishedDate = c.DateTime(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        Accepted = c.Boolean(nullable: false),
                        GameId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Problem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublishedDate = c.DateTime(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Problem", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Review", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Review", "GameId", "dbo.Game");
            DropForeignKey("dbo.Rate", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rate", "GameId", "dbo.Game");
            DropForeignKey("dbo.News", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gameplay", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gameplay", "GameId", "dbo.Game");
            DropForeignKey("dbo.Comment", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comment", "GameId", "dbo.Game");
            DropForeignKey("dbo.Game", "CategoryId", "dbo.Category");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Problem", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "GameId" });
            DropIndex("dbo.Rate", new[] { "UserId" });
            DropIndex("dbo.Rate", new[] { "GameId" });
            DropIndex("dbo.News", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Gameplay", new[] { "UserId" });
            DropIndex("dbo.Gameplay", new[] { "GameId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropIndex("dbo.Comment", new[] { "GameId" });
            DropIndex("dbo.Game", new[] { "CategoryId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Problem");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Review");
            DropTable("dbo.Rate");
            DropTable("dbo.News");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Gameplay");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comment");
            DropTable("dbo.Game");
            DropTable("dbo.Category");
        }
    }
}
