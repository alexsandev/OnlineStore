using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Context
{
    public class OnlineStoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options) { }
    }
}
