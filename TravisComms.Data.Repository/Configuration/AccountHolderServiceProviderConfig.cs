using TravisComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Repository.Configuration
{
    public class AccountHolderServiceProviderConfig : IEntityTypeConfiguration<AccountHolderServiceProvider>
    {
        public void Configure(EntityTypeBuilder<AccountHolderServiceProvider> builder)
        {
            builder.HasKey(x => x.AccountHolderServiceProviderId);
            builder.Property(x => x.AccountSid).HasMaxLength(100).IsRequired().IsUnicode(false);
            builder.Property(x => x.AuthToken).HasMaxLength(100).IsRequired().IsUnicode(false);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired().IsUnicode(false);
            builder.HasOne(x => x.ServiceProvider)
                    .WithMany(x => x.AccountHolderServiceProviders)
                    .HasForeignKey(x => x.ServiceProviderId)
                    .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
