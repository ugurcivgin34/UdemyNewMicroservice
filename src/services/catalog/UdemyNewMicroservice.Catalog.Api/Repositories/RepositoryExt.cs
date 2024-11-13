using MongoDB.Driver;
using UdemyNewMicroservice.Catalog.Api.Options;

namespace UdemyNewMicroservice.Catalog.Api.Repositories
{
    public static class RepositoryExt
    {
        public static IServiceCollection AddDataabaseServiceExt(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var options = sp.GetRequiredService<MongoOption>();
                return new MongoClient(options.ConnectionString);

            });

            services.AddScoped(sp =>
            {
                var mongoClient = sp.GetRequiredService<IMongoClient>();
                var options = sp.GetRequiredService<MongoOption>();

                return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
            });

            return services;
        }
    }
}
