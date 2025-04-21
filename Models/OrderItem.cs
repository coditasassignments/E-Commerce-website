namespace E_Commerce_Website.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => Price * Quantity;

        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
