using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class EmploymentContext : System.Data.Entity.DbContext
    {
        public EmploymentContext() : base("DefaultConnection")
        {

        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AppliesFor> AppliesFors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppliesFor>().HasKey(vf => new { vf.Profileid, vf.JobId });
            modelBuilder.Entity<Comment>().HasKey(vf => new { vf.Profileid, vf.JobId });
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}