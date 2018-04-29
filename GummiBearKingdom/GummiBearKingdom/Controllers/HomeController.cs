using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepo;

        public HomeController(IProductRepository repo = null)
        {
            if (repo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = repo;
            }
        }

        public IActionResult Index()
        {
            List<Product> products = productRepo.Products.Include(p=> p.Reviews).ToList();
            List<Product> sortedProducts = products.OrderByDescending(p => p.AvgRating()).ToList();
            List<Product> topThreeProducts = new List<Product> { sortedProducts[0], sortedProducts[1], sortedProducts[2] };
            return View(topThreeProducts);
        }
    }
}
