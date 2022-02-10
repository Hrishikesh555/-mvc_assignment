using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeProj.Models;

namespace EmployeProj.Areas.Admin.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Admin/Employe
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
        public ActionResult Create()
        {
            ViewBag.departmen = db.Departments.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Empploye E)
        {
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength - 1];
                file.InputStream.Read(imgBytes, 0, file.ContentLength - 1);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                E.Profile = base64String;
            }

            db.Empployes.Add(E);
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
            return RedirectToAction("Index", "Employe");
        }


        public ActionResult Details(int id)
        {

            Empploye Detail = db.Empployes.Where(temp => temp.EmployeId == id).FirstOrDefault();

            return View(Detail);
        }

        public JsonResult Delete(long ID)
        {
            bool result = false;

            Empploye pr = db.Empployes.Where(temp => temp.EmployeId == ID).FirstOrDefault();
            db.Empployes.Remove(pr);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }





    }
}