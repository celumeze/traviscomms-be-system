using FlexiComms.Api.Dto;
using FlexiComms.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiComms.Api.Helpers
{
    public static class SubscriptionTypeExtension
    {        
        public static async Task GetSelectedSubscriptionIdAsync(this SubscriptionTypeDto subscriptionType, ISubscriptionTypeRepository subscriptionTypeRepository)
        {
            var id = await subscriptionTypeRepository.GetSubscriptionIdByNameAsync(subscriptionType.Name);
            subscriptionType.SubscriptionTypeId = id;
        }
    }
}
