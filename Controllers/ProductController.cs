using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CoffeLake.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            /*var Tea = new Product();
            Tea.Name = "Чай Гринфилд";
            Tea.Id = 1;
            Tea.Price = 120;
            Tea.Discription = "Вкусный чай";
            Tea.ImageUrl = "../Content/images/tea.jpg";
            Tea.Country = "Великобритания";
            Tea.ProductCategory = new ProductCategory();
            Tea.ProductCategory.Name = "Чай";

            var Coffe = new Product();
            Coffe.Name = "Кофе Нескафе";
            Coffe.Id = 1;
            Coffe.Price = 500;
            Coffe.Discription = "Кофе с эффектом пробуждения";
            Coffe.ImageUrl = "";
            Coffe.Country = "Швейцария";
            Coffe.ProductCategory = new ProductCategory();
            Coffe.ProductCategory.Name = "Кофе";

            var model = new List<Product>();
            model.Add(Tea);
            model.Add(Coffe);

            return View(model);*/

            var db = new CoffeLakeContainer();
            var items = db.ProductSet.Include(x => x.ProductCategory).ToList();
            return View(items);
        }
    }
}