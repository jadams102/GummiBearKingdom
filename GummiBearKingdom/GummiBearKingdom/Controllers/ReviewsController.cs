using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Controllers
{
    public class ReviewsController : Controller
    {
        private GummiBearDbContext db = new GummiBearDbContext();
        public IActionResult Create(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(product => product.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("Products", "Detail", review.ProductId);
        }
        public IActionResult Edit(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }
        [HttpPost]
        public IActionResult Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Products", "Detail", review.ProductId);
        }
    }
}
