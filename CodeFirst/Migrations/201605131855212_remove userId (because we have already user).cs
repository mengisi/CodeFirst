namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeuserIdbecausewehavealreadyuser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ApplicationUserId", c => c.Int(nullable: false));
        }
    }
}
