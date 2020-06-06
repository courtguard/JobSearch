using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name="Email")]
        public string eAddress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Role { get; set; }

        public ICollection<Job> Job { get; set; }
        public ICollection<AppliesFor> AppliesFor { get; set; }
        public ICollection<Comment> Comment { get; set; }

    }
}