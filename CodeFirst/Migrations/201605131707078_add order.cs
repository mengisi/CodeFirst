namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubmitTime = c.DateTime(nullable: false),
                        ApproveTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        ItemName = c.String(),
                        Quantity = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Orders");
        }
    }
}
