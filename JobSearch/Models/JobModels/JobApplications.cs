using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class JobApplications
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string FullPart { get; set; }
        public string Description { get; set; }
        public string Qualifications { get; set; }
        public DateTime Deadline { get; set; }

        public List<int> Applications { get; set; }

        public JobApplications()
        {
            Applications = new List<int>();
        }
        public JobApplications(string p,string f,string d,string q,DateTime dl, List<int> a)
        {
            Position = p;
            FullPart = f;
            Description = d;
            Qualifications = q;
            Deadline = dl;
            Applications = a;
        }

    }
}