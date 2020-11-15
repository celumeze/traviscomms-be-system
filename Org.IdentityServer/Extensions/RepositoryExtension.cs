using Microsoft.Extensions.DependencyInjection;
using Org.IdentityServer.Interfaces;
using Org.IdentityServer.Repository;
using Org.IdentityServer.UnitOfWork;
using System;

namespace Org.IdentityServer.Extensions
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
