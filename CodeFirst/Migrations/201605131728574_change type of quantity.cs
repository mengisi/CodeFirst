namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetypeofquantity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Quantity", c => c.Double(nullable: false));
        }
    }
}
