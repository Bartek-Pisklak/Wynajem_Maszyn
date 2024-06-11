using WynajemMaszyn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;

namespace BlazorServerCleanArchitecture.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 

        }

        public DbSet<Excavator> Excavators => Set<Excavator>();
        public DbSet<Roller> Rollers => Set<Roller>();
        public DbSet<Permision> Permisions => Set<Permision>();
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
