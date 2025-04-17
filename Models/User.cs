using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Website.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
