namespace JobSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcompanyandsalaryinjob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Company", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "Salary", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "Position", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Position", c => c.String());
            DropColumn("dbo.Jobs", "Salary");
            DropColumn("dbo.Jobs", "Company");
        }
    }
}
