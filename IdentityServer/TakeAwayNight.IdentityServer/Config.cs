// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using static IdentityServer4.Models.IdentityResources;

namespace TakeAwayNight.IdentityServer
{

    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            //Burada yetkilerin dağıtımı hazırlanıyor
            new ApiResource("ResourceCatalog"){ Scopes = { "CatalogFullPermission", "CatalogReadPermission" }},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceDiscount2"){Scopes={"DiscountDeletePermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"}},
            new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName) //Apiresourcelara erişim sağlarken scopeların isimlerine göre çağırmayı sağlıyor.
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full Authority For Catalog Operations"),
            new ApiScope("DiscountFullPermission","Full Authority For Discount Operations"),
            new ApiScope("DiscountDeletePermission","DiscountDelete Authority For Discount Delete"),
            new ApiScope("OrderFullPermission","Full Authority For Order Operations"),
            new ApiScope("CargoFullPermission","Full Authority For Cargo Operations"),
            new ApiScope("BasketFullPermission","Full Authority For Basket Operations"),
            new ApiScope("CommentFullPermission","Full Authority For Comment Operations"),
            new ApiScope("OcelotFullPermission","Full Authority For Ocelot Operations"),
            new ApiScope("MessageFullPermission","Full Authority For Message Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {

                ClientId="TakeAwayVisitorId",
                ClientName="TakeAwayVisitorUser",
                AllowedGrantTypes=GrantTypes.ClientCredentials, // Kullanıcının nasıl erişim sağlayacağını belirtiyoruz
                ClientSecrets={new Secret("takeawaysecret".Sha256())},  //Token alabilmesi için belirlenen key veriliyor.
                AllowedScopes={"CatalogFullPermission","OcelotFullPermission",IdentityServerConstants.LocalApi.ScopeName}, //Yetkileri belirleniyor.
                AccessTokenLifetime= 300
             },

            new Client
            {
                ClientId="TakeAwayAdminId",
                ClientName="TakeAwayAdminUser",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword, //Bu clienta erişim sağlayabilmek için login olmak gerekecek.
                ClientSecrets={new Secret("takeawaysecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "DiscountFullPermission","OrderFullPermission","CargoFullPermission","BasketFullPermission","CommentFullPermission","OcelotFullPermission","MessageFullPermission",IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile},
                AccessTokenLifetime=750,
            }
         };
    }
}