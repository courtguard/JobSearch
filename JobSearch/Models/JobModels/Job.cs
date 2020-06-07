using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [Display(Name = "Company name")]
        public string Company { get; set; }
        [Display(Name ="Full time / Part time")]
        public string FullPart { get; set; }
        public string Description { get; set; }
        public string Qualifications { get; set; }
        public int Salary { get; set; }

        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public ICollection<AppliesFor> AppliesFor { get; set; }
        public ICollection<Comment> Comment { get; set; }

    }
}