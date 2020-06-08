using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.Models.JobModels
{
    public class AppliesFor
    {
        private int? id;
        public int JobId { get; set; }
        public int Profileid { get; set; }
        public string Approved { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual Job Job { get; set; }

        public AppliesFor() { }
        public AppliesFor(int profileId, int id)
        {
            Profileid = profileId;
            JobId = id;
            Approved = "Pending";
        }
    }
}