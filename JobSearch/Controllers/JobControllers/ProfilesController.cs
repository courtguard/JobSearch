using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobSearch.Models.JobModels;

namespace JobSearch.Controllers.JobControllers
{
    public class ProfilesController : Controller
    {
        private EmploymentContext db = new EmploymentContext();

        // GET: Profiles
        public ActionResult Index()
        {
            return View(db.Profiles.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,eAddress,Name,Surname,Role")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                var user = db.Profiles.Where(x => x.Username == profile.Username).FirstOrDefault();
                var user2 = db.Profiles.Where(x => x.eAddress == profile.eAddress).FirstOrDefault();
                if (user == null && user2==null)
                {
                    db.Profiles.Add(profile);
                    db.SaveChanges();
                    HttpCookie userInfo = new HttpCookie("userInfo");
                    userInfo["UserName"] = profile.Username;
                    userInfo["Id"] = profile.Id.ToString();
                    userInfo["Role"] = profile.Role.ToString();
                    userInfo["Name"] = profile.Name;
                    userInfo["Surname"] = profile.Surname;
                    userInfo["eAddress"] = profile.eAddress;
                    userInfo.Expires.Add(new TimeSpan(0, 1, 0));
                    Response.Cookies.Add(userInfo);
                    return RedirectToAction("AllJobs","Jobs");
                }
                else
                {
                    if (user != null)
                        ModelState.AddModelError("", "Username allready exists");
                    else if (user2 != null)
                        ModelState.AddModelError("", "Email allready exists");
                    return View();
                }
            }

            return View(profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Profile profile)
        {
            var user = db.Profiles.Where(x => x.Username == profile.Username && x.Password == profile.Password).FirstOrDefault();
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }
            //System.Diagnostics.Debug.WriteLine(profile.Username);
            HttpCookie userInfo = new HttpCookie("userInfo");
            userInfo["UserName"] = user.Username;
            userInfo["Id"] = user.Id.ToString();
            userInfo["Role"] = user.Role.ToString();
            userInfo["Name"] = user.Name;
            userInfo["Surname"] = user.Surname;
            userInfo["eAddress"] = user.eAddress;
            userInfo.Expires.Add(new TimeSpan(0, 1, 0));
            Response.Cookies.Add(userInfo);

            return RedirectToAction("AllJobs", "Jobs");
            
        }
        public ActionResult LogOff()
        {
            if (Request.Cookies["userInfo"] != null)
            {
                var c = new HttpCookie("userInfo");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("AllJobs", "Jobs");
        }
    }
}
