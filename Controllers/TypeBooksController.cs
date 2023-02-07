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
    public class TypeBooksController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: TypeBooks
        public ActionResult Index()
        {
            return View(db.TypeBook.ToList());
        }

        // GET: TypeBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeBook typeBook = db.TypeBook.Find(id);
            if (typeBook == null)
            {
                return HttpNotFound();
            }
            return View(typeBook);
        }

        // GET: TypeBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Type_Id,Tpe_Name")] TypeBook typeBook)
        {
            if (ModelState.IsValid)
            {
                db.TypeBook.Add(typeBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeBook);
        }

        // GET: TypeBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeBook typeBook = db.TypeBook.Find(id);
            if (typeBook == null)
            {
                return HttpNotFound();
            }
            return View(typeBook);
        }

        // POST: TypeBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Type_Id,Tpe_Name")] TypeBook typeBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeBook);
        }

        // GET: TypeBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeBook typeBook = db.TypeBook.Find(id);
            if (typeBook == null)
            {
                return HttpNotFound();
            }
            return View(typeBook);
        }

        // POST: TypeBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeBook typeBook = db.TypeBook.Find(id);
            db.TypeBook.Remove(typeBook);
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
