﻿using Asp.Versioning.Builder;
using UdemyNewMicroservice.Basket.Api.Features.Baskets.AddBasketItem;

namespace UdemyNewMicroservice.Basket.Api
{
    public static class BasketEndpointExt
    {
        public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
                .WithApiVersionSet(apiVersionSet)
                .AddBasketItemGroupItemEndpoint();
        }
    }
}
