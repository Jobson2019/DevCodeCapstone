namespace Pubcrew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amenities",
                c => new
                    {
                        amenityId = c.Int(nullable: false, identity: true),
                        supplyName = c.String(),
                        amProductLineName = c.String(),
                        locationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.amenityId)
                .ForeignKey("dbo.Inventories", t => t.locationId, cascadeDelete: true)
                .Index(t => t.locationId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        productDescription = c.String(),
                        currentInventory = c.Int(nullable: false),
                        locationId = c.Int(nullable: false),
                        AppUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.Locations", t => t.locationId, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_UserId)
                .Index(t => t.locationId)
                .Index(t => t.AppUser_UserId);
            
            CreateTable(
                "dbo.Beverages",
                c => new
                    {
                        beverageId = c.Int(nullable: false, identity: true),
                        brandName = c.String(),
                        bevProductLineName = c.String(),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.beverageId)
                .ForeignKey("dbo.Inventories", t => t.BusinessId, cascadeDelete: true)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        foodName = c.String(),
                        foodProductLineName = c.String(),
                        inventoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId)
                .ForeignKey("dbo.Inventories", t => t.inventoryId, cascadeDelete: true)
                .Index(t => t.inventoryId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        locationName = c.String(),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        BusinessId = c.Int(nullable: false, identity: true),
                        businessName = c.String(),
                    })
                .PrimaryKey(t => t.BusinessId);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.BizRoles",
                c => new
                    {
                        bizRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.bizRoleId)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BizRoles", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Inventories", "AppUser_UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Amenities", "locationId", "dbo.Inventories");
            DropForeignKey("dbo.Inventories", "locationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Foods", "inventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Beverages", "BusinessId", "dbo.Inventories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.BizRoles", new[] { "UserId" });
            DropIndex("dbo.Locations", new[] { "BusinessId" });
            DropIndex("dbo.Foods", new[] { "inventoryId" });
            DropIndex("dbo.Beverages", new[] { "BusinessId" });
            DropIndex("dbo.Inventories", new[] { "AppUser_UserId" });
            DropIndex("dbo.Inventories", new[] { "locationId" });
            DropIndex("dbo.Amenities", new[] { "locationId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.BizRoles");
            DropTable("dbo.AppUsers");
            DropTable("dbo.Businesses");
            DropTable("dbo.Locations");
            DropTable("dbo.Foods");
            DropTable("dbo.Beverages");
            DropTable("dbo.Inventories");
            DropTable("dbo.Amenities");
        }
    }
}
