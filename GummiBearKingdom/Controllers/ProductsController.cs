using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepo;

        public ProductsController(IProductRepository repo = null)
        {
            if(repo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = repo;
            }
        }

        public ViewResult Index()
        {
            return View(productRepo.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            Product thisProduct = productRepo.Products.Include(products => products.Reviews).FirstOrDefault(p => p.ProductId == id);
            return View(thisProduct);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productRepo.Save(product);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Product thisProduct = productRepo.Products.FirstOrDefault(products => products.ProductId == id);
            return View(thisProduct);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            productRepo.Edit(product);
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            Product thisProduct = productRepo.Products.FirstOrDefault(products => products.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Product thisProduct = productRepo.Products.FirstOrDefault(products => products.ProductId == id);
            productRepo.Remove(thisProduct);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAll()
        {
            return View();
        }
        [HttpPost, ActionName("DeleteAll")]
        public IActionResult DeleteAllConfirmed()
        {
            productRepo.RemoveAll();
            return View("Index");
        }
    }
}