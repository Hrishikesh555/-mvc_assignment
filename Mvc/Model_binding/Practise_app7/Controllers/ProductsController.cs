using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practise_app7.Models;

namespace Practise_app7.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product(){ProductId=101,ProductName="Phone",Rate=8500 },
                new Product(){ProductId=102,ProductName="LAptop",Rate=85000 },
                new Product(){ProductId=103,ProductName="Machine",Rate=55000 }
            };
           
            return View(products);
        }
        public ActionResult Details(int Id)

        {
            List<Product> products = new List<Product>
            {
                new Product(){ProductId=101,ProductName="Phone",Rate=8500 },
                new Product(){ProductId=102,ProductName="LAptop",Rate=85000 },
                new Product(){ProductId=103,ProductName="Machine",Rate=55000 }
            };
            Product matchingprod=null;
            foreach (var item in products)
            {
                if(item.ProductId==Id)
                {
                    matchingprod = item;
                }
            }
    
            return View(matchingprod);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            return View();
        }
    }
}