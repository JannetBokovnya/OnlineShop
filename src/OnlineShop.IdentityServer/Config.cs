// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace OnlineShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("OnlineShop.Api"), //взаимодействие услуги между собой
                new ApiScope("OnlineShop.Web"), //будут заходить пользователи через web  интерфейс
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // клиент для взаимодействия услуг между собой
                new Client
                {
                    ClientId = "test.client",
                    ClientName = "Test client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = 
                    { 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "OnlineShop.Api",
                        "OnlineShop.Web"
                    }
                },

                // внешний клиент, который будет заходить в приложение при помощи логина и пароля
                new Client
                {
                    ClientId = "external",
                    ClientName="External client",
                    //ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    RequireClientSecret=false,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "OnlineShop.Web"
                    }

                    //RedirectUris = { "https://localhost:44300/signin-oidc" },
                    //FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    //PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    //AllowOfflineAccess = true,
                    //AllowedScopes = { "openid", "profile", "scope2" }
                },
            };
    }
}