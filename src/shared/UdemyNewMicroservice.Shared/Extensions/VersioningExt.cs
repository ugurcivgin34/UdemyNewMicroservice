using Asp.Versioning; // ASP.NET API sürümleme işlemleri için kullanılan kütüphane.
using Asp.Versioning.Builder; // API sürümleme yapılandırma işlemlerine yönelik yardımcı sınıflar.
using Microsoft.AspNetCore.Builder; // ASP.NET uygulama yapılandırma işlemleri için kullanılan kütüphane.
using Microsoft.Extensions.DependencyInjection; // Dependency Injection işlemleri için kullanılan kütüphane.

namespace UdemyNewMicroservice.Shared.Extensions
{
    // Sınıf, API sürümleme ile ilgili genişletme metotlarını içerir.
    public static class VersioningExt
    {
        // IServiceCollection için bir genişletme metodu.
        public static IServiceCollection AddVersioningExt(this IServiceCollection services)
        {
            // API sürümleme işlemlerini ekler ve yapılandırır.
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0); // Varsayılan API sürümü 1.0 olarak ayarlanır.
                options.AssumeDefaultVersionWhenUnspecified = true; // Sürüm belirtilmemişse varsayılan sürüm kullanılır.
                options.ReportApiVersions = true; // Kullanılabilir API sürümleri istemcilere raporlanır.
                options.ApiVersionReader = new UrlSegmentApiVersionReader(); // API sürümleri URL segmentlerinden okunur.

                // Alternatif API sürümleme okuma yöntemleri, yorum satırında verilmiştir.
                // Örneğin: Header, Query String ya da URL Segmentleri birleştirilebilir.
                // options.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader(),
                //    new QueryStringApiVersionReader(), new UrlSegmentApiVersionReader());

                // Swagger dokümantasyonu için API sürümleme ayarları bu yapılandırma ile çalışır.
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V"; // API gruplama formatı "v1" gibi ayarlanır.
                options.SubstituteApiVersionInUrl = true; // API sürümleri URL'ye otomatik olarak eklenir.
            });

            return services; // Hizmet koleksiyonunu döndürür.
        }

        // Minimal API'ler için API sürümleme yapılandırması yapılır.
        public static ApiVersionSet AddVersionSetExt(this WebApplication app)
        {
            // Yeni bir API sürüm seti oluşturulur ve yapılandırılır.
            var apiVersionSet = app.NewApiVersionSet()
                .HasApiVersion(new ApiVersion(1, 0)) // Sürüm 1.0 tanımlanır.
                .HasApiVersion(new ApiVersion(1, 2)) // Ek bir sürüm olan 1.2 tanımlanır.
                .HasApiVersion(new ApiVersion(1, 0)) // Aynı sürüm tekrar tanımlanabilir (örnek için).
                .ReportApiVersions() // API sürüm bilgileri istemcilere raporlanır.
                .Build(); // Sürüm seti tamamlanır ve döndürülmek üzere hazırlanır.

            return apiVersionSet; // API sürüm setini döndürür.
        }
    }
}
