using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWithEntityFramework.Models;

namespace UniversityManagementWithEntityFramework.Controllers
{
    public class CourseController : Controller
    {
        UniversityManagementEntities db = new UniversityManagementEntities();
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Departments = new SelectList(db.Departments.ToList(),"DepartmentId","DepartmentName");
          ViewBag.Semesters = new SelectList(db.Semesters.ToList(), "SemesterId", "SemesterName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            db.Entry(course).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
    }
}