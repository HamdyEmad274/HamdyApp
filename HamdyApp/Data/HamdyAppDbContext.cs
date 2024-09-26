using HamdyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HamdyApp.Data
{
    public class HamdyAppDbContext : DbContext
    {
        public HamdyAppDbContext(DbContextOptions<HamdyAppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Horror", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Sci-Fi", DisplayOrder = 3 }
           );
        }
        public DbSet<Category> Categories { get; set; }
    }
}
