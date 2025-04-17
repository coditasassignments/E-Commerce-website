using Microsoft.AspNetCore.Mvc;
using E_Commerce_Website.Models;
using E_Commerce_Website.Data;
using Microsoft.AspNetCore.Authorization;

namespace E_Commerce_Website.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        [Authorize]
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

