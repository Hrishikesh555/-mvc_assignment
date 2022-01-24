using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practise_app5.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [Route("Product/Details/{Id:int?}")]
        public ActionResult Details(int? Id)
        {
            var products = new[]
            {
                new{ProductId=1,ProductNm="Phone",Cost=8000},
                new{ProductId=2,ProductNm="Laptop",Cost=80000},
                new{ProductId=3,ProductNm="PowerBank",Cost=1000}
            };
            if (Id == null)
            {
                return Content("Please Enter a Id ");
            }
            else
            {
                string Prodctnm = "";
                foreach (var item in products)
                {
                    if (item.ProductId == Id)
                    {
                        Prodctnm = item.ProductNm;
                    }
                }
                return Content(Prodctnm);
            }

        }

        [Route("Product/Products/{productNm}")]
        public ActionResult Products(string productNm)
        {
            var products = new[]
            {
                new{ProductId=1,ProductNm="Phone",Cost=8000},
                new{ProductId=2,ProductNm="Laptop",Cost=80000},
                new{ProductId=3,ProductNm="PowerBank",Cost=1000}
            };
            if (productNm == null)
            {
                return Content("Please Enter a name of product ");
            }
            else
            {
                int ProdctId = 0;
                foreach (var item in products)
                {
                    if (item.ProductNm == productNm)
                    {
                        ProdctId = item.ProductId;
                    }
                }
                return Content(ProdctId.ToString());
            }

        }
    }
}