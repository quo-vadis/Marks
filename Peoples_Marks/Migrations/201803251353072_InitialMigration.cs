namespace Peoples_Marks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.People", "IX_FullName");
            AlterColumn("dbo.People", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.People", "LastName", c => c.String(maxLength: 50));
            CreateIndex("dbo.People", new[] { "FirstName", "LastName" }, unique: true, name: "IX_FullName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.People", "IX_FullName");
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String());
            CreateIndex("dbo.People", new[] { "FirstName", "LastName" }, unique: true, name: "IX_FullName");
        }
    }
}
