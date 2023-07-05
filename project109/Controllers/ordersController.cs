using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project109.Models;

namespace project109.Controllers
{
    public class ordersController : Controller
    {
        private msaadtestEntities db = new msaadtestEntities();

        // GET: orders
        public ActionResult Index()
        {
            int ssnadmin = Convert.ToInt32(Session["adminid"].ToString());
            return View(db.view_orders.Where(a=>a.buyer_id==ssnadmin || a.vendor_id==ssnadmin).OrderByDescending(a=>a.Id).ToList());
        }

        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orders orders = db.orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: orders/Create
        public ActionResult Create(int? id)
        {
            var vendorid = db.view_books.Where(a => a.Id == id).FirstOrDefault();
            ViewBag.vendorid = vendorid.sold_by;
            ViewBag.bookid =id;
            ViewBag.bookname = vendorid.book_Title;
            ViewBag.vendorname = vendorid.RealName;
            return View();
        }

        // POST: orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,order_date,buyer_id,vendor_id,book_id,qty,done_sel,deal_date,canceled")] orders orders)
        {
            orders.order_date = System.DateTime.Now;
            orders.deal_date= null;
           // if (ModelState.IsValid)
           // {
                db.orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("DoneOrder");
            //}

           // return View(orders);
        }
        public ActionResult DoneOrder()
        {
            return View();
        }
        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {
             
             var orderid = db.view_orders.Where(a => a.Id == id).FirstOrDefault();
            ViewBag.vendorid = orderid.vendor_id;
            ViewBag.bookid = orderid.Id;
            ViewBag.bookname = orderid.book_Title;
            ViewBag.vendorname = orderid.vendorname;
            //user data
            var userdata = db.view_users.Where(a => a.Id == orderid.buyer_id).FirstOrDefault();
            ViewBag.buyername = userdata.RealName;
            ViewBag.buyerphone = userdata.Phone;
            ViewBag.buyeremail = userdata.Email;
            ViewBag.buyeraddress = userdata.Address;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orders orders = db.orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,order_date,buyer_id,vendor_id,book_id,qty,done_sel,deal_date,canceled")] orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.Entry(orders).Property(x => x.order_date).IsModified = false;
                orders.deal_date = System.DateTime.Now;
                var stts = Request.Form["lststatus"];
                if (stts.ToString() == "1")
                {
                    orders.done_sel = true;
                    orders.canceled = false;
                }
                else {
                    orders.done_sel = false;
                    orders.canceled = true;
                }



                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orders);
        }

        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orders orders = db.orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orders orders = db.orders.Find(id);
            db.orders.Remove(orders);
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
