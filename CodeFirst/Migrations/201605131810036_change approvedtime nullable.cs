namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeapprovedtimenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "ApproveTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "ApproveTime", c => c.DateTime(nullable: false));
        }
    }
}
