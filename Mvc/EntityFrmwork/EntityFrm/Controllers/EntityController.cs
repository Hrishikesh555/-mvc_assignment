using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrm.Models;

namespace EntityFrm.Controllers
{
    public class EntityController : Controller
    {
        // GET: Entity
        public ActionResult Index()
        {
            CompanyEntities cmp = new CompanyEntities();

            return View(cmp.Employes);
        }
        [HttpGet]
        public ActionResult Create()
        {
           /* CompanyEntities cmp = new CompanyEntities();
            List<string> dept= new List<string>();
            foreach (Department d in cmp.Departments)
            {
                dept.Add(d.Depno.ToString());
            }*/
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            CompanyEntities cmp = new CompanyEntities();
            Employe e = new Employe();
            e.Eno = Convert.ToInt32(collection["Eno"].ToString());
            e.Ename = collection["Ename"].ToString();
            e.Salary= Convert.ToInt32(collection["Salary"].ToString());
            e.Designation=collection["Depno"].ToString();
            
            cmp.Employes.Add(e);
            cmp.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}