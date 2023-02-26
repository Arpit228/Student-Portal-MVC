using Microsoft.AspNetCore.Mvc;
using Student_Register.Models;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace Student_Register.Controllers
{
    public class StudentController : Controller
    {
        // private readonly ACE42023Context db;

        // public StudentController(ACE42023Context _db)
        // {
        //     db = _db;
        // }

        public static ACE42023Context db = new ACE42023Context();

        public ActionResult GetStudents()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View(db.StudentArpits);
        }

        public IActionResult AddStudent()
        {
            var list = db.CourseArpits;
            ViewBag.Courses = new SelectList(list, "Cid", "Cname");
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentArpit p)
        {
            
            db.StudentArpits.Add(p);
            db.SaveChanges();
            return RedirectToAction("GetStudents");
        }

        public IActionResult ViewStudent(int id)
        {
            StudentArpit p = db.StudentArpits.Find(id);
            return View(p);
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var list = db.CourseArpits;
            ViewBag.Courses = new SelectList(list, "Cid", "Cname");
            StudentArpit p = db.StudentArpits.Find(id);
            return View(p);
        }

        [HttpPost]
        public IActionResult EditStudent(StudentArpit p)
        {
            try{
                db.StudentArpits.Update(p);
                db.SaveChanges();
            }
            catch(Exception e){
                return RedirectToAction("GetStudents");
            }
            
            return RedirectToAction("GetStudents");
        }

        public IActionResult DeleteStudent(int id)
        {
            StudentArpit p = db.StudentArpits.Find(id);
            return View(p);
        }

        [HttpPost]
        [ActionName("DeleteStudent")]
        public IActionResult DeleteStudentConfirmed(int id)
        {
            StudentArpit p = db.StudentArpits.Find(id);
            db.StudentArpits.Remove(p);
            db.SaveChanges();
            return RedirectToAction("GetStudents");
        }
    }
}