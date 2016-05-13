namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class text2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "FirstName");
            DropColumn("dbo.Orders", "LastName");
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.Orders", "Email");
           // RenameColumn(table: "dbo.Orders", name: "Discriminator1", newName: "Discriminator");
           // AlterColumn("dbo.Orders", "Discriminator", c => c.String(nullable: false, maxLength: 128));
          //  AlterColumn("dbo.Orders", "Discriminator1", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Discriminator1", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Orders", "Discriminator", c => c.String());
            RenameColumn(table: "dbo.Orders", name: "Discriminator", newName: "Discriminator1");
            AddColumn("dbo.Orders", "Discriminator", c => c.String());
        }
    }
}
