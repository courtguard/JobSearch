using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public partial class MyJobs
    {
        [Display(Name = "Company name")]
        public string Company { get; set; }
        public string Position { get; set; }
        public string FullPart { get; set; }
        public string Description { get; set; }
        public string Qualifications { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }
        public string Approved { get; set; }

        public int ProfileId { get; set; }

    }
}