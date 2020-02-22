using FlexiComms.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiComms.Data.Repository
{
    public static class ModelBuilderExtension
    {
        public static void Seed(FlexiCommsDbContext context)
        {
            
                SeedServiceProviders(context);
                SeedSubscriptionTypes(context);
                context.SaveChanges();            
        }

        private static void SeedServiceProviders(FlexiCommsDbContext context)
        {
            var serviceProviders = new List<ServiceProvider>
            {
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
            };
            if (!context.ServiceProviders.ToList().Any())  context.AddRange(serviceProviders);            
        }

        private static void SeedSubscriptionTypes(FlexiCommsDbContext context)
        {
            var subscriptionTypes = new List<SubscriptionType>
            {
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
            };
            if (!context.SubscriptionTypes.ToList().Any()) context.AddRange(subscriptionTypes);
        }
    }
}
