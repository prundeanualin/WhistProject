namespace WhistProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2_a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "First_Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Last_Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropColumn("dbo.AspNetUsers", "Last_Name");
            DropColumn("dbo.AspNetUsers", "First_Name");
        }
    }
}
