using BestsellerBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace BestsellerBlog.Data
{
    public class BlogDbContext : DbContext
    {
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6ODJ8SS;Database=Bestseller;User Id=sa;Password=demo1234;Trust Server Certificate=true");
        }

        public DbSet<Post> Posts { get; set; }

    }
}
