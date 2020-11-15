using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.IdentityServer.Models;
using System;

namespace Org.IdentityServer.EfConfig
{
    public class SubscriptionTypeConfig : IEntityTypeConfiguration<SubscriptionType>
    {
        public void Configure(EntityTypeBuilder<SubscriptionType> builder)
        {
            builder.HasKey(x => x.SubscriptionTypeId);
            builder.Property(x => x.SubscriptionTypeId).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired().IsUnicode(false);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.HasIndex(x => x.Name).IsUnique(false);
        }
    }
}
