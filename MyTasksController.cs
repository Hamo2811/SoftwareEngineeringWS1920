using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeukonstChecklistLibDb;
using System.Threading.Tasks;

namespace NeukonstChecklistWebHTML.Controllers
{
    public class MyTasksController : BaseController
    {
        //private NeukonstChecklistDataModelContainer db = new NeukonstChecklistDataModelContainer();

        // GET: Checkpoints
        //public async Task<ActionResult> Index(string searchString)
        public ActionResult Index()
        {
            ViewBag.Initialen = getName();
            
            var checkpoints =
                from checkpoint in db.Checkpoints
                where checkpoint.Erledigt == false && checkpoint.Auftragsknoten.VonUser.Initialen == LoggedInUser.Initialen
                select checkpoint;
            //Such Filter
            //var orders = from m in db.Checkpoints
                        // select m;
            //if (!String.IsNullOrEmpty(searchString))
            //{
                //orders = orders.Where(s => s.Beschreibung.Contains(searchString));
            //}
            //return View(await orders.ToListAsync());
            return View(checkpoints.ToList());
        }


        // GET: Checkpoints/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Initialen = getName();
            if (id == null)
            {
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
                db.Entry(checkpoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuftragsknotenId = new SelectList(db.Auftragsknotens, "Id", "KnotenID", checkpoint.AuftragsknotenId);
            return View(checkpoint);
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