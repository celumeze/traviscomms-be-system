using FlexiComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlexiComms.Data.Repository
{
    public class FlexiCommsDbContext : DbContext
    {
        public FlexiCommsDbContext(DbContextOptions options) : base(options)
        {

        }

        private void AuditShadowProperties(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<string>(nameof(EntityBase.CreatedBy));
                modelBuilder.Entity(entityType.Name).Property<DateTime>(nameof(EntityBase.DateCreated));
                modelBuilder.Entity(entityType.Name).Property<string>(nameof(EntityBase.ModifiedBy));
                modelBuilder.Entity(entityType.Name).Property<DateTime>(nameof(EntityBase.DateModified));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlexiCommsDbContext).Assembly);            
            AuditShadowProperties(modelBuilder);
            modelBuilder.Seed();
            modelBuilder.HasDefaultContainer("FlexiCommsDbDocuments");
        }

        public override int SaveChanges()
        {
            var timeStamp = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified && !e.Metadata.IsOwned()))
            {
                entry.Property(nameof(EntityBase.DateModified)).CurrentValue = timeStamp;

                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(EntityBase.DateCreated)).CurrentValue = timeStamp;
                }
            }
            return base.SaveChanges();
        }

        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
