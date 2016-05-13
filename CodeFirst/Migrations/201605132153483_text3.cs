namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class text3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "FirstName");
            DropColumn("dbo.Orders", "LastName");
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.Orders", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Discriminator1", c => c.String());
        }
    }
}
