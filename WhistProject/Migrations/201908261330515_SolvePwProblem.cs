namespace WhistProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolvePwProblem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "password");
        }
    }
}
