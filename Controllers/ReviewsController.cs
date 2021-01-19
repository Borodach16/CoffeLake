using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeLake.Controllers
{
    public class ReviewsController : Controller
    {
        // GET: Reviews
        public ActionResult Index()
        {
            var db = new CoffeLakeContainer();
            var items = db.ReviewsSet.ToList();
            return View(items);
        }

        public ActionResult Create()
        {
            var db = new CoffeLakeContainer();
            var items = db.ReviewsSet.ToList();

            return View(items);
        }
        [HttpPost]
        public ActionResult CreateModel(Reviews model)
        {
            var db = new CoffeLakeContainer();
            var element = new Reviews();

            element.ReviewAuthor = model.ReviewAuthor;
            element.ReviewText = model.ReviewText;
            element.Rating = model.Rating;
            element.PictureUrl = model.PictureUrl;
            db.ReviewsSet.Add(element);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var db = new CoffeLakeContainer();
            var element = db.ReviewsSet.Where(x => x.Id == id).FirstOrDefault();

            db.ReviewsSet.Remove(element);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}