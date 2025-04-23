using System;

namespace E_Commerce_Website.Models
{
    public class Product
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double Price { get; set; }
        public int Quantity { get; set; }
        public required string Image { get; set; }
    }
}
