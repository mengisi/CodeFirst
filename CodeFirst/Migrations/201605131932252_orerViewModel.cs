namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orerViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "FirstName", c => c.String());
            AddColumn("dbo.Orders", "LastName", c => c.String());
            AddColumn("dbo.Orders", "Email", c => c.String());
            AddColumn("dbo.Orders", "UserId", c => c.String());
            AddColumn("dbo.Orders", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Discriminator");
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.Orders", "Email");
            DropColumn("dbo.Orders", "LastName");
            DropColumn("dbo.Orders", "FirstName");
        }
    }
}
