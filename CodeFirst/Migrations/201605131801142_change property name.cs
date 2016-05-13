namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepropertyname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ProductName", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "ItemName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ItemName", c => c.String());
            DropColumn("dbo.Orders", "ProductName");
        }
    }
}
