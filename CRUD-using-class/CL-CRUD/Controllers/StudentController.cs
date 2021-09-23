using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CL_CRUD.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(StudentDetails student)
        {
            return View();
        }

    }
}