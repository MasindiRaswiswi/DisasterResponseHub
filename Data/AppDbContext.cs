using DisasterResponseHub.Models;
using Microsoft.EntityFrameworkCore;

namespace DisasterResponseHub.ResourceAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Donor> Donors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donor>().ToTable("Donor");
        }
    }
}
