namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doubletodecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Total", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "Price", c => c.Double(nullable: false));
        }
    }
}
