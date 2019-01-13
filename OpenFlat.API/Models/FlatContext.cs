using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using OpenFlat.API.Models.Attributes;
using OpenFlat.API.Models.Dtos;
using OpenFlat.API.Models.Entities;
using OpenFlat.API.Models.Entities.Base;

namespace OpenFlat.API.Models
{
    public class FlatContext : DbContext
    {
        private readonly int? _authorizedUserId;

        public FlatContext()
        {
            _authorizedUserId = null;
        }

        public FlatContext(int authorizedUserId)
        {
            _authorizedUserId = authorizedUserId;
        }

        private void BeforeSaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.Entity is BaseEntity
                           select e.Entity as BaseEntity;
            foreach (var entity in entities)
            {
                var entityState = this.Entry(entity).State;
                foreach (var prop in entity.GetType().GetProperties())
                {
                    var attDateTime = prop.GetCustomAttribute<ColumnCurrentDateTimeAttribute>();
                    if (attDateTime?.State == entityState)
                    {
                        prop.SetValue(entity, DateTime.Now);
                    }
                    if (_authorizedUserId.HasValue)
                    {
                        var attUser = prop.GetCustomAttribute<ColumnUserAttribute>();
                        if (attUser?.State == entityState)
                        {
                            prop.SetValue(entity, _authorizedUserId.Value);
                        }
                    }
                }
                if (_authorizedUserId.HasValue && entity is BaseRecordEntity)
                {
                    var recEntity = entity as BaseRecordEntity;
                    if (entityState == EntityState.Added)
                    {
                        recEntity.AddTime = DateTime.Now;
                        recEntity.AddUserId = _authorizedUserId.Value;
                    }
                    if (entityState == EntityState.Modified)
                    {
                        recEntity.UpdTime = DateTime.Now;
                        recEntity.UpdUserId = _authorizedUserId.Value;
                    }
                    if (entityState == EntityState.Deleted)
                    {
                        this.Entry(entity).State = EntityState.Modified;
                        recEntity.DelTime = DateTime.Now;
                        recEntity.DelUserId = _authorizedUserId.Value;
                        recEntity.Deleted = true;
                    }
                }
            }
        }

        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            BeforeSaveChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

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
