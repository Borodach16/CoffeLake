using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CoffeLake.Areas.Admin.Models;

namespace CoffeLake.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Index()
        {
            var db = new CoffeLakeContainer();
            var items = db.ProductSet.Include(x => x.ProductCategory).ToList();

            return View(items);
        }

        public ActionResult Edit(int id)
        {
            var db = new CoffeLakeContainer();
            var model = new ProductsEditPage();

            model.Products = db.ProductSet.Where(x => x.Id == id).FirstOrDefault();
            model.Categories = db.ProductCategorySet.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditModel(Product model)
        {
            var db = new CoffeLakeContainer();
            var element = db.ProductSet.Where(x => x.Id == model.Id).FirstOrDefault();

            if (element != null)
            {
                element.Caption = model.Caption;
                element.Description = model.Description;
                element.Price = model.Price;
                element.ProductCategoryId = model.ProductCategoryId;
                element.Quantity = model.Quantity;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Create()
        {
            var db = new CoffeLakeContainer();
            var model = db.ProductCategorySet.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateModel(Product model)
        {
            var db = new CoffeLakeContainer();
            var element = new Product();

            element.Caption = model.Caption;
            element.Description = model.Description;
            element.Price = model.Price;
            element.ProductCategoryId = model.ProductCategoryId;
            element.Quantity = model.Quantity;

            db.ProductSet.Add(element);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var db = new CoffeLakeContainer();
            var element = db.ProductSet.Where(x => x.Id == id).FirstOrDefault();

            db.ProductSet.Remove(element);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}