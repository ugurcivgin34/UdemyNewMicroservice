﻿using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyNewMicroservice.Basket.Api.Const;
using UdemyNewMicroservice.Basket.Api.Dto;
using UdemyNewMicroservice.Shared;

namespace UdemyNewMicroservice.Basket.Api.Features.Baskets.AddBasketItem
{
    public class AddBasketItemCommandHandler(IDistributedCache distributedCache) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            //TODO: change userId
            Guid userId = Guid.NewGuid();
            var cacheKey = string.Format(BasketConst.BasketCacheKey, userId);

            var basketAsString = await distributedCache.GetStringAsync(cacheKey, token: cancellationToken);

            BasketDto? currentBasket;

            var newBasketItem = new BasketItemDto(request.CourseId, request.CourseName, request.ImageUrl, request.CoursePrice, null);

            if (string.IsNullOrEmpty(basketAsString))
            {
                currentBasket = new BasketDto(userId, [newBasketItem]);
            }
            else
            {
                currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);

                var existringBasketItem = currentBasket.BasketItems.FirstOrDefault(x => x.Id == request.CourseId);

                if (existringBasketItem is not null)
                {
                    currentBasket.BasketItems.Remove(existringBasketItem);
                    currentBasket.BasketItems.Add(newBasketItem);
                }
                else
                {
                    currentBasket.BasketItems.Add(newBasketItem);
                }

              
            }
            basketAsString = JsonSerializer.Serialize(currentBasket);

            await distributedCache.SetStringAsync(cacheKey, basketAsString, cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }
    }
}
