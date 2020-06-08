using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobSearch.Models.JobModels;

namespace JobSearch.Controllers
{
    public class ApplicantsForJobsController : Controller
    {
        private EmploymentContext db = new EmploymentContext();

        // GET: ApplicantsForJobs
        public ActionResult Index()
        {
            HttpCookie reqJobId = Request.Cookies["JobId"];
            int JobId=Convert.ToInt32(reqJobId["JobId"].ToString());
            List < ApplicantsForJob >model= new List<ApplicantsForJob>();
            List<AppliesFor> lista = db.AppliesFors.ToList();
            foreach (AppliesFor a in lista)
            {
                if (a.JobId == JobId)
                {
                    var profile = db.Profiles.Where(x => x.Id == a.Profileid).FirstOrDefault();
                    var portfolio = db.Portfolios.Where(x => x.ProfilId == a.Profileid).FirstOrDefault();
                    var apply = db.AppliesFors.Where(x => x.Profileid == a.Profileid && x.JobId == JobId).FirstOrDefault();
                    if(profile!=null && portfolio!=null)
                        model.Add(new ApplicantsForJob(JobId, profile.eAddress, profile.Name, profile.Surname, portfolio.Location, portfolio.Education, portfolio.CV, portfolio.Experience, portfolio.PreviousProjects,apply.Approved,profile.Id));
                }
            }
            return View(model);
        }

        // GET: ApplicantsForJobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantsForJob applicantsForJob = db.ApplicantsForJobs.Find(id);
            if (applicantsForJob == null)
            {
                return HttpNotFound();
            }
            return View(applicantsForJob);
        }

        // GET: ApplicantsForJobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicantsForJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobId,eAddress,Name,Surname,Location,Education,CV,Experience,PreviousProjects")] ApplicantsForJob applicantsForJob)
        {
            if (ModelState.IsValid)
            {
                db.ApplicantsForJobs.Add(applicantsForJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicantsForJob);
        }

        // GET: ApplicantsForJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantsForJob applicantsForJob = db.ApplicantsForJobs.Find(id);
            if (applicantsForJob == null)
            {
                return HttpNotFound();
            }
            return View(applicantsForJob);
        }

        // POST: ApplicantsForJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobId,eAddress,Name,Surname,Location,Education,CV,Experience,PreviousProjects")] ApplicantsForJob applicantsForJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantsForJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicantsForJob);
        }

        // GET: ApplicantsForJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantsForJob applicantsForJob = db.ApplicantsForJobs.Find(id);
            if (applicantsForJob == null)
            {
                return HttpNotFound();
            }
            return View(applicantsForJob);
        }

        // POST: ApplicantsForJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicantsForJob applicantsForJob = db.ApplicantsForJobs.Find(id);
            db.ApplicantsForJobs.Remove(applicantsForJob);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Deny(int id)
        {
            HttpCookie reqJobId = Request.Cookies["JobId"];
            int JobId = Convert.ToInt32(reqJobId["JobId"].ToString());
            AppliesFor a= db.AppliesFors.Where(x => x.JobId == JobId && x.Profileid == id).FirstOrDefault();
            a.Approved = "Denied";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Approve(int id)
        {
            HttpCookie reqJobId = Request.Cookies["JobId"];
            int JobId = Convert.ToInt32(reqJobId["JobId"].ToString());
            AppliesFor a = db.AppliesFors.Where(x => x.JobId == JobId && x.Profileid == id).FirstOrDefault();
            a.Approved = "Approved";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
