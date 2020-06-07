namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedidincomment : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AddColumn("dbo.Comments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments");
            DropColumn("dbo.Comments", "Id");
            AddPrimaryKey("dbo.Comments", new[] { "Profileid", "JobId" });
        }
    }
}
