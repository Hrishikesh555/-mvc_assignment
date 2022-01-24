using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Practise_app5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*routes.MapRoute(
              name: "Product",
              url: "Product/Products/{productNm}",
               defaults: new { controller = "Product", action = "Products", id = UrlParameter.Optional }
          );*/
            routes.MapRoute(
              name: "Product",
              url: "{controller}/{action}/{productNm}",
               defaults: new { },
                constraints: new { productNm = @"^[A-Za-z ]*$" }
              // constraints:new {productNm=@"[A-Za-z]^*$"}
          );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
                defaults: new { controller = "Hom", action = "index", id = UrlParameter.Optional }
           );
           

        }
    }
}
