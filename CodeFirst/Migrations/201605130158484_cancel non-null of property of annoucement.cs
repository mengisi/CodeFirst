namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cancelnonnullofpropertyofannoucement : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Annoucements", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Annoucements", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Annoucements", "Updatetime", c => c.DateTime());
            AlterColumn("dbo.Annoucements", "Visits", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Annoucements", "Visits", c => c.Int(nullable: false));
            AlterColumn("dbo.Annoucements", "Updatetime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Annoucements", "Text", c => c.String());
            AlterColumn("dbo.Annoucements", "Title", c => c.String());
        }
    }
}
