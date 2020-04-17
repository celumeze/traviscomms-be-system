using TravisComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Repository.Configuration
{
    public class ClientRoleConfiguration : IEntityTypeConfiguration<ClientRole>
    {
        public void Configure(EntityTypeBuilder<ClientRole> builder)
        {
            builder.HasKey(x => x.ClientRoleId);
            builder.Property(x => x.ClientRoleId).ValueGeneratedOnAdd();
            builder.HasIndex(x => x.RoleType).IsUnique(false);
        }
    }
}
