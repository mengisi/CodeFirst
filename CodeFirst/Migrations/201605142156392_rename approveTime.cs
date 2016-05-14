namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameapproveTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ApproveOrRefuseTime", c => c.DateTime());
            DropColumn("dbo.Orders", "ApproveTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ApproveTime", c => c.DateTime());
            DropColumn("dbo.Orders", "ApproveOrRefuseTime");
        }
    }
}
