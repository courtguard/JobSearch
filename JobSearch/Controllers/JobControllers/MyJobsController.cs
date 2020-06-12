using JobSearch.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobSearch.Controllers.JobControllers
{
    public class MyJobsController : Controller
    {
        private EmploymentContext db = new EmploymentContext();

        // GET: MyJobs
        public async Task<ActionResult> Index()
        {
            int userid = 0;
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            userid = Convert.ToInt32(reqCookies["Id"].ToString());

            List<MyJobs> mj = new List<MyJobs>();
            var list = db.Jobs.Join(db.AppliesFors,
               job => job.Id,
               applies => applies.JobId,
               (job, applies) => new
               {
                   Company = job.Company,
                   Position = job.Position,
                   FullPart = job.FullPart,
                   Description = job.Description,
                   Qualifications = job.Qualifications,
                   Location = job.Location,
                   Salary = job.Salary,
                   Approved = applies.Approved,
                   ProfileId = applies.Profileid
               });

            foreach (var l in list)
            {
                if (l.ProfileId==userid)
                {
                    MyJobs m = new MyJobs();
                    m.Company = l.Company;
                    m.Position = l.Position;
                    m.FullPart = l.FullPart;
                    m.Description = l.Description;
                    m.Qualifications = l.Qualifications;
                    m.Location = l.Location;
                    m.Salary = l.Salary;
                    m.Approved = l.Approved;
                    m.ProfileId = l.ProfileId;
                    mj.Add(m);
                }
            }
            return View(mj);
        }
    }
}