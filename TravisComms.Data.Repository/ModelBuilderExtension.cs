using TravisComms.Data.Entities.Enums;
using TravisComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Repository.IdentityModels;

namespace TravisComms.Data.Repository
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {            
                SeedServiceProviders(modelBuilder);
                SeedSubscriptionTypes(modelBuilder);
                SeedAccountHolderRole(modelBuilder);
        }

        private static void SeedServiceProviders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceProvider>().HasData(            
                new ServiceProvider
                {
                    ServiceProviderId = Guid.NewGuid(),
                    Name = "Twilio"
                },
                new ServiceProvider
                {
                    ServiceProviderId = Guid.NewGuid(),
                    Name = "Vonage"
                }
            );
        }

        private static void SeedSubscriptionTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionType>().HasData(
                new SubscriptionType
                {
                    SubscriptionTypeId = Guid.NewGuid(),
                    Name = "Trial",
                    PeriodInDays = 2,
                    Price = 0
                },
                new SubscriptionType
                {
                    SubscriptionTypeId = Guid.NewGuid(),
                    Name = "Paid",
                    PeriodInDays = 31,
                    Price = 45
                }
            );
        }

        private static void SeedAccountHolderRole(ModelBuilder modelBuilder)
        {
            var adminRoleId = Guid.NewGuid();
            var subRoleId = Guid.NewGuid();
            modelBuilder.Entity<AccountHolderRole>().HasData(
                new AccountHolderRole
                {
                    AccountHolderRoleId = adminRoleId,
                    RoleType = RoleType.AdminRoleType
                },
                new AccountHolderRole
                {
                    AccountHolderRoleId = subRoleId,
                    RoleType = RoleType.SubRoleType
                }
            );
            modelBuilder.Entity<MainRole>().HasData(
              new MainRole
              {
                  ClientRoleId = adminRoleId,
                  Name = "Admin"
              },
              new MainRole
              {
                  ClientRoleId = subRoleId,
                  Name = "SubRole"
              }
          );
        }     
    }
}
