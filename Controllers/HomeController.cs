using Microsoft.Reporting.WebForms;
using Projent_NOTZA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projent_NOTZA.Controllers
{
    public class HomeController : Controller
    {
        BookShopEntities db = new BookShopEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult LoginAdmin()
        {

            return View();
        }



        [HttpPost]
        public ActionResult LoginAdmin(Admin data)
        {
            var Admin = db.Admin.Where(a => a.Admin_Username == data.Admin_Username
            && a.Admin_Password == data.Admin_Password).FirstOrDefault();

            if (Admin != null)
            {
                Session["Admin"] = Admin;
                return RedirectToAction("Admin", "Home");
            }
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Login()
        {

            return View();
        }

     


        [HttpPost]
        public ActionResult Login(User data)
        {
            var user = db.User.Where(a => a.User_Name == data.User_Name
            && a.User_Password == data.User_Password).FirstOrDefault();

            if (user != null)
            {
                Session["user"] = user;
                return RedirectToAction("Indexx", "ProductBooks");
            }
            return View();
        }

        //public ActionResult Reports(string ReportTyport) 
        //{
        //    LocalReport localReport = new LocalReport();
        //    localReport.ReportPath = Server.MapPath("~/Report/Report1.rdlc");

        //    ReportDataSource reportDataSource = new ReportDataSource();
        //    reportDataSource.Name = "UserDataSource";
        //}  

       
    }
}
