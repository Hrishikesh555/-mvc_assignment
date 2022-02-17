using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeProj.Models;

namespace EmployeProj.Areas.Manager.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Manager/Employe
        OrganizationsDbcontext db = new OrganizationsDbcontext();
        // GET: Employe
        public ActionResult Index(string EmployeName = "", string City = "", string SortColumn = "EmployeId", string IconClass = "fa-sort-asc", int Page = 1)
        {
            List<Empploye> empployes = db.Empployes.ToList();
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;




            if (ViewBag.SortColumn == "EmployeId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    empployes = empployes.OrderBy(temp => temp.EmployeId).ToList();
                else
                    empployes = empployes.OrderByDescending(temp => temp.EmployeId).ToList();
            }
            else if (ViewBag.SortColumn == "EmployeName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    empployes = empployes.OrderBy(temp => temp.EmployeName).ToList();
                else
                    empployes = empployes.OrderByDescending(temp => temp.EmployeName).ToList();
            }
            else if (ViewBag.SortColumn == "Designation")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    empployes = empployes.OrderBy(temp => temp.Designation).ToList();
                else
                    empployes = empployes.OrderByDescending(temp => temp.Designation).ToList();
            }
            else if (ViewBag.SortColumn == "Profile")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    empployes = empployes.OrderBy(temp => temp.Profile).ToList();
                else
                    empployes = empployes.OrderByDescending(temp => temp.Profile).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfJoing")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    empployes = empployes.OrderBy(temp => temp.DateOfJoing).ToList();
                else
                    empployes = empployes.OrderByDescending(temp => temp.DateOfJoing).ToList();
            }
            else if (ViewBag.SortColumn == "City")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    empployes = empployes.OrderBy(temp => temp.City).ToList();
                else
                    empployes = empployes.OrderByDescending(temp => temp.City).ToList();
            }
            else if (ViewBag.SortColumn == "Contact")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    empployes = empployes.OrderBy(temp => temp.Contact).ToList();
                else
                    empployes = empployes.OrderByDescending(temp => temp.Contact).ToList();
            }
            else if (ViewBag.SortColumn == "DepartmentId")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    empployes = empployes.OrderBy(temp => temp.DepartmentId).ToList();
                else
                    empployes = empployes.OrderByDescending(temp => temp.DepartmentId).ToList();
            }
            else if (ViewBag.SortColumn == "Status")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    empployes = empployes.OrderBy(temp => temp.Status).ToList();
                else
                    empployes = empployes.OrderByDescending(temp => temp.Status).ToList();
            }
            int NoOfRecodePerpg = 4;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(empployes.Count) / Convert.ToDouble(NoOfRecodePerpg)));
            int NoOfRecordsToSkip = (Page - 1) * NoOfRecodePerpg;
            ViewBag.Page = Page;
            ViewBag.NoOfPages = NoOfPages;
            empployes = empployes.Skip(NoOfRecordsToSkip).Take(NoOfRecodePerpg).ToList();


            if (City != "" && EmployeName != "")
            {
                List<Empploye> Elist = db.Empployes.Where(temp => temp.City.Contains(City) && temp.EmployeName.Contains(EmployeName)).ToList();
                int NoOfRecPerPage1 = 4;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Elist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (Page - 1) * NoOfRecPerPage1;
                ViewBag.pageno = Page;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.EmployeName = EmployeName;
                ViewBag.City = City;
                return View(Elist);
            }



            else if (City != "")
            {
                List<Empploye> Elist = db.Empployes.Where(temp => temp.City.Contains(City)).ToList();
                int NoOfRecPerPage1 = 4;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Elist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (Page - 1) * NoOfRecPerPage1;
                ViewBag.pageno = Page;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.City = City;
                return View(Elist);
            }
            else if (EmployeName != "")
            {
                List<Empploye> Elist = db.Empployes.Where(temp => temp.EmployeName.Contains(EmployeName)).ToList();
                int NoOfRecPerPage1 = 4;
                int NoOfPages1 = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Elist.Count) / Convert.ToDouble(NoOfRecPerPage1)));
                int NoOfRecToSkip1 = (Page - 1) * NoOfRecPerPage1;
                ViewBag.pageno = Page;
                ViewBag.noofpages = NoOfPages1;
                ViewBag.EmployeName = EmployeName;
                return View(Elist);
            }
            return View(empployes);
        }
        public ActionResult SalIndx(int id)
        {
            Salary Detail = db.Salaries.Where(temp => temp.EmployeId == id).FirstOrDefault();

            return View(Detail);
        }
        public ActionResult Create()
        {
            ViewBag.departmen = db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Empploye E)
        {
            Empploye Emp = new Empploye();
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength - 1];
                file.InputStream.Read(imgBytes, 0, file.ContentLength - 1);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                E.Profile = base64String;
                Emp.Profile = E.Profile;
            }
            Emp.EmployeName = E.EmployeName;
            Emp.Designation = E.Designation;
            Emp.DateOfJoing = E.DateOfJoing;
            Emp.City = E.City;
            Emp.Contact = E.Contact;
            Emp.Sals = E.Sals;
            Emp.DepartmentId = E.DepartmentId;
            Emp.Status = E.Status;
            db.Empployes.Add(Emp);
            db.SaveChanges();


            int s = E.Sals;
            int EmpId = Emp.EmployeId;

            Salary sal = new Salary();
            sal.EmployeId = EmpId;
            sal.Salarys = s;
            if (s > 50000)
            {
                sal.HRA = s * 20 / 100;
                sal.DA = s * 7 / 100;
                sal.Tax = s * 10 / 100;
            }
            else if (s > 30000 && s < 50000)
            {
                sal.HRA = s * 15 / 100;
                sal.DA = s * 5 / 100;
                sal.Tax = s * 7 / 100;
            }
            else
            {
                sal.HRA = s * 10 / 100;
                sal.DA = s * 5 / 100;
                sal.Tax = s * 5 / 100;
            }


            db.Salaries.Add(sal);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult Edit(long ID)
        {

            ViewBag.Department = db.Departments.ToList();

            Empploye pro = db.Empployes.Where(temp => temp.EmployeId == ID).FirstOrDefault();
            TempData["ProfilePath"] = pro.Profile;

            return View(pro);
        }

        [HttpPost]
        public ActionResult Edit(Empploye E)
        {

            Empploye pro = db.Empployes.Where(temp => temp.EmployeId == E.EmployeId).FirstOrDefault();
            pro.EmployeName = E.EmployeName;
            pro.Designation = E.Designation;
            pro.DateOfJoing = E.DateOfJoing;
            pro.City = E.City;
            pro.Contact = E.Contact;
            pro.DepartmentId = E.DepartmentId;
            pro.Sals = E.Sals;
            pro.Status = E.Status;

            if (E.Profile != null)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                pro.Profile = base64String;
            }
            else
            {
                string path = Convert.ToString(TempData["ProfilePath"]);
                pro.Profile = path;
            }

            db.SaveChanges();

            int s = E.Sals;
            int EmpId = pro.EmployeId;


            Salary sal = db.Salaries.Where(temp => temp.EmployeId == E.EmployeId).FirstOrDefault();

            sal.Salarys = s;
            if (s > 50000)
            {
                sal.HRA = s * 20 / 100;
                sal.DA = s * 7 / 100;
                sal.Tax = s * 10 / 100;
            }
            else if (s > 30000 && s < 50000)
            {
                sal.HRA = s * 15 / 100;
                sal.DA = s * 5 / 100;
                sal.Tax = s * 7 / 100;
            }
            else
            {
                sal.HRA = s * 10 / 100;
                sal.DA = s * 5 / 100;
                sal.Tax = s * 5 / 100;
            }



            db.SaveChanges();

            return RedirectToAction("Index", "Employe");
        }



        public ActionResult Details(int id)
        {

            Empploye Detail = db.Empployes.Where(temp => temp.EmployeId == id).FirstOrDefault();

            return View(Detail);
        }
    }
}