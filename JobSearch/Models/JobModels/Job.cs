using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class Job
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string FullPart { get; set; }
        public string Description { get; set; }
        public string Qualifications { get; set; }
        public DateTime Deadline { get; set; }

        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public ICollection<AppliesFor> AppliesFor { get; set; }
        public ICollection<Comment> Comment { get; set; }

    }
}