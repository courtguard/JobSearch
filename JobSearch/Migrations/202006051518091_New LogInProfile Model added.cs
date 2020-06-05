namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewLogInProfileModeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppliesFors",
                c => new
                    {
                        Profileid = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profileid, t.JobId })
                .ForeignKey("dbo.Jobs", t => t.JobId)
                .ForeignKey("dbo.Profiles", t => t.Profileid)
                .Index(t => t.Profileid)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        FullPart = c.String(),
                        Description = c.String(),
                        Qualifications = c.String(),
                        Deadline = c.DateTime(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Profileid = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profileid, t.JobId })
                .ForeignKey("dbo.Jobs", t => t.JobId)
                .ForeignKey("dbo.Profiles", t => t.Profileid)
                .Index(t => t.Profileid)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        eAddress = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Education = c.String(),
                        Location = c.String(),
                        CV = c.String(),
                        Experience = c.Int(nullable: false),
                        PreviousProjects = c.String(),
                        ProfilId = c.Int(nullable: false),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Portfolios", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.Jobs", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Comments", "Profileid", "dbo.Profiles");
            DropForeignKey("dbo.AppliesFors", "Profileid", "dbo.Profiles");
            DropForeignKey("dbo.Comments", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.AppliesFors", "JobId", "dbo.Jobs");
            DropIndex("dbo.Portfolios", new[] { "Profile_Id" });
            DropIndex("dbo.Comments", new[] { "JobId" });
            DropIndex("dbo.Comments", new[] { "Profileid" });
            DropIndex("dbo.Jobs", new[] { "ProfileId" });
            DropIndex("dbo.AppliesFors", new[] { "JobId" });
            DropIndex("dbo.AppliesFors", new[] { "Profileid" });
            DropTable("dbo.Portfolios");
            DropTable("dbo.Profiles");
            DropTable("dbo.Comments");
            DropTable("dbo.Jobs");
            DropTable("dbo.AppliesFors");
        }
    }
}
