using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.IdentityServer.Models;
using System;

namespace Org.IdentityServer.EfConfig
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.CompanyId);
            builder.Property(x => x.CompanyId).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(70).IsRequired().IsUnicode(false);
            builder.HasIndex(x => x.Name).IsUnique(false);
        }
    }
}
