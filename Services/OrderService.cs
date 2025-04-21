using E_Commerce_Website.Data;
using E_Commerce_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task PlaceOrder(int userId, List<CartItem> cartItems)
        {
            if(cartItems == null || !cartItems.Any())
            {
                throw new ArgumentException("Cart items cannot be empty.");
            }
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = cartItems.Sum(item => item.Quantity * Convert.ToDecimal(item.Product.Price)),
                Status = OrderStatus.Pending

            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach(var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.OrderId,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Price = Convert.ToDecimal(cartItem.Product?.Price ?? 0)


                };
                _context.OrderItems.Add(orderItem);

            }
            await _context.SaveChangesAsync();

            //Remove cart items from database after successfullt placing order
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            

        }
    }
}
