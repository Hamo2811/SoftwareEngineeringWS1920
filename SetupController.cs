using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using NeukonstChecklistLibDb;

namespace NeukonstChecklistWebHTML.Controllers
{
    public class SetupController : BaseController
    {
        // GET: Setup
        //string KonstrukteursData = "...";
        ///string AuftragsknotensData = "...";
        public ActionResult Import()
        {

            return View();
        }

        public ActionResult ClearAll()
        {
            foreach (var user in db.Users)
            {
                user.KonstruiertAuftragsknoten.Clear();
                //User.tauschen.Clear();
            }
            //Context.SaveChanges();
            foreach (var checkpoint in db.Checkpoints)
            {
                //checkpoint.Auftragsknoten.Clear();
            }
            db.SaveChanges();
            db.Auftragsknotens.RemoveRange(db.Auftragsknotens);
            db.SaveChanges();
            db.Users.RemoveRange(db.Users);
            db.SaveChanges();
            db.Checkpoints.RemoveRange(db.Checkpoints);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}