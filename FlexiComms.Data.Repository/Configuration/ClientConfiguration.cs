﻿using FlexiComms.Data.Entities.Models;
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
            builder.Property(x => x.ClientId).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired().IsUnicode(false);
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired().IsUnicode(false);
            builder.HasOne(x => x.SubscriptionType)
                   .WithMany(x => x.Clients)
                   .HasForeignKey(x => x.SubscriptionTypeId)
                   .OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(x => x.ClientRole)
                   .WithMany(x => x.Clients)
                   .HasForeignKey(x => x.ClientRoleId)
                   .OnDelete(DeleteBehavior.ClientCascade);
            builder.HasIndex(x => x.SubscriptionTypeId).IsUnique(false);                   
        }
    }
}
