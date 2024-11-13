﻿using Microsoft.Extensions.DependencyInjection;

namespace UdemyNewMicroservice.Shared.Extensions
{
    public static class CommonServiceExt
    {
        public static IServiceCollection AddCommonServiceExt(this IServiceCollection services,Type assembly) 
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(x=>x.RegisterServicesFromAssemblyContaining(assembly));

            return services;
        }
    }
}
