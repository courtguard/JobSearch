namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcompanyandsalaryinjobApplications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobApplications", "Company", c => c.String());
            AddColumn("dbo.JobApplications", "Salary", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobApplications", "Salary");
            DropColumn("dbo.JobApplications", "Company");
        }
    }
}
