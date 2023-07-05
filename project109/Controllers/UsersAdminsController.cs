using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project109.Models;
using System.Globalization;

namespace project109.Controllers
{
    public class UsersAdminsController : Controller
    {
        private msaadtestEntities db = new msaadtestEntities();

        // GET: UsersAdmins
        public ActionResult Index()
        {
            return View(db.UsersAdmins.ToList());
        }

        // GET: UsersAdmins/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAdmins usersAdmins = db.UsersAdmins.Find(id);
            if (usersAdmins == null)
            {
                return HttpNotFound();
            }
            return View(usersAdmins);
        }
        public ActionResult DoneCreate()
        {
            return View();
        }
        // GET: UsersAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersAdmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RealName,Title,Email,Username,Password,IsAdmin,Active,Phone,Address,UserType,date_insert,last_update")] UsersAdmins usersAdmins)
        {
            //string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy", "dd/MM/yyyy", "MM/dd/yyyyHH:mm:ss" };
            //CultureInfo provider = new CultureInfo("en-US");
            //string date_insert = Request.Form["date_insert"].ToString();
            //DateTime date_insert_param = DateTime.ParseExact(date_insert, dateFormats, provider, DateTimeStyles.AdjustToUniversal);
            //string last_update = Request.Form["last_update"].ToString();
            //DateTime last_update_param = DateTime.ParseExact(last_update, dateFormats, provider, DateTimeStyles.AdjustToUniversal);
            //usersAdmins.date_insert = date_insert_param;
            //usersAdmins.last_update = last_update_param;
            usersAdmins.date_insert = System.DateTime.Now;
            usersAdmins.last_update = System.DateTime.Now;
            EncryptionHelper enchlpr = new EncryptionHelper();
            usersAdmins.Password = enchlpr.Encrypt(Request["Password"]);
            if (ModelState.IsValid)
            {
                db.UsersAdmins.Add(usersAdmins);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("DoneCreate");
            }

            return View(usersAdmins);
        }

        // GET: UsersAdmins/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAdmins usersAdmins = db.UsersAdmins.Find(id);
            if (usersAdmins == null)
            {
                return HttpNotFound();
            }
            return View(usersAdmins);
        }

        // POST: UsersAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RealName,Title,Email,Username,Password,IsAdmin,Active,Phone,Address,UserType,date_insert,last_update")] UsersAdmins usersAdmins)
        {
            EncryptionHelper enchlpr = new EncryptionHelper();
            usersAdmins.Password = enchlpr.Encrypt(Request["Password"]);
            if (ModelState.IsValid)
            {
                db.Entry(usersAdmins).State = EntityState.Modified;
                db.Entry(usersAdmins).Property(x => x.date_insert).IsModified = false;
                usersAdmins.last_update = System.DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("DoneUpdate");
            }
            return View(usersAdmins);
        }
        public ActionResult DoneUpdate()
        {
            return View();
        }
        // GET: UsersAdmins/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersAdmins usersAdmins = db.UsersAdmins.Find(id);
            if (usersAdmins == null)
            {
                return HttpNotFound();
            }
            return View(usersAdmins);
        }

        // POST: UsersAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            UsersAdmins usersAdmins = db.UsersAdmins.Find(id);
            db.UsersAdmins.Remove(usersAdmins);
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
