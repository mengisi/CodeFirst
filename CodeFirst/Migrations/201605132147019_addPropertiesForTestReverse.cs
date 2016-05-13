namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPropertiesForTestReverse : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "Discriminator", newName: "Discriminator1");
           // AlterColumn("dbo.Orders", "Discriminator", c => c.String());
        }
        
        public override void Down()
        {
           // AlterColumn("dbo.Orders", "Discriminator", c => c.String(nullable: true, maxLength: 128));
            RenameColumn(table: "dbo.Orders", name: "Discriminator1", newName: "Discriminator");
        }
    }
}
