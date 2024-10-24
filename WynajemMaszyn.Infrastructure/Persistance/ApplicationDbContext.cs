using WynajemMaszyn.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace WynajemMaszyn.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Excavator> Excavators => Set<Excavator>();
        public DbSet<ExcavatorBucket> ExcavatorsBuckets => Set<ExcavatorBucket>();

        public DbSet<WoodChipper> WoodChippers => Set<WoodChipper>();
        public DbSet<Harvester> Harvesters => Set<Harvester>();
        public DbSet<Roller> Rollers => Set<Roller>();


        public DbSet<Machinery> Machiners => Set<Machinery>(); 
        public DbSet<MachineryRental> MachineryRentals => Set<MachineryRental>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<User> Users => Set<User>();




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>()
                .HasIndex(r => r.Email)
                .IsUnique();

        }
    }
}
