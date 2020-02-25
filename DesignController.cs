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
    public class DesignController : BaseController
    {
        //private NeukonstChecklistDataModelContainer db = new NeukonstChecklistDataModelContainer();

        // GET: Design
        public ActionResult Index()
        {
            if (!hasKonstrukteur())
            {
             return new
                HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            ViewBag.DesignedIds = LoggedInKonstrukteur.KonstruiertAuftragsknoten.Select(o => o.Id).ToList();
            return View(db.Auftragsknotens.ToList());
        }

        // GET: Design/Details/5
        public ActionResult Design(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auftragsknoten auftragsknoten = db.Auftragsknotens.Find(id);
            if (auftragsknoten == null)
            {
                return HttpNotFound();
            }
            if (!hasKonstrukteur())
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            LoggedInKonstrukteur.KonstruiertAuftragsknoten.Add(auftragsknoten);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
