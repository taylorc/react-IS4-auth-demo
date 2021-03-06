﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer2
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()                
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("doughnutapi", "Doughnut API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // React client
                new Client
                {
                    ClientId = "wewantdoughnuts",
                    ClientName = "We Want Doughnuts",
                    ClientUri = "http://localhost:3000",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    
                    RequireClientSecret = false,

                    RedirectUris =
                    {                        
                        "http://localhost:3000/signin-oidc",                        
                    },

                    PostLogoutRedirectUris = { "http://localhost:3000/signout-oidc" },
                    AllowedCorsOrigins = { "http://localhost:3000" },

                    AllowedScopes = { "openid", "profile", "doughnutapi" },
                    AllowAccessTokensViaBrowser = true
                }
            };
        }
    }
}