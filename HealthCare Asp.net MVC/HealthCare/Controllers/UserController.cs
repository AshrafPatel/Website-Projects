using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HealthCare.Models;

namespace HealthCare.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Student student)
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



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin userLogin, string ReturnURL = "")
        {
            string message = "";
            using (StudentContext db = new StudentContext())
            {
                var query = db.Students.Where(a => a.Email == userLogin.Email && a.Password == userLogin.Password).FirstOrDefault();
                if (query != null)
                {
                    int timeout = userLogin.RememberMe ? 525600 : 1; //How long cookie will last
                    var ticket = new FormsAuthenticationTicket(userLogin.Email, userLogin.RememberMe, timeout); //create a ticket
                    string enrypted = FormsAuthentication.Encrypt(ticket);//encrypt ticket
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, enrypted);//create cookie
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    string decodedURL = Server.UrlDecode(ReturnURL);
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Message = message;
            return View();
        }


        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
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