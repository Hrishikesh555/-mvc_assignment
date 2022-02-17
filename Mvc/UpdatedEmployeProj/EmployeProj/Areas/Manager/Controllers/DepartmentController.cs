using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeProj.Models;

namespace EmployeProj.Areas.Manager.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Manager/Department
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




    }
}