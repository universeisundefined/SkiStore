using Microsoft.EntityFrameworkCore;
using SkiStore.Core.Entities;

namespace SkiStore.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}