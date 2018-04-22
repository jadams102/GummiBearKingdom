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
        private GummiBearDbContext db = new GummiBearDbContext();
        public IActionResult Index()
        {
            List<Product> model = db.Products.ToList();
            return View(model);
        }
    }
}
