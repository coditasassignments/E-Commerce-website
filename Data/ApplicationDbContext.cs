using Microsoft.EntityFrameworkCore;
using E_Commerce_Website.Models;

namespace E_Commerce_Website.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ID = 1, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" },

                new Product { ID = 2, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" },

                new Product { ID = 3, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" },

                new Product { ID = 4, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" },

                new Product { ID = 5, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" },

                new Product { ID = 6, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" }
                );

            modelBuilder.Entity<CartItem>().HasData(
                new CartItem { ID = 1, ProductId = 1, Quantity = 2 },
                new CartItem { ID = 2, ProductId = 2, Quantity = 1 }
                );
        }
    }
}
