using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CoffeLake.Areas.Admin.Models;

namespace CoffeLake.Areas.Admin.Controllers
{
    public class MenuCafeController : Controller
    {
        // GET: Admin/MenuCafe
        public ActionResult Index()
        {
            var db = new CoffeLakeContainer();
            var model = db.CoffeLakeMenuSet.Include(x=>x.MenuCategory).ToList();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var db = new CoffeLakeContainer();
            var model = new MenuCafeEditPage();
            model.CoffeLakeMenu = db.CoffeLakeMenuSet.Where(x => x.Id == id).FirstOrDefault();
            model.Categories = db.MenuCategorySet.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            var db = new CoffeLakeContainer();
            var categories = db.MenuCategorySet.ToList();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult Save(CoffeLakeMenu model)
        {
            var db = new CoffeLakeContainer();
            CoffeLakeMenu element;
            if(model.Id == 0)
            {
                element = new CoffeLakeMenu();
            }
            else
            {
                element = db.CoffeLakeMenuSet.Where(x => x.Id == model.Id).FirstOrDefault();
            }
            if(element != null)
            {
                element.Caption = model.Caption;
                element.Description = model.Description;
                element.Price = model.Price;
                element.MenuCategoryId = model.MenuCategoryId;
            }
            if(element.Id == 0)
            {
                db.CoffeLakeMenuSet.Add(element);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}