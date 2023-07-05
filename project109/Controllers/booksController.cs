using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project109.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace project109.Controllers
{

    public class booksController : Controller
    {
        private msaadtestEntities db = new msaadtestEntities();

        // GET: books
        public ActionResult Index()
        {
            int ssnadmin = Convert.ToInt32(Session["adminid"].ToString());
            return View(db.view_books.Where(a=>a.sold_by== ssnadmin).OrderByDescending(a=>a.Id).ToList());
        }
        public ActionResult Fair(string txtttl,int? ddlcat)
        {
            var results = db.view_books.Where(a => a.active == true).OrderByDescending(a => a.Id).ToList();
            if (txtttl != null && txtttl != "") { results = results.Where(a => a.book_Title.Contains(txtttl)).ToList();  }
            if (ddlcat != 0 && ddlcat != null) { results = results.Where(a => a.book_cat == ddlcat).ToList();  }
            ViewBag.ddlcat = new SelectList(db.books_categories, "Id", "cat_name");
            return View(results);
        }
        // GET: books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // books books = db.books.Find(id);
            var x= db.view_books.Where(a => a.Id == id).FirstOrDefault();
            //books books = x;
            if (x == null)
            {
                return HttpNotFound();
            }
            return View(x);
        }

        // GET: books/Create
        public ActionResult Create()
        {
            ViewBag.author_id = new SelectList(db.authors, "Id", "author_name");
            ViewBag.publisher_id = new SelectList(db.publishers, "Id", "publisher_name");
            ViewBag.book_cat = new SelectList(db.books_categories, "Id", "cat_name");
            return View();
        }

        // POST: books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,book_Title,price,author_id,sold_by,publisher_id,publishing_year,stock,book_cover,book_softcopy,date_insert,last_update,active,book_language,book_cat")] books books, HttpPostedFileBase book_cover, HttpPostedFileBase book_softcopy)
        {
            try
            {
                // if (ModelState.IsValid)
                //  {

                //string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy", "dd/MM/yyyy", "MM/dd/yyyyHH:mm:ss" };
                //CultureInfo provider = new CultureInfo("en-US");
                //string date_insert = Request.Form["date_insert"].ToString();
                //DateTime date_insert_param = DateTime.ParseExact(date_insert, dateFormats, provider, DateTimeStyles.AdjustToUniversal);
                //string last_update = Request.Form["last_update"].ToString();
                //DateTime last_update_param = DateTime.ParseExact(last_update, dateFormats, provider, DateTimeStyles.AdjustToUniversal);
                //books.date_insert = date_insert_param;
                //books.last_update = last_update_param;
                books.date_insert = System.DateTime.Now;
                books.last_update = System.DateTime.Now;
                //upload photo code
                if (book_cover == null)
                {
                    ModelState.AddModelError("img", "Enter file");

                }
                else
                {
                    string[] allowindex = new string[] { ".jpg", ".gif", ".png" };
                    if (!allowindex.Contains(book_cover.FileName.Substring(book_cover.FileName.LastIndexOf("."))))
                    {
                        ModelState.AddModelError("img", "Wrong file");
                    }
                    else
                    {
                        //int maxwds = 120; int newwds = 0;
                        string initpath = "~/Content/images/Covers/";
                        var filename = Path.GetFileName(book_cover.FileName);
                        var paths = Path.Combine(Server.MapPath(initpath), "project109_" + filename);
                        book_cover.SaveAs(paths);
                        books.book_cover = "project109_" + filename;

                    }
                }
                //end upload

                //upload Content code
                if (book_softcopy == null)
                {
                    ModelState.AddModelError("doc", "Enter file");
                }
                else
                {
                    string[] allowindex2 = new string[] { ".docx", ".pdf", ".doc" };
                    if (!allowindex2.Contains(book_softcopy.FileName.Substring(book_softcopy.FileName.LastIndexOf("."))))
                    {
                        ModelState.AddModelError("doc", "Wrong file");
                    }
                    else
                    {
                        
                        string initpath2 = "~/Content/images/Docs/";
                        var filename2 = Path.GetFileName(book_softcopy.FileName);
                        var paths2 = Path.Combine(Server.MapPath(initpath2), "project109docs_" + filename2);
                        book_softcopy.SaveAs(paths2);
                        books.book_softcopy = "project109docs_" + filename2;
                        
                    }
                }
                //end upload



                db.books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
           // }
        }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
}
            }
            return View(books);
        }

        // GET: books/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            ViewBag.author_id = new SelectList(db.authors, "Id", "author_name",books.author_id);
            ViewBag.publisher_id = new SelectList(db.publishers, "Id", "publisher_name",books.publisher_id);
            ViewBag.book_cat = new SelectList(db.books_categories, "Id", "cat_name",books.book_cat);

            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,book_Title,price,author_id,sold_by,publisher_id,publishing_year,stock,book_cover,book_softcopy,date_insert,last_update,active,book_language,book_cat")] books books, HttpPostedFileBase book_cover, HttpPostedFileBase book_softcopy)
        {
            //if (ModelState.IsValid)
            //{
            db.Entry(books).State = EntityState.Modified;
           // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy", "dd/MM/yyyy", "MM/dd/yyyyHH:mm:ss" };
           // CultureInfo provider = new CultureInfo("en-US");
           // //string date_insert = Request.Form["date_insert"].ToString();
           //// DateTime date_insert_param = DateTime.ParseExact(date_insert, dateFormats, provider, DateTimeStyles.AdjustToUniversal);
           // string last_update = Request.Form["last_update"].ToString();
           // DateTime last_update_param = DateTime.ParseExact(last_update, dateFormats, provider, DateTimeStyles.AdjustToUniversal);
           // // books.date_insert = date_insert_param;
            
            books.last_update = System.DateTime.Now;
            //upload photo code
            if (book_cover == null)
            {
                ModelState.AddModelError("img", "Enter file");
                db.Entry(books).Property(x => x.book_cover).IsModified = false;

            }
            else
            {
                string[] allowindex = new string[] { ".jpg", ".gif", ".png" };
                if (!allowindex.Contains(book_cover.FileName.Substring(book_cover.FileName.LastIndexOf("."))))
                {
                    ModelState.AddModelError("img", "Wrong file");
                }
                else
                {
                    //int maxwds = 120; int newwds = 0;
                    string initpath = "~/Content/images/Covers/";
                    var filename = Path.GetFileName(book_cover.FileName);
                    var paths = Path.Combine(Server.MapPath(initpath), "project109_" + filename);
                    book_cover.SaveAs(paths);
                    books.book_cover = "project109_" + filename;

                }
            }
            //end upload

            //upload Content code
            if (book_softcopy == null)
            {
                ModelState.AddModelError("doc", "Enter file");
                db.Entry(books).Property(x => x.book_softcopy).IsModified = false;
            }
            else
            {
                string[] allowindex2 = new string[] { ".docx", ".pdf", ".doc" };
                if (!allowindex2.Contains(book_softcopy.FileName.Substring(book_softcopy.FileName.LastIndexOf("."))))
                {
                    ModelState.AddModelError("doc", "Wrong file");
                }
                else
                {

                    string initpath2 = "~/Content/images/Docs/";
                    var filename2 = Path.GetFileName(book_softcopy.FileName);
                    var paths2 = Path.Combine(Server.MapPath(initpath2), "project109docs_" + filename2);
                    book_softcopy.SaveAs(paths2);
                    books.book_softcopy = "project109docs_" + filename2;

                }
            }
            //end upload

            
            db.Entry(books).Property(x => x.date_insert).IsModified = false;
            db.SaveChanges();
                return RedirectToAction("Index");
            //}
            return View(books);
        }

        // GET: books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            books books = db.books.Find(id);
            db.books.Remove(books);
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
