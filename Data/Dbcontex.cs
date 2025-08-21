using Microsoft.EntityFrameworkCore;
using OOP_final.Components.Models;

namespace OOP_final.Components.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Fulltime>().HasBaseType<Employee>();
            modelBuilder.Entity<Parttime>().HasBaseType<Employee>();
        }
    }
}
