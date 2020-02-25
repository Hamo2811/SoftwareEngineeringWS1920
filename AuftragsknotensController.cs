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
    public class AuftragsknotensController : BaseController
    {
        //private NeukonstChecklistDataModelContainer db = new NeukonstChecklistDataModelContainer();

        // GET: Auftragsknotens
        public ActionResult Index()
        {
            ViewBag.Initialen = getName();
            ViewBag.Admin = getRoleAdmin();
            if (LoggedInUser.Admin == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var auftragsknotens = db.Auftragsknotens.Include(a => a.VonUser);
            return View(auftragsknotens.ToList());
        }

        // GET: Auftragsknotens/Details/5
        public ActionResult Details(int? id)
        {
            if (LoggedInUser.Admin == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auftragsknoten auftragsknoten = db.Auftragsknotens.Find(id);
            if (auftragsknoten == null)
            {
                return HttpNotFound();
            }
            return View(auftragsknoten);
        }

        // GET: Auftragsknotens/Create
        public ActionResult Create()
        {
            if (LoggedInUser.Admin == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Initialen");
            return View();
        }

        // POST: Auftragsknotens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KnotenID,Sachnummer,Freigabe,UserId")] Auftragsknoten auftragsknoten)
        {
            if (ModelState.IsValid)
            {
                if (LoggedInUser.Admin == false)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                db.Auftragsknotens.Add(auftragsknoten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Initialen", auftragsknoten.UserId);
            return View(auftragsknoten);
        }

        // GET: Auftragsknotens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (LoggedInUser.Admin == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auftragsknoten auftragsknoten = db.Auftragsknotens.Find(id);
            if (auftragsknoten == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Initialen", auftragsknoten.UserId);
            return View(auftragsknoten);
        }

        // POST: Auftragsknotens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KnotenID,Sachnummer,Freigabe,UserId")] Auftragsknoten auftragsknoten)
        {
            if (LoggedInUser.Admin == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                db.Entry(auftragsknoten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Initialen", auftragsknoten.UserId);
            return View(auftragsknoten);
        }

        // GET: Auftragsknotens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (LoggedInUser.Admin == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auftragsknoten auftragsknoten = db.Auftragsknotens.Find(id);
            if (auftragsknoten == null)
            {
                return HttpNotFound();
            }
            return View(auftragsknoten);
        }

        // POST: Auftragsknotens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (LoggedInUser.Admin == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auftragsknoten auftragsknoten = db.Auftragsknotens.Find(id);
            db.Auftragsknotens.Remove(auftragsknoten);
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
