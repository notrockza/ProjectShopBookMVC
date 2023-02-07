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
    public class SalesSlipsController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: SalesSlips
        public ActionResult Index()
        {
            var salesSlip = db.SalesSlip.Include(s => s.User);
            return View(salesSlip.ToList());
        }

        // GET: SalesSlips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesSlip salesSlip = db.SalesSlip.Find(id);
            if (salesSlip == null)
            {
                return HttpNotFound();
            }
            return View(salesSlip);
        }

        // GET: SalesSlips/Create
        public ActionResult Create()
        {
            ViewBag.Sales_Userid = new SelectList(db.User, "User_Id", "User_Name");
            return View();
        }

        // POST: SalesSlips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sales_Id,Sales_date,Sales_Product,Sales_Userid,Sales_NumProduct")] SalesSlip salesSlip)
        {
            if (ModelState.IsValid)
            {
                db.SalesSlip.Add(salesSlip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sales_Userid = new SelectList(db.User, "User_Id", "User_Name", salesSlip.Sales_Userid);
            return View(salesSlip);
        }

        // GET: SalesSlips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesSlip salesSlip = db.SalesSlip.Find(id);
            if (salesSlip == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sales_Userid = new SelectList(db.User, "User_Id", "User_Name", salesSlip.Sales_Userid);
            return View(salesSlip);
        }

        // POST: SalesSlips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sales_Id,Sales_date,Sales_Product,Sales_Userid,Sales_NumProduct")] SalesSlip salesSlip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesSlip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sales_Userid = new SelectList(db.User, "User_Id", "User_Name", salesSlip.Sales_Userid);
            return View(salesSlip);
        }

        // GET: SalesSlips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesSlip salesSlip = db.SalesSlip.Find(id);
            if (salesSlip == null)
            {
                return HttpNotFound();
            }
            return View(salesSlip);
        }

        // POST: SalesSlips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesSlip salesSlip = db.SalesSlip.Find(id);
            db.SalesSlip.Remove(salesSlip);
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
