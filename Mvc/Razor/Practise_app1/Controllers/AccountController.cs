using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practise_app1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult login(string Username, string Password)
        {
            if (Username == "admin" && Password == "@123")
            {
                return RedirectToAction("Dashboard","Admin");
            }
            else
            {
                return RedirectToAction("InvalidLogin");
            }

        }
        public ActionResult InvalidLogin(string Username, string Password)
        {
            return View();
        }
    }
}