﻿using System;
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
    public class JobsController : Controller
    {
        private EmploymentContext db = new EmploymentContext();

        // GET: Jobs
        public ActionResult Index()
        {

            List<Job> jobs = new List<Job>(); 
            string search = string.Empty;
            HttpCookie searchCookie = Request.Cookies["searchCookie"];
            if (searchCookie != null)
            {
                search = searchCookie["Search"];
                jobs = db.Jobs.Where(x => x.Position.Contains(search)).ToList();
            }
            else
            {
                jobs = db.Jobs.ToList();
            }
            string sort = string.Empty;
            HttpCookie sortCookie = Request.Cookies["sortCookie"];
            if (sortCookie != null)
            {
                sort = sortCookie["sort"];
                if(sort=="Ascending")
                    for (int i = 0; i < jobs.Count - 1; i++)
                    {
                        for (int j = i + 1; j < jobs.Count; j++)
                        {
                            if (jobs[i].Salary > jobs[j].Salary)
                            {
                                Job tmp = jobs[i];
                                jobs[i] = jobs[j];
                                jobs[j] = tmp;
                            }
                        }
                    }
                else if(sort=="Descending")
                    for (int i = 0; i < jobs.Count - 1; i++)
                    {
                        for (int j = i + 1; j < jobs.Count; j++)
                        {
                            if (jobs[i].Salary < jobs[j].Salary)
                            {
                                Job tmp = jobs[i];
                                jobs[i] = jobs[j];
                                jobs[j] = tmp;
                            }
                        }
                    }

            }

            return View(jobs);
        }

        public ActionResult AllJobs()
        {
            if (Request.Cookies["sortCookie"] != null)
            {
                var c1 = new HttpCookie("sortCookie");
                c1.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c1);
            }
            if (Request.Cookies["searchCookie"] != null)
            {
                var c1 = new HttpCookie("searchCookie");
                c1.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c1);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Ascending()
        {
            HttpCookie sortCookie = new HttpCookie("sortCookie");
            sortCookie["sort"] = "Ascending";
            Response.Cookies.Add(sortCookie);
            return RedirectToAction("Index");
        }
        public ActionResult Descending()
        {
            HttpCookie sortCookie = new HttpCookie("sortCookie");
            sortCookie["sort"] = "Descending";
            Response.Cookies.Add(sortCookie);
            return RedirectToAction("Index");
        }
        // GET: Jobs/Details/5
        public ActionResult Details(int id)
        {
            int userid = 0;
            HttpCookie jobId = new HttpCookie("JobId");
            jobId["JobId"] = id.ToString();
            Response.Cookies.Add(jobId);
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                string Position = db.Jobs.Where(x => x.Id == id).FirstOrDefault().Position;
                string FullPart = db.Jobs.Where(x => x.Id == id).FirstOrDefault().FullPart;
                string Description = db.Jobs.Where(x => x.Id == id).FirstOrDefault().Description;
                string Qualifications = db.Jobs.Where(x => x.Id == id).FirstOrDefault().Qualifications;
                string Company = db.Jobs.Where(x => x.Id == id).FirstOrDefault().Company;
                int Salary = Convert.ToInt32(db.Jobs.Where(x => x.Id == id).FirstOrDefault().Salary);
                userid = Convert.ToInt32(reqCookies["Id"].ToString());
                List<AppliesFor> appliesfor = db.AppliesFors.ToList();
                List<int> Applications = new List<int>();
                foreach (AppliesFor a in appliesfor)
                {
                    if (a.JobId == id)
                    {
                        Applications.Add(a.Profileid);
                    }
                }
                JobApplications model = new JobApplications(id, Position, FullPart, Description, Qualifications, Applications,Company,Salary);
                return View(model);
            }
            return View();
        }


        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.ProfileId = new SelectList(db.Profiles, "Id", "Username");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Position,FullPart,Description,Qualifications,ProfileId,Company,Salary")] Job job)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                var id = Convert.ToInt32(reqCookies["Id"].ToString());
                job.ProfileId = id;
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileId = new SelectList(db.Profiles, "Id", "Username", job.ProfileId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            List<Comment> comments = db.Comments.ToList();
            foreach (Comment comment in comments)
            {
                if (comment.JobId == id)
                {
                    db.Comments.Remove(comment);
                }
            }
            List<AppliesFor> applies = db.AppliesFors.ToList();
            foreach (AppliesFor a in applies)
            {
                if (a.JobId == id)
                {
                    db.AppliesFors.Remove(a);
                }
            }
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Apply(int id)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                int profileId = Convert.ToInt32(reqCookies["Id"].ToString());
                var application = db.AppliesFors.Where(x => x.JobId == id && x.Profileid == profileId).FirstOrDefault();
                if (application == null)
                {
                    AppliesFor app=new AppliesFor(profileId,id);
                    db.AppliesFors.Add(app);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Details","Jobs", new { id = id });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Search(string txt)
        {
            HttpCookie searchCookie = new HttpCookie("searchCookie");
            searchCookie["Search"] = txt;
            Response.Cookies.Add(searchCookie);

            return RedirectToAction("Index");
        }
    }
}
