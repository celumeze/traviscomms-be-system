using TravisComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Repository.Configuration
{
    public class AccountHolderRoleConfig : IEntityTypeConfiguration<AccountHolderRole>
    {
        public void Configure(EntityTypeBuilder<AccountHolderRole> builder)
        {
            builder.HasKey(x => x.AccountHolderRoleId);
            builder.Property(x => x.AccountHolderRoleId).ValueGeneratedOnAdd();
            builder.HasIndex(x => x.RoleType).IsUnique(false);
        }
    }
}
