using Lesson06.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson06.Enitities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
