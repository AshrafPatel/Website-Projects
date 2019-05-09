using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthCare.Models;

namespace HealthCare.Controllers
{
    public class RotationsController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Rotations
        [AuthorizeEmailDomain]
        [Authorize]
        public ActionResult Index()
        {
            var rotations = db.Rotations.Include(r => r.Student);
            return View(rotations.ToList());
        }

        // GET: Rotations/Details/5
        [AuthorizeEmailDomain]
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rotation rotation = db.Rotations.Find(id);
            if (rotation == null)
            {
                return HttpNotFound();
            }
            return View(rotation);
        }

        // GET: Rotations/Create
        [AuthorizeEmailDomain]
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PKey = new SelectList(db.Students, "PKey", "FirstName");
            return View();
        }

        // POST: Rotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PKey,RotationName,StartDate,EndDate,Supervisor,RKey")] Rotation rotation)
        {
            if (ModelState.IsValid)
            {
                db.Rotations.Add(rotation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PKey = new SelectList(db.Students, "PKey", "FirstName", rotation.PKey);
            return View(rotation);
        }

        // GET: Rotations/Edit/5
        [AuthorizeEmailDomain]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rotation rotation = db.Rotations.Find(id);
            if (rotation == null)
            {
                return HttpNotFound();
            }
            ViewBag.PKey = new SelectList(db.Students, "PKey", "FirstName", rotation.PKey);
            return View(rotation);
        }

        // POST: Rotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthorizeEmailDomain]
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PKey,RotationName,StartDate,EndDate,Supervisor,RKey")] Rotation rotation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rotation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PKey = new SelectList(db.Students, "PKey", "FirstName", rotation.PKey);
            return View(rotation);
        }

        // GET: Rotations/Delete/5
        [AuthorizeEmailDomain]
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rotation rotation = db.Rotations.Find(id);
            if (rotation == null)
            {
                return HttpNotFound();
            }
            return View(rotation);
        }

        // POST: Rotations/Delete/5
        [AuthorizeEmailDomain]
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rotation rotation = db.Rotations.Find(id);
            db.Rotations.Remove(rotation);
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
