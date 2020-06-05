using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class Portfolio
    {
        public int Id { get; set; }

        public string Education { get; set; }
        public string Location { get; set; }
        public string CV { get; set; }
        public int Experience { get; set; }
        public string PreviousProjects { get; set; }

        public int ProfilId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}