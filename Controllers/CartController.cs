using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Website.Models;
using E_Commerce_Website.Data;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace E_Commerce_Website.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Dummy UserID
        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst("UserID")?.Value;
            if (userIdClaim != null)
            {
                return int.Parse(userIdClaim);
            }
            else
            {
                
                return 0;
            }
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            
            var userId = GetCurrentUserId();


            var cart = _context.Carts.FirstOrDefault(c => c.UserID == userId);
            if (cart == null)
            {
                cart = new Cart { UserID = userId };
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            var product = _context.Products.FirstOrDefault(p => p.ID == productId);
            if (product == null)
            {
                TempData["Error"] = "Product not found!";  // Agar product nahi milta
                return RedirectToAction("Index", "Product");
            }
            if (product.Quantity < quantity)
            {
                TempData["Error"] = "Not enough stock available for this product.";  // Quantity exceed hone par error message
                return RedirectToAction("Index", "Product");
            }


            var existingCartItem = _context.CartItems.FirstOrDefault(ci => ci.CartId == cart.ID && ci.ProductId == productId);
            if (existingCartItem != null)
            {
                if (existingCartItem.Quantity + quantity <= product.Quantity)  // Ensure total quantity doesn't exceed stock
                {
                    existingCartItem.Quantity += quantity;
                    _context.CartItems.Update(existingCartItem);
                    product.Quantity -= quantity;  // Decrease the product quantity from available stock
                }
                else
                {
                    TempData["Error"] = "Cannot add more than the available stock!";  // Stock limit exceeded
                    return RedirectToAction("Index", "Product");
                }
            }
            else
            {
                // If product is not in the cart, add it as a new cart item
                var newCartItem = new CartItem
                {
                    CartId = cart.ID,
                    ProductId = productId,
                    Quantity = quantity
                };
                _context.CartItems.Add(newCartItem);
                product.Quantity -= quantity;  // Decrease the product quantity from available stock
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Product");  // Redirect to product list after adding to cart
        }


        public IActionResult Index()
        {
            var userId = GetCurrentUserId();

            var cart = _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.UserID == userId);
            if(cart == null)
            {
                return View(new List<CartItem>());
            }
            return View(cart.CartItems.ToList());
        }
        public IActionResult ViewCart()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            int userId = int.Parse(User.FindFirst("UserID")!.Value);
            var cart = _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefault(c => c.UserID == userId);
            if(cart == null || !cart.CartItems.Any())
            {
                ViewBag.Message = "Your cart is Empty.";
                return View(new List<CartItem>());
            }
            decimal grandTotal = (decimal)cart.CartItems.Sum(item => (item.Product?.Price ?? 0) * item.Quantity);
            ViewBag.GrandTotal = grandTotal;
            foreach (var item in cart.CartItems)
            {
                item.Product = _context.Products.FirstOrDefault(p => p.ID == item.ProductId);
            }

            return View(cart.CartItems.ToList());
        }
        
        [HttpPost]
        public IActionResult IncreaseQuantity(int cartItemId)
        {
            var cartItem = _context.CartItems.Include(ci => ci.Product).FirstOrDefault(ci => ci.ID == cartItemId);
            if (cartItem != null)
            {
                var availableStock = cartItem.Product.Quantity;

                if (cartItem.Quantity < availableStock)
                {
                    cartItem.Quantity++;
                    _context.SaveChanges();
                }
                else
                {
                    TempData["StockError"] = $"Only {availableStock} items available in stock for '{cartItem.Product.Name}'.";
                }
            }

            return RedirectToAction("ViewCart");
        }

        [HttpPost]
        public IActionResult DecreaseQuantity(int cartItemId)
        {
            var cartItem = _context.CartItems.FirstOrDefault(ci => ci.ID == cartItemId);
            if(cartItem!= null && cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
                _context.SaveChanges();
            }
            return RedirectToAction("ViewCart");
        }
        [HttpPost]
        public IActionResult RemoveItem(int cartItemId)
        {
            try
            {
                var cartItem = _context.CartItems.FirstOrDefault(ci => ci.ID == cartItemId);
                if(cartItem == null)
                {
                    TempData["Error Message"] = "Item Not Found in your Cart!";
                    return RedirectToAction("ViewCart");
                }
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Item removed successfully!";

            }
            catch(Exception )
            {
                TempData["Error Message"] = "Error occured while removing the item. Please try again later!";
                
            }
            return RedirectToAction("ViewCart");

        }
        

    }
}
