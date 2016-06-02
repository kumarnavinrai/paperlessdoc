using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;

namespace applicationproject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Fileup()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ExportPDF()
        {
            ActionAsPdf result = new ActionAsPdf("Contact")
            {
                FileName = Server.MapPath("~/Content/Invoice.pdf")
            };
            return result;
        }
    }
}
