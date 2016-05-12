namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addanoncouement : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Announcements", newName: "Annoucements");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Annoucements", newName: "Announcements");
        }
    }
}
