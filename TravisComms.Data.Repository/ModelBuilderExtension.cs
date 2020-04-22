using TravisComms.Data.Entities.Enums;
using TravisComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Repository.IdentityModels;
using IdentityServer4.EntityFramework.Entities;
using System.Globalization;

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
                    ServiceProviderId = Guid.Parse("3F6625AE-9FCA-4975-99C2-2CA362E55825"),
                    Name = "Twilio",
                    DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                    CreatedBy = "TravisComms\\System"
                },
                new ServiceProvider
                {
                    ServiceProviderId = Guid.Parse("8B07F619-CFF8-4795-9A22-CBCA1493CF02"),
                    Name = "Vonage",
                    DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                    CreatedBy = "TravisComms\\System"
                },
                 new ServiceProvider
                 {
                     ServiceProviderId = Guid.Parse("873C3886-CE7D-42BD-B48C-05F41B36212F"),
                     Name = "Whatsapp",
                     DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                     CreatedBy = "TravisComms\\System"
                 }

            );   
        }

        private static void SeedSubscriptionTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionType>().HasData(
                new SubscriptionType
                {
                    SubscriptionTypeId = Guid.Parse("360CF2ED-3705-4248-A4A4-B15C8A3077DE"),
                    Name = "Trial",
                    PeriodInDays = 2,
                    Price = 0,
                    DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                    CreatedBy = "TravisComms\\System"
                },
                new SubscriptionType
                {
                    SubscriptionTypeId = Guid.Parse("55404FE5-0FF5-4CAE-9B30-69263BAF424F"),
                    Name = "Paid",
                    PeriodInDays = 31,
                    Price = 45,
                    DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                    CreatedBy = "TravisComms\\System"
                }
            );
        }

        private static void SeedAccountHolderRole(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<AccountHolderRole>().HasData(
                new AccountHolderRole
                {
                    AccountHolderRoleId = Guid.Parse("CB0A792B-BF55-46B5-8795-10C43006BE92"),
                    RoleType = RoleType.AdminRoleType,
                    DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                    CreatedBy = "TravisComms\\System"
                },
                new AccountHolderRole
                {
                    AccountHolderRoleId = Guid.Parse("37C9973F-9436-4F49-89EF-1E7B2D2398E4"),
                    RoleType = RoleType.SubRoleType,
                    DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                    CreatedBy = "TravisComms\\System"
                }
            );
            modelBuilder.Entity<MainRole>().HasData(
              new MainRole
              {
                  Id = "833583c3-1d58-4b95-baad-05b35acdd6a3",
                  ConcurrencyStamp = "ef51e739-98e5-4455-9ae0-061ebfdda460",
                  NormalizedName = "ADMIN",
                  AccountHolderRoleId = Guid.Parse("CB0A792B-BF55-46B5-8795-10C43006BE92"),
                  Name = "Admin",
                  DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                  CreatedBy = "TravisComms\\System"
              },
              new MainRole
              {
                  Id = "ebd48401-7db4-43e5-ae50-211fa5d87ac8",
                  ConcurrencyStamp = "be15a41d-2400-45cf-bb50-9c6394d9ef25",
                  NormalizedName = "SUBROLE",
                  AccountHolderRoleId = Guid.Parse("37C9973F-9436-4F49-89EF-1E7B2D2398E4"),
                  Name = "SubRole",
                  DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                  CreatedBy = "TravisComms\\System"
              }
          );
        }
    }
}
