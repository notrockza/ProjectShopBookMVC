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
    public class OrderBooksController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: OrderBooks
        public ActionResult Index()
        {
            var orderBook = db.OrderBook.Include(o => o.ProductBook).Include(o => o.SalesSlip).Include(o => o.Status);
            return View(orderBook.ToList());
        }

        // GET: OrderBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderBook orderBook = db.OrderBook.Find(id);
            if (orderBook == null)
            {
                return HttpNotFound();
            }
            return View(orderBook);
        }

        // GET: OrderBooks/Create
        public ActionResult Create()
        {
            ViewBag.Order_BookId = new SelectList(db.ProductBook, "Product_BookId", "Product_Name");
            ViewBag.Order_SalesId = new SelectList(db.SalesSlip, "Sales_Id", "Sales_date");
            ViewBag.Order_Status_Id = new SelectList(db.Status, "Status_Id", "Status_Name");
            return View();
        }

        // POST: OrderBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_Id,Order_SalesId,Order_Date,Order_NumProduct,Order_BookId,Order_Price,Order_Status_Id")] OrderBook orderBook)
        {
            if (ModelState.IsValid)
            {
                db.OrderBook.Add(orderBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_BookId = new SelectList(db.ProductBook, "Product_BookId", "Product_Name", orderBook.Order_BookId);
            ViewBag.Order_SalesId = new SelectList(db.SalesSlip, "Sales_Id", "Sales_date", orderBook.Order_SalesId);
            ViewBag.Order_Status_Id = new SelectList(db.Status, "Status_Id", "Status_Name", orderBook.Order_Status_Id);
            return View(orderBook);
        }

        // GET: OrderBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderBook orderBook = db.OrderBook.Find(id);
            if (orderBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_BookId = new SelectList(db.ProductBook, "Product_BookId", "Product_Name", orderBook.Order_BookId);
            ViewBag.Order_SalesId = new SelectList(db.SalesSlip, "Sales_Id", "Sales_date", orderBook.Order_SalesId);
            ViewBag.Order_Status_Id = new SelectList(db.Status, "Status_Id", "Status_Name", orderBook.Order_Status_Id);
            return View(orderBook);
        }

        // POST: OrderBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_Id,Order_SalesId,Order_Date,Order_NumProduct,Order_BookId,Order_Price,Order_Status_Id")] OrderBook orderBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_BookId = new SelectList(db.ProductBook, "Product_BookId", "Product_Name", orderBook.Order_BookId);
            ViewBag.Order_SalesId = new SelectList(db.SalesSlip, "Sales_Id", "Sales_date", orderBook.Order_SalesId);
            ViewBag.Order_Status_Id = new SelectList(db.Status, "Status_Id", "Status_Name", orderBook.Order_Status_Id);
            return View(orderBook);
        }

        // GET: OrderBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderBook orderBook = db.OrderBook.Find(id);
            if (orderBook == null)
            {
                return HttpNotFound();
            }
            return View(orderBook);
        }

        // POST: OrderBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderBook orderBook = db.OrderBook.Find(id);
            db.OrderBook.Remove(orderBook);
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
