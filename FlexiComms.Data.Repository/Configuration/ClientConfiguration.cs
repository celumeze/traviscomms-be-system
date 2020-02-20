using FlexiComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Repository.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.ClientId);
            builder.Property(x=>x.FirstName).HasMaxLength(50).IsRequired().IsUnicode(false);
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired().IsUnicode(false);
            builder.OwnsOne(x => x.SubscriptionType);
        }
    }
}
