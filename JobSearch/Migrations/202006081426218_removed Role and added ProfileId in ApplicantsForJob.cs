namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedRoleandaddedProfileIdinApplicantsForJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicantsForJobs", "ProfileId", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicantsForJobs", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicantsForJobs", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicantsForJobs", "ProfileId");
        }
    }
}
