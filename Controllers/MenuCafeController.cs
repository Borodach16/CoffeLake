using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CoffeLake.Controllers
{
    public class MenuCafeController : Controller
    {
        // GET: MenuCaffe
        public ActionResult Index()
        {
            /*var Tea = new MenuCafe();
            Tea.Name = "Чай Гринфилд";
            Tea.Price = 120;
            Tea.Id = 1;
            Tea.MenuCategory = new MenuCategory();
            Tea.MenuCategory.Name = "Напитки";

            var Coffe = new MenuCafe();
            Coffe.Name = "Кофе Нескафе";
            Coffe.Price = 500;
            Coffe.Id = 1;
            Coffe.MenuCategory = new MenuCategory();
            Coffe.MenuCategory.Name = "Напитки";

            var model = new List<MenuCafe>();
            model.Add(Tea);
            model.Add(Coffe);

            return View(model);*/

            var db = new CoffeLakeContainer();
            var items = db.CoffeLakeMenuSet.Include("MenuCategory").ToList();
            return View(items);
        }
    }
}