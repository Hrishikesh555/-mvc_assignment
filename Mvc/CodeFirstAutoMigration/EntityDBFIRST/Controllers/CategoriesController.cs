using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDBFIRST.Models;

namespace EntityDBFIRST.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            CompanyDbCotext db = new CompanyDbCotext();
            List<Category> categories =db.Categories.ToList();
            return View(categories);
        }
    }
}