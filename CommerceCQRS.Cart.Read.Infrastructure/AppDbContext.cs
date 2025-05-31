using CommerceCQRS.Cart.Read.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CommerceCQRS.Cart.Read.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CartDto> Carts { get; set; }
    }
}
