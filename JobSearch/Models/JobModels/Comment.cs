using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class Comment
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int Profileid { get; set; }

        [Display(Name= "Comment:")]
        public string comment { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Job Job { get; set; }
    }
}