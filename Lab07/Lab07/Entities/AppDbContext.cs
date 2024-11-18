using Lab07.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab07.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Bans { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
