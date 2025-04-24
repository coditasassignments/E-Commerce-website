using E_Commerce_Website.Data;
using E_Commerce_Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Website.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {

            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult ProductList()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            
            if (ModelState.IsValid)
            {
                
                _context.Products.Add(product);
                _context.SaveChanges();
                Console.WriteLine(">>> Product Saved");
                return RedirectToAction("ProductList");
            }
            
            return View(product);
        }
        public IActionResult UpdateQuantity(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ID == id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateQuantity(Product model)
        {
            var product = _context.Products.FirstOrDefault(p => p.ID == model.ID);
            if (product == null) return NotFound();

            product.Quantity = model.Quantity;
            _context.SaveChanges();

            return RedirectToAction("ProductList");
        }


        public IActionResult DecreaseQuantity(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            if (product.Quantity > 0)
            {
                product.Quantity--;
                _context.SaveChanges();
            }

            return RedirectToAction("ProductList");
        }

    }
}
