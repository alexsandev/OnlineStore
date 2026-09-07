using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Infrastructure.Context
{
    public class OnlineStoreDbContext : DbContext
    {
        OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options) 
        { 
        }
    }
}
