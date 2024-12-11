using Microsoft.EntityFrameworkCore;
using mvcWithDb.Models;

namespace mvcWithDb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Restaurant> Repas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "La petite Pizza", Location = "Paris 5ème" },
                new Restaurant { Id = 2, Name = "La petite Salade", Location = "Paris 6ème" }
            );
        }
    }
}
