using FlexiComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiComms.Data.Repository.Repository
{
    public class RepositoryBase
    {
        private readonly FlexiCommsSqlDbContext _flexiCommsSqlDbContext;

        public RepositoryBase(FlexiCommsSqlDbContext flexiCommsSqlDbContext)
        {
            _flexiCommsSqlDbContext = flexiCommsSqlDbContext;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var timeStamp = DateTime.Now;
            foreach (var entry in _flexiCommsSqlDbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified && !e.Metadata.IsOwned()))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(EntityBase.DateModified)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.ModifiedBy)).CurrentValue = "FlexiComms\\System";
                    entry.Property(nameof(EntityBase.DateCreated)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.CreatedBy)).CurrentValue = "FlexiComms\\System";
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(EntityBase.DateModified)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.ModifiedBy)).CurrentValue = "FlexiComms\\System";
                }
            }
            return _flexiCommsSqlDbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            var timeStamp = DateTime.Now;
            foreach (var entry in _flexiCommsSqlDbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified && !e.Metadata.IsOwned()))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(EntityBase.DateModified)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.ModifiedBy)).CurrentValue = "FlexiComms\\System";
                    entry.Property(nameof(EntityBase.DateCreated)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.CreatedBy)).CurrentValue = "FlexiComms\\System";
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(EntityBase.DateModified)).CurrentValue = timeStamp;
                    entry.Property(nameof(EntityBase.ModifiedBy)).CurrentValue = "FlexiComms\\System";
                }
            }
            return _flexiCommsSqlDbContext.SaveChanges();
        }
    }
}
