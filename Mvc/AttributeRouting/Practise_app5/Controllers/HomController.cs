using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practise_app5.Controllers
{
    public class HomController : Controller
    {
        // GET: Hom
        [Route ("Hom/index")]
        [Route ("")]
        public ActionResult index()
        {
            return View();
        }
        [Route("Hom/About")]
        public ActionResult About()
        {
            return View();
        }
        [Route("Hom/Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("Hom/Profilee")]
        public ActionResult Profilee()
        {
            return View();
        }
        
      

    }
}