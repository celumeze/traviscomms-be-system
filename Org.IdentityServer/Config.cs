// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Org.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[] 
            { 
              new ApiResource("traviscomms-api", "TravisComms API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {

                    AccessTokenLifetime = 120,
                    ClientId = "traviscomms-desktop",
                    ClientName = "TravisComms",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    RedirectUris = { "http://localhost:8100/signin-callback", "http://8100/assets"},
                    PostLogoutRedirectUris = { "http://localhost:8100/signout-callback"},
                    AllowedCorsOrigins = { "http://localhost:8100"},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "traviscomms-api"
                    }
                },
                new Client
                {

                    AccessTokenLifetime = 120,
                    ClientId = "traviscomms-webui",
                    ClientName = "TravisComms",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    RedirectUris = { "http://localhost:4200/signin-callback", "http://4200/assets"},
                    PostLogoutRedirectUris = { "http://localhost:4200/signout-callback"},
                    AllowedCorsOrigins = { "http://localhost:4200"},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "traviscomms-api"
                    }
                   
                }
            };
    }
}