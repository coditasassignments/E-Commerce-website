using E_Commerce_Website.Data;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_Website.Services;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly OrderService _orderService;

        public OrderController(ApplicationDbContext context, OrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            int userId = 1;
            var cartItems = await _context.CartItems.Include(c => c.Product).Where(c => c.Cart.UserID == userId).ToListAsync();
            await _orderService.PlaceOrder(userId, cartItems);
            return RedirectToAction("OrderSuccess");
        }

        public IActionResult OrderSuccess()
        {
            return View();
        }
    }
}
