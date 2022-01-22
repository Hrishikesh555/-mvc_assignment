using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practise_app4.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult accountt()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Tollfree = "22-22-23-33";
            return View();
        }
    }
}