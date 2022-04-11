using ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        private Func<Type, object> getRequiredService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>().HasData(
                    new Page { Id = 1, Title = "Home", Slug = "Home", Content = "Home Page", Sorting = 0 },
                    new Page { Id = 2, Title = "About Us", Slug = "about-us", Content = "About Us Page", Sorting = 100 },
                    new Page { Id = 3, Title = "Services", Slug = "services", Content = "Services Page", Sorting = 100 }
                );
        }*/

        // Create table named Categories in DB 
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<WishListDetail> WishListDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
    }
}
