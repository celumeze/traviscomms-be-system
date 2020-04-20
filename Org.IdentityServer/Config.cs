// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Org.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("subscriptiontype", "the account holder subscription type", new List<string> { "subscriptiontype" } ),
                new IdentityResource("accountholderrole", "the account holder role", new List<string> { "accountholderrole" } ),
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
                     
                    AccessTokenType = AccessTokenType.Reference,
                    AccessTokenLifetime = 120,
                    ClientId = "traviscomms-desktop",
                    ClientName = "TravisComms",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireConsent = false,
                    RedirectUris = { "http://localhost:4200/signin-callback", "http://4200/assets"},
                    PostLogoutRedirectUris = { "http://localhost:4200/signout-callback"},
                    AllowedCorsOrigins = { "http://localhost:4200"},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "subscriptiontype",
                        "accountholderrole"
                    }
                }
            };
        
    }
}