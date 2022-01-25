using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practise_app7.Models;

namespace Practise_app7.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(CustomeBinder))] Student stud)
        {
            return View();
        }
    }
}