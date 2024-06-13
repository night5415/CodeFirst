
using Code_First.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace Code_First.Contexts
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options): base(options) { }

        public DbSet<Cars> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AutomotiveConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>().ToTable("Cars");

            modelBuilder.Entity<Cars>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Cars>()
                .Property(b => b.Make)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Cars>()
                .Property(b => b.Model)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
