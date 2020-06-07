namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deadlinedeletedfromJob : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "Deadline");
            DropColumn("dbo.JobApplications", "Deadline");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobApplications", "Deadline", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "Deadline", c => c.DateTime(nullable: false));
        }
    }
}
