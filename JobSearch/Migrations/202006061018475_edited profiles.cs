namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedprofiles : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Profiles", "eAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "eAddress", c => c.String());
            AlterColumn("dbo.Profiles", "Password", c => c.String());
            AlterColumn("dbo.Profiles", "Username", c => c.String());
        }
    }
}
