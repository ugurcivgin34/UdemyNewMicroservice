using Microsoft.Extensions.Options;

namespace UdemyNewMicroservice.Catalog.Api.Options
{
    public static class OptionExt
    {
        public static IServiceCollection AddOptionExt(this IServiceCollection services)
        {
            services.AddOptions<MongoOption>().BindConfiguration(nameof(MongoOption)).ValidateDataAnnotations().ValidateOnStart();

            //Option konfigürasyon dosyalarını tip güvenli şekilde okumay ayarar
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoOption>>().Value);
            return services;
        }
    }
}
