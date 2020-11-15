using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.IdentityServer.Models;
using System;

namespace Org.IdentityServer.EfConfig
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
