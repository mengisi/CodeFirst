namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isApprovednullableinorder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "IsApproved", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "IsApproved", c => c.Boolean(nullable: false));
        }
    }
}
