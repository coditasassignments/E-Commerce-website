using Microsoft.AspNetCore.Mvc;
using E_Commerce_Website.Models;
using E_Commerce_Website.Data;

namespace E_Commerce_Website.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.ID == productId);
            if(product == null)
            {
                return NotFound();
            }

            var cartItem = new CartItem
            {
                ProductId = productId,
                Quantity = quantity

            };

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}
