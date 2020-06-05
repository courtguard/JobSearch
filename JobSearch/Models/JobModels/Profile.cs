using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class Profile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string eAddress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Role { get; set; }

        public ICollection<Job> Job { get; set; }
        public ICollection<AppliesFor> AppliesFor { get; set; }
        public ICollection<Comment> Comment { get; set; }

    }
}