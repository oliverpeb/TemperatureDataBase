using Microsoft.EntityFrameworkCore;
using Temperature.Models;

namespace Temperature.Contexts
{
    public class TempDbContext : DbContext
    {
        public TempDbContext(DbContextOptions<TempDbContext> options) : base(options) { }

        public DbSet<Temperatures> temperatures { get; set; } // DbSet af typen temp
    }
}



