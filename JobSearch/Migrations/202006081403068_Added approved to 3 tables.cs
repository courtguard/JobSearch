namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedapprovedto3tables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicantsForJobs", "Approved", c => c.String());
            AddColumn("dbo.ApplicantsForJobs", "Role", c => c.Int(nullable: false));
            AddColumn("dbo.AppliesFors", "Approved", c => c.String());
            AddColumn("dbo.Jobs", "Location", c => c.String());
            AddColumn("dbo.JobApplications", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobApplications", "Location");
            DropColumn("dbo.Jobs", "Location");
            DropColumn("dbo.AppliesFors", "Approved");
            DropColumn("dbo.ApplicantsForJobs", "Role");
            DropColumn("dbo.ApplicantsForJobs", "Approved");
        }
    }
}
