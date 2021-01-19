using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CoffeLake.Areas.Admin.Models;

namespace CoffeLake.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        // GET: Admin/Menu
        public ActionResult Index()
        {
            var db = new CoffeLakeContainer();
            var items = db.CoffeLakeMenuSet.Include(x => x.MenuCategory).ToList();

            return View(items);
        }

        public ActionResult Edit(int id)
        {
            var db = new CoffeLakeContainer();
            var model = new MenuEditPage();

            model.Menu = db.CoffeLakeMenuSet.Where(x => x.Id == id).FirstOrDefault();
            model.Categories = db.MenuCategorySet.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditModel(CoffeLakeMenu model)
        {
            var db = new CoffeLakeContainer();
            var element = db.CoffeLakeMenuSet.Where(x => x.Id == model.Id).FirstOrDefault();

            if (element != null)
            {
                element.Caption = model.Caption;
                element.Price = model.Price;
                element.MenuCategoryId = model.MenuCategoryId;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Create()
        {
            var db = new CoffeLakeContainer();
            var model = db.MenuCategorySet.ToList();

            return View(model);
        }
        
        [HttpPost]
        public ActionResult CreateModel(CoffeLakeMenu model)
        {
            var db = new CoffeLakeContainer();
            var element = new CoffeLakeMenu();

            element.Caption = model.Caption;
            element.Price = model.Price;
            element.Description = model.Description;
            element.MenuCategoryId = model.MenuCategoryId;

            db.CoffeLakeMenuSet.Add(element);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var db = new CoffeLakeContainer();
            var element = db.CoffeLakeMenuSet.Where(x => x.Id == id).FirstOrDefault();

            db.CoffeLakeMenuSet.Remove(element);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}