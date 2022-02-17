using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeProj.Models;

namespace EmployeProj.Areas.Admin.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Admin/Department
        OrganizationsDbcontext db = new OrganizationsDbcontext();
        public ActionResult Index(string SortColumn = "DepartmentId", string IconClass = "fa-sort-asc", int Page = 1)
        {

            List<Department> departments = db.Departments.ToList();

            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "DepartmentId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    departments = departments.OrderBy(temp => temp.DepartmentId).ToList();
                else
                    departments = departments.OrderByDescending(temp => temp.DepartmentId).ToList();
            }
            else if (ViewBag.SortColumn == "DepartmentName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    departments = departments.OrderBy(temp => temp.DepartmentName).ToList();
                else
                    departments = departments.OrderBy(temp => temp.DepartmentName).ToList();
            }
            else if (ViewBag.SortColumn == "DepartmentLoc")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    departments = departments.OrderBy(temp => temp.DepartmentLoc).ToList();
                else
                    departments = departments.OrderBy(temp => temp.DepartmentLoc).ToList();
            }


            int NoOfRecodePerpg = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(departments.Count) / Convert.ToDouble(NoOfRecodePerpg)));
            int NoOfRecordsToSkip = (Page - 1) * NoOfRecodePerpg;
            ViewBag.Page = Page;
            ViewBag.NoOfPages = NoOfPages;
            departments = departments.Skip(NoOfRecordsToSkip).Take(NoOfRecodePerpg).ToList();
            return View(departments);

        }
        public ActionResult Create()
        {

            ViewBag.Department = db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department d)
        {
            if (ModelState.IsValid)
            {

                db.Departments.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Edit(long ID)
        {

            ViewBag.Department = db.Departments.ToList();

            Department pro = db.Departments.Where(temp => temp.DepartmentId == ID).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Department d)
        {

            Department pro = db.Departments.Where(temp => temp.DepartmentId == d.DepartmentId).FirstOrDefault();
            pro.DepartmentName = d.DepartmentName;
            pro.DepartmentLoc = d.DepartmentLoc;
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }


        public JsonResult Delete(long ID)
        {
            bool result = false;

            Department pr = db.Departments.Where(temp => temp.DepartmentId == ID).FirstOrDefault();
            db.Departments.Remove(pr);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {

            Department Detail = db.Departments.Where(temp => temp.DepartmentId == id).FirstOrDefault();

            return View(Detail);
        }




    }
}