using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.IdentityServer.Helpers
{
    public static class InitConfigDb
    {
        public static void InitializeClients(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                foreach(var client in Config.Clients)
                {
                    context.Clients.Add(client.ToEntity());                  
                }
            }
            else
            {
                Config.Clients.ToList().ForEach(cfg =>
                {
                    var isClientExists = context.Clients.Any(ctx => ctx.ClientName == cfg.ClientName);
                    if (!isClientExists)
                    {
                        context.Clients.Add(cfg.ToEntity());
                    }
                });
                context.SaveChanges();
            }
        }

        public static void InitializeIdentityResources(ConfigurationDbContext context)
        {
            if (!context.IdentityResources.Any())
            {
                foreach(var idresource in Config.Ids)
                {
                    context.IdentityResources.Add(idresource.ToEntity());
                }
            }
            else
            {
                Config.Ids.ToList().ForEach(cfg =>
                {
                    var isIdResourcesExist = context.IdentityResources.Any(ctx => ctx.Name == cfg.Name);
                    if (!isIdResourcesExist)
                    {
                        context.IdentityResources.Add(cfg.ToEntity());
                    }
                });
            }
        }

        public static void InitializeApiResources(ConfigurationDbContext context)
        {
            if (!context.ApiResources.Any())
            {
                foreach(var apiresource in Config.Apis)
                {
                    context.ApiResources.Add(apiresource.ToEntity());
                }
            }
            else
            {
                Config.Apis.ToList().ForEach(cfg =>
                {
                    var isApiResourcesExists = context.ApiResources.Any(ctx => ctx.Name == cfg.Name);
                    if (!isApiResourcesExists)
                    {
                        context.ApiResources.Add(cfg.ToEntity());
                    }
                });
            }
        }
    }
}
