using Microsoft.AspNetCore.Mvc;
using E_Commerce_Website.Models;
using E_Commerce_Website.Data;

namespace E_Commerce_Website.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}

