using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practise_app1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View("OurCompanyProducts");
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult GetEmpName(int EmpId)
        {
            var Employee = new[]{
                new { EmpId=1,EmpName="Hrishi",Salary=1000 },
                new { EmpId=2,EmpName="Rahul",Salary=2000 },
                new { EmpId=3,EmpName="Rahul",Salary=2000 }
            };
            string matchEmpName=null;
            foreach (var item in Employee)
            {
                if(item.EmpId==EmpId)
                {
                    matchEmpName = item.EmpName;
                }
            }
            return Content(matchEmpName , "text/plain");
            
        }
        public ActionResult GetPaySlip(int EmpId)
        {
            string filename= "-/name" + EmpId+ ".pdf";

            return File(filename, "application/pdf");
        }

        public ActionResult EmpfBpage(int EmpId)
        {
            var Employee = new[]{
                new { EmpId=1,EmpName="Hrishi",Salary=1000 },
                new { EmpId=2,EmpName="Rahul",Salary=2000 },
                new { EmpId=3,EmpName="Rahul",Salary=2000 }
            };
            string FBurl = null;
            foreach (var item in Employee)
            {
                if (item.EmpId == EmpId)
                {
                    FBurl = "http://www.facebook.com/emp" + EmpId;
                }
            }
                if(FBurl==null)
                {
                    return Content("Envalid Id");
                }
                else
                {
                    return Redirect(FBurl);
                }
        }

        public ActionResult StudentsDetails()
        {
            ViewBag.studentId = 101;
            ViewBag.StudentName = "Hrishi";
            ViewBag.Mark = 85;
            ViewBag.NoofSem = 6;
            return View();
        }

    }
}