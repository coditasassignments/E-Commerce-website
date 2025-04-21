
using Microsoft.EntityFrameworkCore;
using E_Commerce_Website.Models;

namespace E_Commerce_Website.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { ID = 1, UserName = "Pranjali", Password = "1234" }
                );

            modelBuilder.Entity<Cart>();

            modelBuilder.Entity<Product>().HasData(
                new Product { ID = 1, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" },

                new Product { ID = 2, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" },

                new Product { ID = 3, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" },

                new Product { ID = 4, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" },

                new Product { ID = 5, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" },

                new Product { ID = 6, Name = "Shirt", Description = "Cotton Shirt for comfort", Price = 599, Image = "https://static.vecteezy.com/system/resources/thumbnails/028/252/048/small/men-s-t-shirt-realistic-mockup-in-different-colors-ai-generated-photo.jpg" }
                );
            modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderItem>().Property(oi => oi.Price).HasColumnType("decimal(18,2)");



            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
