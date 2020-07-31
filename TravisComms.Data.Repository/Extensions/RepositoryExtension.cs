using TravisComms.Data.Repository.Interfaces;
using TravisComms.Data.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TravisComms.Data.Repository.UoW;
using Microsoft.AspNetCore.Identity;
using TravisComms.Data.Repository.IdentityModels;

namespace TravisComms.Data.Repository.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IIdentityRepository, IdentityRepository>();
            services.AddScoped<IAccountHolderRepository, AccountHolderRepository>();
            services.AddScoped<IAccountHolderRoleRepository, AccountHolderRoleRepository>();
            services.AddScoped<ISubscriptionTypeRepository, SubscriptionTypeRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IRegistrationUoW, RegistrationUoW>();
        }
    }
}
