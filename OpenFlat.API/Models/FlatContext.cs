using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using OpenFlat.API.Models.Entities;

namespace OpenFlat.API.Models
{
    public class FlatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=OpenFlat;Username=postgres;Password=masterkey");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.UserName).IsUnique();
            });
        }

        //Entities
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
