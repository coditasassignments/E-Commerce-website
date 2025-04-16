
namespace E_Commerce_Website.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public  Product? Product { get; set;}
        public int Quantity { get; set; }
    }
}
