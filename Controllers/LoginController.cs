using Microsoft.AspNetCore.Mvc;
using Student_Register.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace Student_Register.Controllers
{
    public class LoginController : Controller
    {
        public static ACE42023Context db = new ACE42023Context();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminArpit u)
        {
            AdminArpit a = db.AdminArpits.Find(u.Userid);
            if(a != null && a.Pwd == u.Pwd)
            {
                HttpContext.Session.SetString("username", a.Username);
                return RedirectToAction("GetStudents", "Student");
            }
            else
            {
                return View();
            }
        }
    }
}