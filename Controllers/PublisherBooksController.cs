using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projent_NOTZA.Models;

namespace Projent_NOTZA.Controllers
{
    public class PublisherBooksController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: PublisherBooks
        public ActionResult Index()
        {
            return View(db.PublisherBook.ToList());
        }

        // GET: PublisherBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherBook publisherBook = db.PublisherBook.Find(id);
            if (publisherBook == null)
            {
                return HttpNotFound();
            }
            return View(publisherBook);
        }

        // GET: PublisherBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublisherBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Publisher_id,Publisher_name")] PublisherBook publisherBook)
        {
            if (ModelState.IsValid)
            {
                db.PublisherBook.Add(publisherBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publisherBook);
        }

        // GET: PublisherBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherBook publisherBook = db.PublisherBook.Find(id);
            if (publisherBook == null)
            {
                return HttpNotFound();
            }
            return View(publisherBook);
        }

        // POST: PublisherBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Publisher_id,Publisher_name")] PublisherBook publisherBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisherBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisherBook);
        }

        // GET: PublisherBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherBook publisherBook = db.PublisherBook.Find(id);
            if (publisherBook == null)
            {
                return HttpNotFound();
            }
            return View(publisherBook);
        }

        // POST: PublisherBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublisherBook publisherBook = db.PublisherBook.Find(id);
            db.PublisherBook.Remove(publisherBook);
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
