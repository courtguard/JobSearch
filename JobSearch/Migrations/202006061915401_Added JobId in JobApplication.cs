namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedJobIdinJobApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobApplications", "JobId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobApplications", "JobId");
        }
    }
}
