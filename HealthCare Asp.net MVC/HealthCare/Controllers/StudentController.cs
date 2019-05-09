using HealthCare.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Linq;
using System.Data.Entity;

namespace HealthCare.Controllers
{
    public class StudentController : Controller
    {
        private StudentContext db = new StudentContext();


        // GET: Student
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult RotaIndex()
        {
            var a = User.Identity.Name.ToString();
            var currentStudent = db.Students.Where(user => user.Email == a).FirstOrDefault();
            var usersRotations = db.Rotations.Where(rota => rota.PKey == currentStudent.PKey);
            return View(usersRotations.ToList());
        }


        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        {
            var a = User.Identity.Name.ToString();
            var currentStudent = db.Students.Where(user => user.Email == a).FirstOrDefault();
            if (currentStudent == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,Address,PostalCode,Password,ConfirmPassword,Telephone,ProgramType,ProgramName,InstitutionalName")] Student student)
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

        // GET: Student/Details/5
        [Authorize]
        public ActionResult DetailsRota(int? id)
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
        [Authorize]
        public ActionResult CreateRota(int ?id)
        {
            return View(id);
        }

        // POST: Rotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRota([Bind(Include = "PKey,RotationName,StartDate,EndDate,Supervisor,RKey")] Rotation rotation)
        {
            var a = User.Identity.Name.ToString();
            var currentStudent = db.Students.Where(user => user.Email == a).FirstOrDefault();
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                using (StudentContext dc = new StudentContext())
                {
                    if ((DateTime.Parse(rotation.StartDate) < DateTime.Now)  || (DateTime.Parse(rotation.EndDate) < DateTime.Now) || (DateTime.Parse(rotation.StartDate).Year < 1900) || (DateTime.Parse(rotation.EndDate).Year < 1900))
                    {
                        ModelState.AddModelError("DOBInvalid", "The date is invalid!");
                    }
                    else if (DateTime.Parse(rotation.StartDate) > DateTime.Parse(rotation.EndDate)) {
                        ModelState.AddModelError("DOBInvalid", "Please check your start and end date and try again");
                    }
                    else
                    {
                        rotation.PKey = currentStudent.PKey;
                        dc.Rotations.Add(rotation);
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
            return View(rotation);
        }

        // GET: Rotations/Edit/5
        [Authorize]
        public ActionResult EditRota(int? id)
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

        // POST: Rotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRota([Bind(Include = "PKey,RotationName,StartDate,EndDate,Supervisor,RKey")] Rotation rotation)
        {
            var a = User.Identity.Name.ToString();
            var currentStudent = db.Students.Where(user => user.Email == a).FirstOrDefault();
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                using (StudentContext dc = new StudentContext())
                {
                    if ((DateTime.Parse(rotation.StartDate) < DateTime.Now) || (DateTime.Parse(rotation.EndDate) < DateTime.Now) || (DateTime.Parse(rotation.StartDate).Year < 1900) || (DateTime.Parse(rotation.EndDate).Year < 1900))
                    {
                        ModelState.AddModelError("DOBInvalid", "The date is invalid!");
                    }
                    else if (DateTime.Parse(rotation.StartDate) > DateTime.Parse(rotation.EndDate))
                    {
                        ModelState.AddModelError("DOBInvalid", "Please check your start and end date and try again");
                    }
                    else
                    {
                        rotation.PKey = currentStudent.PKey;
                        dc.Rotations.Add(rotation);
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
            return View(rotation);
        }

        // GET: Rotations/Delete/5
        [Authorize]
        public ActionResult DeleteRota(int? id)
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