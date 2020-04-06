using FlexiComms.Data.Repository.Interfaces;
using FlexiComms.Data.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Repository.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IIdentityRepository, IdentityRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientRoleRepository, ClientRoleRepository>();
        }
    }
}
