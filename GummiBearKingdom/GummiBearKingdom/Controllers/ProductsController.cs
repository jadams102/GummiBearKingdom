using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Controllers
{
    public class ProductsController : Controller
    {
        private GummiBearDbContext db = new GummiBearDbContext();
        public IActionResult Index()
        {
            List<Product> model = db.Products.ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Product thisProduct = db.Products.FirstOrDefault(products => products.ProductId == id);
            return View(thisProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}