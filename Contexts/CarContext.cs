
using Code_First.Entities;
using Microsoft.EntityFrameworkCore;
namespace Code_First.Contexts
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options):base(options) { }

        public DbSet<Cars> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>().ToTable("Cars");

            modelBuilder.Entity<Cars>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Cars>()
                .Property(b => b.Make)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Cars>()
                .Property(b => b.Model)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
