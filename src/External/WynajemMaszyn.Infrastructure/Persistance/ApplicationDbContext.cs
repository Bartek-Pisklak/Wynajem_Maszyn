using WynajemMaszyn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace WynajemMaszyn.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User>
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

        public DbSet<User> Users => Set<User>();
        public DbSet<Permission> Permissions => Set<Permission>();

        public DbSet<MachineryRentalList> MachineryRentalLists => Set<MachineryRentalList>();
        public DbSet<ExcavatorBucketList> ExcavatorBucketLists => Set<ExcavatorBucketList>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>()
                .HasIndex(r => r.Email)
                .IsUnique();

            modelBuilder.Entity<ExcavatorBucketList>()
                    .HasNoKey();
            modelBuilder.Entity<MachineryRentalList>()
                    .HasNoKey();
        // enums
        //fuel
        modelBuilder.Entity<Excavator>()
                   .Property(m => m.FuelType)
                   .HasConversion<string>();
            modelBuilder.Entity<Roller>()
                   .Property(m => m.FuelType)
                   .HasConversion<string>();
            modelBuilder.Entity<Harvester>()
                   .Property(m => m.FuelType)
                   .HasConversion<string>();
            modelBuilder.Entity<WoodChipper>()
                   .Property(m => m.FuelType)
                   .HasConversion<string>();

            // machineryRental
            modelBuilder.Entity<MachineryRental>()
                   .Property(m => m.RentalStatus)
                   .HasConversion<string>();
            modelBuilder.Entity<MachineryRental>()
                   .Property(m => m.PaymentStatus)
                   .HasConversion<string>();


            // roller
            modelBuilder.Entity<Roller>()
                   .Property(m => m.RollerType)
                   .HasConversion<string>();

            // excavator
            modelBuilder.Entity<Excavator>()
                   .Property(m => m.TypeChassis)
                   .HasConversion<string>();
            modelBuilder.Entity<Excavator>()
                   .Property(m => m.TypeExcavator)
                   .HasConversion<string>();



            // identity
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
        }
    }
}
