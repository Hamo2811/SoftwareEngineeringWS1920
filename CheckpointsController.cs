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
    public class CheckpointsController : BaseController
    {
        //private NeukonstChecklistDataModelContainer db = new NeukonstChecklistDataModelContainer();

        // GET: Checkpoints
        public ActionResult Index()
        {
            ViewBag.Initialen = getName();
            ViewBag.Admin = getRoleAdmin();
            if (LoggedInUser.Admin == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var checkpoints = db.Checkpoints.Include(c => c.Auftragsknoten);
            return View(checkpoints.ToList());
        }

        // GET: Checkpoints/Details/5
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
            Checkpoint checkpoint = db.Checkpoints.Find(id);
            if (checkpoint == null)
            {
                return HttpNotFound();
            }
            return View(checkpoint);
        }

        // GET: Checkpoints/Create
        public ActionResult Create()
        {
            if (LoggedInUser.Admin == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.AuftragsknotenId = new SelectList(db.Auftragsknotens, "Id", "KnotenID");
            return View();
        }

        // POST: Checkpoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Beschreibung,AuftragsknotenId,Erledigt,Auftragsnummer,Baureihe")] Checkpoint checkpoint)
        {
            if (ModelState.IsValid)
            {
                if (LoggedInUser.Admin == false)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                db.Checkpoints.Add(checkpoint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuftragsknotenId = new SelectList(db.Auftragsknotens, "Id", "KnotenID", checkpoint.AuftragsknotenId);
            return View(checkpoint);
        }

        // GET: Checkpoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                if (LoggedInUser.Admin == false)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkpoint checkpoint = db.Checkpoints.Find(id);
            if (checkpoint == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuftragsknotenId = new SelectList(db.Auftragsknotens, "Id", "KnotenID", checkpoint.AuftragsknotenId);
            return View(checkpoint);
        }

        // POST: Checkpoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Beschreibung,AuftragsknotenId,Erledigt,Auftragsnummer,Baureihe")] Checkpoint checkpoint)
        {
            if (ModelState.IsValid)
            {
                if (LoggedInUser.Admin == false)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                db.Entry(checkpoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuftragsknotenId = new SelectList(db.Auftragsknotens, "Id", "KnotenID", checkpoint.AuftragsknotenId);
            return View(checkpoint);
        }

        // GET: Checkpoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                if (LoggedInUser.Admin == false)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkpoint checkpoint = db.Checkpoints.Find(id);
            if (checkpoint == null)
            {
                return HttpNotFound();
            }
            return View(checkpoint);
        }

        // POST: Checkpoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (LoggedInUser.Admin == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checkpoint checkpoint = db.Checkpoints.Find(id);
            db.Checkpoints.Remove(checkpoint);
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
