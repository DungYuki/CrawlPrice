using GetPriceUrl.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GetPriceUrl.Infrastructure
{
    public class LaptopPriceDbContext : DbContext
    {
        public LaptopPriceDbContext(DbContextOptions<LaptopPriceDbContext> options) : base(options) { }

        public DbSet<LaptopURL> LaptopURL { get; set; }
    }
}
