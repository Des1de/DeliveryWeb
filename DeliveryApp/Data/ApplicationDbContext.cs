using Microsoft.EntityFrameworkCore;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DeliveryApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
      

        public DbSet<Dish> Dishes { get; set; } 
        public DbSet<Order> Orders { get; set; }    
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDish> CartDishes { get; set;}
        public DbSet<OrderDish> OrderDishes { get; set; }
    }
}
