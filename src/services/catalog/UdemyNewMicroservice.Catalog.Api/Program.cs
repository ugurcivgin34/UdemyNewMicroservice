using UdemyNewMicroservice.Catalog.Api;
using UdemyNewMicroservice.Catalog.Api.Features.Categories;
using UdemyNewMicroservice.Catalog.Api.Features.Courses;
using UdemyNewMicroservice.Catalog.Api.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionExt();
builder.Services.AddDataabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));
builder.Services.AddVersioningExt();
var app = builder.Build();

//E�er ki a�a��daki kod yerine await app.AddSeedDataExt() metodunu kullansayd�k, seed data olu�ana kadar uygulaman�n aya�a kalkmas� seed data n�n bitmesine kadar s�recekti. , bu y�zden bu yap�y� kullanarak beklemesini istemedi�imiz i�in arka planda aya�a kalks�n, var olan thread bloklanmadan arka planda bu s�re� ger�ekle�sin.Uygulama h�zl� �ekilde aya�a kalks�n.Hata verirse versin , vermezse ba�ar�l� �ekilde mesaj yazarak bitirsin i�lemini
app.AddSeedDataExt().ContinueWith(x =>
{
    Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed data has been saved successfully");
});
app.AddCategoryGroupEndpointExt(app.AddVersionSetExt());
app.AddCourseGroupEndpointExt(app.AddVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();