﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") {Scopes={"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount") {Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder") {Scopes={"OrderFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes={"CatalogReadPermission"}
            },
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes={"CatalogReadPermission", "CatalogFullPermission" }
            },
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes={
                    "CatalogReadPermission",
                    "CatalogFullPermission",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime = 600
            }
        };


        //public static IEnumerable<Client> Clients =>
        //    new Client[]
        //    {
        //        // m2m client credentials flow client
        //        new Client
        //        {
        //            ClientId = "m2m.client",
        //            ClientName = "Client Credentials Client",

        //            AllowedGrantTypes = GrantTypes.ClientCredentials,
        //            ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

        //            AllowedScopes = { "scope1" }
        //        },

        //        // interactive client using code flow + pkce
        //        new Client
        //        {
        //            ClientId = "interactive",
        //            ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

        //            AllowedGrantTypes = GrantTypes.Code,

        //            RedirectUris = { "https://localhost:44300/signin-oidc" },
        //            FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
        //            PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

        //            AllowOfflineAccess = true,
        //            AllowedScopes = { "openid", "profile", "scope2" }
        //        },
        //    };
    }
}