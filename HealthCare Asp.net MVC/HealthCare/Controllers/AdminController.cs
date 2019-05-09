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
    public class AdminController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Admin
        [AuthorizeEmailDomain]
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Admin/Details/5
        [AuthorizeEmailDomain]
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Admin/Create
        [AuthorizeEmailDomain]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthorizeEmailDomain]
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PKey,FirstName,LastName,Address,PostalCode,DOB,Email,Password,ConfirmPassword,Telephone,ProgramType,ProgramName,InstitutionalName")] Student student)
        {
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                var itExists = IsEmailExist(student.Email);
                using (StudentContext dc = new StudentContext())
                {
                    if (itExists)
                    {
                        ModelState.AddModelError("EmailExist", "This email already exists!");
                    }
                    else if (student.DOB.Year < 1900 || student.DOB.Year >= DateTime.Now.Year)
                    {
                        ModelState.AddModelError("DOBInvalid", "Error Date is invalid");
                    }
                    else
                    {
                        dc.Students.Add(student);
                        dc.SaveChanges();
                        Status = true;
                        message = "Successfully created user";
                    }
                }
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(student);
        }

        // GET: Admin/Edit/5
        [AuthorizeEmailDomain]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthorizeEmailDomain]
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PKey,FirstName,LastName,Address,PostalCode,DOB,Email,Password,ConfirmPassword,Telephone,ProgramType,ProgramName,InstitutionalName")] Student student)
        {
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                var itExists = IsEmailExist(student.Email);
                using (StudentContext dc = new StudentContext())
                {
                    if (itExists)
                    {
                        ModelState.AddModelError("EmailExist", "This email already exists!");
                    }
                    else if (student.DOB.Year < 1900 || student.DOB.Year >= DateTime.Now.Year)
                    {
                        ModelState.AddModelError("DOBInvalid", "Error Date is invalid");
                    }
                    else
                    {
                        dc.Students.Add(student);
                        dc.SaveChanges();
                        Status = true;
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(student);
        }

        // GET: Admin/Delete/5
        [AuthorizeEmailDomain]
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Admin/Delete/5
        [AuthorizeEmailDomain]
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (StudentContext db = new StudentContext())
            {
                var gotEmail = db.Students.Where(a => a.Email == emailID).FirstOrDefault();
                return gotEmail != null;
            }
        }
    }
}
