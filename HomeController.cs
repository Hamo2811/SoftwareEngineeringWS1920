using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeukonstChecklistWebHTML.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Initialen = getName();
            ViewBag.Admin = getRoleAdmin();
            if (!hasUser()) {
                return new HttpStatusCodeResult(
                System.Net.HttpStatusCode.BadRequest);
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
    }
}