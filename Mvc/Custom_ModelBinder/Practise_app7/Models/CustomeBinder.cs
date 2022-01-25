using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practise_app7.Models
{
    public class CustomeBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            int StudentId =Convert.ToInt32(controllerContext.HttpContext.Request.Form["StudentId"]);
            string StudentName = controllerContext.HttpContext.Request.Form["StudentName"];
            string Dno = controllerContext.HttpContext.Request.Form["Dno"];
            string Landmark = controllerContext.HttpContext.Request.Form["Landmark"];
            string City = controllerContext.HttpContext.Request.Form["City"];

            return new Student() { StudentId = StudentId, StudentName = StudentName, Adress = Dno + " ," + Landmark + "," + City };
        }
    }
}