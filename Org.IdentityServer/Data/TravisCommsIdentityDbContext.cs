using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.IdentityServer.Extensions;
using Org.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Org.IdentityServer.Data
{
    public class TravisCommsIdentityDbContext : IdentityDbContext<MainUser, MainRole, string>
    {

        public TravisCommsIdentityDbContext(DbContextOptions<TravisCommsIdentityDbContext> options) : base(options)
        {
        }

        private void AuditShadowProperties(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!entityType.IsOwned())
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TravisCommsIdentityDbContext).Assembly);
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
                    entry.Property(nameof(EntityBase.ModifiedBy)).CurrentValue = "TravisComms\\System";
                    entry.Property(nameof(EntityBase.DateCreated)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.CreatedBy)).CurrentValue = "TravisComms\\System";
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(EntityBase.DateModified)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.ModifiedBy)).CurrentValue = "TravisComms\\System";
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var timeStamp = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified && !e.Metadata.IsOwned()))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(EntityBase.DateModified)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.ModifiedBy)).CurrentValue = "TravisComms\\System";
                    entry.Property(nameof(EntityBase.DateCreated)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.CreatedBy)).CurrentValue = "TravisComms\\System";
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(EntityBase.DateModified)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.ModifiedBy)).CurrentValue = "TravisComms\\System";
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<AccountHolder> AccountHolders { get; set; }
        public DbSet<AccountHolderRole> AccountHoldersRole { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
