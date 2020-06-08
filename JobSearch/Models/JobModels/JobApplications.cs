using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class JobApplications
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Position { get; set; }
        [Display(Name = "Company name")]
        public string Company { get; set; }
        public string FullPart { get; set; }
        public string Description { get; set; }
        public string Qualifications { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }

        public List<int> Applications { get; set; }

        public JobApplications()
        {
            Applications = new List<int>();
        }
        public JobApplications(int j,string p,string f,string d,string q, List<int> a,string c,int s)
        {
            JobId = j;
            Position = p;
            Company = c;
            FullPart = f;
            Description = d;
            Qualifications = q;
            Applications = a;
            Salary = s;
        }

    }
}