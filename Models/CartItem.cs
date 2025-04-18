using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website.Models
{
    public class CartItem
    {
        [Key]
        public int ID { get; set; }
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart? Cart { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int Quantity { get; set; }


    }
}
