using TravisComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Repository.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
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
