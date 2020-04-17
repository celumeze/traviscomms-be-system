using TravisComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Repository.Configuration
{
    public class ClientServiceProviderConfiguration : IEntityTypeConfiguration<ClientServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ClientServiceProvider> builder)
        {
            builder.HasKey(x => x.ClientServiceProviderId);
            builder.Property(x => x.AccountSid).HasMaxLength(100).IsRequired().IsUnicode(false);
            builder.Property(x => x.AuthToken).HasMaxLength(100).IsRequired().IsUnicode(false);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired().IsUnicode(false);
            builder.HasOne(x => x.ServiceProvider)
                    .WithMany(x => x.ClientServiceProviders)
                    .HasForeignKey(x => x.ServiceProviderId)
                    .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
