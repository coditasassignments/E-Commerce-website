
namespace E_Commerce_Website.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public List<CartItem>? CartItems { get; set; } = new List<CartItem>();

        
    }
}
