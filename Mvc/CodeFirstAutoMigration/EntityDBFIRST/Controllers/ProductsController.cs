using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDBFIRST.Models;

namespace EntityDBFIRST.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string search="",string SortColumn = "ProductName",string IconClass = "fa-sort-asc")
        {

            CompanyDbCotext db = new CompanyDbCotext();
            ViewBag.search = search;
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if(ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.DateofPurchase).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DateofPurchase).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Category.CategoryName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Category.CategoryName).ToList();
            }
            else if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Brand.BrandName).ToList();
            }


            return View(products);
        }
        public ActionResult Add()//AutoGenrated
        {
            CompanyDbCotext db = new CompanyDbCotext();
            List<Product> products = db.Products.Where(temp=>temp.CategoryID==1&& temp.Price >5500).ToList();
            return View(products);
        }
         public ActionResult Details(long id)
        {
            CompanyDbCotext db = new CompanyDbCotext();
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }
        public ActionResult Create()
        {
            CompanyDbCotext db = new CompanyDbCotext();
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Brand = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p )
        {
            CompanyDbCotext db = new CompanyDbCotext();
            if(Request.Files.Count >=1)
            {
                var file = Request.Files[0];
                var imageByte = new Byte[file.ContentLength];
                file.InputStream.Read(imageByte, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imageByte, 0, imageByte.Length);
                p.Photo = base64String;
            }
            
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long ID)
        {
            CompanyDbCotext db = new CompanyDbCotext();
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Brand = db.Brands.ToList();
            Product pro = db.Products.Where(temp => temp.ProductID == ID).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            CompanyDbCotext db = new CompanyDbCotext();
            Product pro = db.Products.Where(temp => temp.ProductID ==p.ProductID).FirstOrDefault();
            pro.ProductName = p.ProductName;
            pro.Price = p.Price;
            pro.DateofPurchase = p.DateofPurchase;
            pro.AvailabilityStatus = p.AvailabilityStatus;
            pro.CategoryID = p.CategoryID;
            pro.BrandID = p.BrandID;
            pro.Active = p.Active;
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }

       
        public ActionResult Delete(long ID)
        {
            CompanyDbCotext db = new CompanyDbCotext();
            Product p = db.Products.Where(temp => temp.ProductID == ID).FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(long ID,Product p)
        {
            CompanyDbCotext db = new CompanyDbCotext();
            Product pr = db.Products.Where(temp => temp.ProductID == ID).FirstOrDefault();
            db.Products.Remove(pr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}