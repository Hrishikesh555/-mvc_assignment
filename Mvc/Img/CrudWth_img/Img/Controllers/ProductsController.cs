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
        public ActionResult Index(string search="")
        {

            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            ViewBag.search = search;
            List<Product> products = db.Products.Where(temp=>temp.ProductName.Contains(search)).ToList();
            return View(products);
        }
        public ActionResult Add()//AutoGenrated
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            List<Product> products = db.Products.Where(temp=>temp.CategoryID==1&& temp.Price >5500).ToList();
            return View(products);
        }
         public ActionResult Details(long id)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }
        public ActionResult Create()
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Brand = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p )
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
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
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Brand = db.Brands.ToList();
            Product pro = db.Products.Where(temp => temp.ProductID == ID).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
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
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product p = db.Products.Where(temp => temp.ProductID == ID).FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(long ID,Product p)
        {
            EFDBFirstDatabaseEntities db = new EFDBFirstDatabaseEntities();
            Product pr = db.Products.Where(temp => temp.ProductID == ID).FirstOrDefault();
            db.Products.Remove(pr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}