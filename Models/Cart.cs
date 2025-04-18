using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website.Models
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User? User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
