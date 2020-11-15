using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.IdentityServer.Models;

namespace Org.IdentityServer.EfConfig
{
    public class AccountHolderConfig : IEntityTypeConfiguration<AccountHolder>
    {
        public void Configure(EntityTypeBuilder<AccountHolder> builder)
        {
            builder.HasKey(x => x.AccountHolderId);
            builder.Property(x => x.AccountHolderId).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired().IsUnicode(false);
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired().IsUnicode(false);
            builder.HasOne(x => x.SubscriptionType)
                   .WithMany(x => x.AccountHolders)
                   .HasForeignKey(x => x.SubscriptionTypeId)
                   .OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(x => x.AccountHolderRole)
                   .WithMany(x => x.AccountHolders)
                   .HasForeignKey(x => x.AccountHolderRoleId)
                   .OnDelete(DeleteBehavior.ClientCascade);
            builder.HasIndex(x => x.SubscriptionTypeId).IsUnique(false);                   
        }
    }
}
