using TravisComms.Data.Entities.Enums;
using TravisComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Data.Repository
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {            
                SeedServiceProviders(modelBuilder);
                SeedSubscriptionTypes(modelBuilder);
                SeedClientRole(modelBuilder);
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
                    Name = "Nexmo"
                }
            );
        }

        private static void SeedSubscriptionTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionType>().HasData(
                new SubscriptionType
                {
                    SubscriptionTypeId = Guid.NewGuid(),
                    Name = "Trial"
                },
                new SubscriptionType
                {
                    SubscriptionTypeId = Guid.NewGuid(),
                    Name = "Paid"
                }
            );
        }

        private static void SeedClientRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientRole>().HasData(
                new ClientRole
                {
                    ClientRoleId = Guid.NewGuid(),
                    RoleType = RoleType.AdminRoleType
                },
                new ClientRole
                {
                    ClientRoleId = Guid.NewGuid(),
                    RoleType = RoleType.SubRoleType
                }
            );
        }
    }
}
