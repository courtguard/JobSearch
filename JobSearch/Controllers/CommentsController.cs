using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobSearch.Models.JobModels;

namespace JobSearch.Controllers.JobControllers
{
    public class CommentsController : Controller
    {
        private EmploymentContext db = new EmploymentContext();

        // GET: Comments
        public ActionResult Index()
        {
            int jobId = 0;
            List<Comment> comment = db.Comments.ToList();
            List<Comment> co = new List<Comment>();
            HttpCookie reqJobId = Request.Cookies["JobId"];
            jobId = Convert.ToInt32(reqJobId["JobId"].ToString());
            foreach (Comment c in comment)
            {
                if (c.JobId == jobId)
                {
                    co.Add(c);
                }
            }

            //var comments = db.Comments.Include(c => c.Job).Include(c => c.Profile);
            return View(co.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            //HttpCookie reqCookies = Request.Cookies["userInfo"];
            //HttpCookie reqJobId = Request.Cookies["JobId"];
            //ViewBag.JobId = Convert.ToInt32(reqJobId["JobId"].ToString());
            //ViewBag.Profileid = Convert.ToInt32(reqCookies["Id"].ToString());
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Position");
            ViewBag.Profileid = new SelectList(db.Profiles, "Id", "Username");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "Profileid,JobId,comment")] Comment comment*/string txt)
        {
            Comment comments = new Comment();
            comments.comment = txt;
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            HttpCookie reqJobId = Request.Cookies["JobId"];
            comments.JobId = Convert.ToInt32(reqJobId["JobId"].ToString());
            comments.Profileid = Convert.ToInt32(reqCookies["Id"].ToString());
            if (ModelState.IsValid)
            {
                db.Comments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.JobId = new SelectList(db.Jobs, "Id", "Position", comment.JobId);
            //ViewBag.Profileid = new SelectList(db.Profiles, "Id", "Username", comment.Profileid);
            return View(/*comment*/);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Position", comment.JobId);
            ViewBag.Profileid = new SelectList(db.Profiles, "Id", "Username", comment.Profileid);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Profileid,JobId,comment")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "Position", comment.JobId);
            ViewBag.Profileid = new SelectList(db.Profiles, "Id", "Username", comment.Profileid);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
    }
}
