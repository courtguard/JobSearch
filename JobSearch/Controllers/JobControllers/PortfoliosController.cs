using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobSearch.Models.JobModels;

namespace JobSearch.Controllers.JobControllers
{
    public class PortfoliosController : Controller
    {
        private EmploymentContext db = new EmploymentContext();

        // GET: Portfolios
        public ActionResult Index()
        {
            var id = 0;
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                id = Convert.ToInt32(reqCookies["Id"].ToString());
                var user = db.Portfolios.Where(x => x.ProfilId == id).FirstOrDefault();
                if (user != null)
                    return View(user);
            }
            return RedirectToAction("Create");
        }

        // GET: Portfolios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // GET: Portfolios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Education,Location,CV,Experience,PreviousProjects")] Portfolio portfolio)
        {

            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                var id = Convert.ToInt32(reqCookies["Id"].ToString());
                portfolio.ProfilId = id;
                db.Portfolios.Add(portfolio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }      
            return View(portfolio);
        }

        // GET: Portfolios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // POST: Portfolios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Education,Location,CV,Experience,PreviousProjects")] Portfolio portfolio)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                var id = Convert.ToInt32(reqCookies["Id"].ToString());
                portfolio.ProfilId = id;
                db.Entry(portfolio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }

        // GET: Portfolios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            db.Portfolios.Remove(portfolio);
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
