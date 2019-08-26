namespace WhistProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreUsernameInAnotherTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "username", c => c.String(nullable: false));
            DropColumn("dbo.Players", "password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "password", c => c.String());
            AlterColumn("dbo.Players", "username", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Players", "email");
        }
    }
}
