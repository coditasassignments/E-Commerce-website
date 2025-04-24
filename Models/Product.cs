using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Website.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }
        public required string Description { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int Quantity { get; set; }
        public string? Image { get; set; }
    }
}
