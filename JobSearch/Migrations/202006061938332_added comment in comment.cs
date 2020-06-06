namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcommentincomment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "comment");
        }
    }
}
