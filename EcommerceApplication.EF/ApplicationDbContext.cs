using EcommerceApplication.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.EF
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    

        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartStatues> CartStatues { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<OrderDetials> OrderDetials { get; set; }
        public DbSet<OrderTable> OrderTables { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}