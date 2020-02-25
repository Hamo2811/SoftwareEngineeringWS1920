using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeukonstChecklistLibDb;

namespace NeukonstChecklistWebHTML.Controllers
{
    public class LoginController : BaseController
    {
        //private NeukonstChecklistDataModelContainer db = new NeukonstChecklistDataModelContainer();

        // GET: Login
       
            // GET: Login
            public ActionResult Index()
            {
                return View(db.Users.ToList());
            }
            // GET: Login/Details/5
            public ActionResult Select(int? id)
            {
                if (id == null)
                {
                    return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                setUserId(id.Value);
                return RedirectToAction("Index","Home");;
            }
        
    }
}