using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLaptop.Models;

namespace WebLaptop.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbShopLaptopContext _context;
        public ProductController(DbShopLaptopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(x => x.Cat).FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return RedirectToAction("Index");
            }         
            return View(product);
        }
    }
}
