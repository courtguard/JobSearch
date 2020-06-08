using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class ApplicantsForJob
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public string eAddress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Location { get; set; }
        public string Education { get; set; }
        public string CV { get; set; }
        public int Experience { get; set; }
        public string PreviousProjects { get; set; }
        public string Approved { get; set; }
        public int ProfileId { get; set; }

        public ApplicantsForJob() { }
        public ApplicantsForJob(int j,string e,string n,string s,string l,string ed,string c,int ex,string p,string a,int i)
        {
            JobId =j;
            eAddress = e;
            Name = n;
            Surname = s;
            Location = l;
            Education = ed;
            CV = c;
            Experience = ex;
            PreviousProjects = p;
            Approved = a;
            ProfileId = i;
        }
    }
}