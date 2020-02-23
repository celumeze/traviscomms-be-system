using FlexiComms.Data.Entities;
using FlexiComms.Data.Entities.Models;
using FlexiComms.Data.Repository.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiComms.Data.Repository
{
    public class FlexiCommsSqlDbContext : IdentityDbContext<MainUser, MainRole, string>
    {
        public FlexiCommsSqlDbContext(DbContextOptions<FlexiCommsSqlDbContext> options) : base(options)
        {
        }

        private void AuditShadowProperties(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if(!entityType.IsOwned())
                {
                    modelBuilder.Entity(entityType.Name).Property<string>(nameof(EntityBase.CreatedBy));
                    modelBuilder.Entity(entityType.Name).Property<DateTime>(nameof(EntityBase.DateCreated));
                    modelBuilder.Entity(entityType.Name).Property<string>(nameof(EntityBase.ModifiedBy));
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>(nameof(EntityBase.DateModified));
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlexiCommsSqlDbContext).Assembly);
            modelBuilder.Seed();
            AuditShadowProperties(modelBuilder);
        }

        public override int SaveChanges()
        {
            var timeStamp = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified && !e.Metadata.IsOwned()))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(EntityBase.DateModified)).CurrentValue = timeStamp;
                }

                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(EntityBase.DateCreated)).CurrentValue = timeStamp;
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var timeStamp = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified && !e.Metadata.IsOwned()))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(EntityBase.DateModified)).CurrentValue = timeStamp;
                }
                   
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(EntityBase.DateCreated)).CurrentValue = timeStamp;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<ClientServiceProvider> ClientsServiceProviders { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
