using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using Projent_NOTZA.Models;

namespace Projent_NOTZA.Controllers
{
    public class ProductBooksController : Controller
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: ProductBooks
        public ActionResult Index()
        {
            var productBook = db.ProductBook.Include(p => p.PublisherBook).Include(p => p.TypeBook);
            return View(productBook.ToList());
        }

        public ActionResult Indexx()
        {
            var productBook = db.ProductBook.Include(p => p.PublisherBook).Include(p => p.TypeBook);
            return View(productBook.ToList());
        }



        // GET: ProductBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBook productBook = db.ProductBook.Find(id);
            if (productBook == null)
            {
                return HttpNotFound();
            }
            return View(productBook);


        }

        // GET: ProductBooks/Create
        public ActionResult Create()
        {

            ViewBag.Product_PublisherId = new SelectList(db.PublisherBook, "Publisher_id", "Publisher_name");
            ViewBag.Product_TypeId = new SelectList(db.TypeBook, "Type_Id", "Type_Name");
            return View();
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_BookId,Product_TypeId,Product_PublisherId,Product_Name,Product_Price,Product_Num,Product_Image")] ProductBook productBook, HttpPostedFileBase UpFile)
        {

            //แปลงภาพให้เป็นไบนารีก่อน กรณีบันทึกไว้ใน Database
            if (UpFile != null)
            {
                byte[] Temp = new byte[UpFile.ContentLength];
                UpFile.InputStream.Read(Temp, 0, UpFile.ContentLength);
                productBook.Product_Image = Temp; // เนื้อภาพ
            }
            //

            if (ModelState.IsValid)
            {
                db.ProductBook.Add(productBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_PublisherId = new SelectList(db.PublisherBook, "Publisher_id", "Publisher_name", productBook.Product_PublisherId);
            ViewBag.Product_TypeId = new SelectList(db.TypeBook, "Type_Id", "Type_Name", productBook.Product_TypeId);
            return View(productBook);
        }


        











        // POST: ProductBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Product_BookId,Product_TypeId,Product_PublisherId,Product_Name,Product_Price,Product_Num,Product_Image")] ProductBook productBook)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ProductBook.Add(productBook);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }


        //    ViewBag.Product_PublisherId = new SelectList(db.PublisherBook, "Publisher_id", "Publisher_name", productBook.Product_PublisherId);
        //    ViewBag.Product_TypeId = new SelectList(db.TypeBook, "Type_Id", "Tpe_Name", productBook.Product_TypeId);
        //    return View(productBook);
        //}





        // GET: ProductBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBook productBook = db.ProductBook.Find(id);
            if (productBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_PublisherId = new SelectList(db.PublisherBook, "Publisher_id", "Publisher_name", productBook.Product_PublisherId);
            ViewBag.Product_TypeId = new SelectList(db.TypeBook, "Type_Id", "Type_Name", productBook.Product_TypeId);
            return View(productBook);
        }

        // POST: ProductBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_BookId,Product_TypeId,Product_PublisherId,Product_Name,Product_Price,Product_Num,Product_Image")] ProductBook productBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_PublisherId = new SelectList(db.PublisherBook, "Publisher_id", "Publisher_name", productBook.Product_PublisherId);
            ViewBag.Product_TypeId = new SelectList(db.TypeBook, "Type_Id", "Type_Name", productBook.Product_TypeId);
            return View(productBook);
        }



        // GET: ProductBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            var result = db.ProductBook.Find(id);
            db.ProductBook.Remove(result);
            db.SaveChanges();
            return RedirectToAction(nameof(Indexx));
        }

        public ActionResult Deletex(int? id)
        {
            var result = db.ProductBook.Find(id);
            db.ProductBook.Remove(result);
            db.SaveChanges();
            return RedirectToAction(nameof(Indexx));
        }


        //public ActionResult Deletex(int? id)
        //{
        //    var result = db.ProductBook.Find(id);
        //    db.ProductBook.Remove(result);
        //    db.SaveChanges();
        //    return RedirectToAction(nameof(Indexx));
        //}

        // POST: ProductBooks/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ProductBook productBook = db.ProductBook.Find(id);
        //    db.ProductBook.Remove(productBook);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult ReportsUser(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/Report2.rdlc");
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet2";
            reportDataSource.Value = db.ProductBook.ToList();
            localReport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mimeType;
            string encoding = "Encoding.UTF8";
            string fileNameExtension;
            if (reportType == "Excel")
            {
                fileNameExtension = "xlsx";
            }
            else if (reportType == "Word")
            {
                fileNameExtension = "docx";
            }
            else if (reportType == "PDF")
            {
                fileNameExtension = "pdf";
            }
            else
            {
                fileNameExtension = "jpg";
            }

            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment;filename= not_reportUser." + fileNameExtension);

            return File(renderedByte, fileNameExtension);
        }



        public ActionResult Adtocart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBook productBook = db.ProductBook.Find(id);
            if (productBook == null)
            {
                return HttpNotFound();
            }
            return View(productBook);
        }

    }
}
