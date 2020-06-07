namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedApplicantsForJobs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicantsForJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        eAddress = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Location = c.String(),
                        Education = c.String(),
                        CV = c.String(),
                        Experience = c.Int(nullable: false),
                        PreviousProjects = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicantsForJobs");
        }
    }
}
