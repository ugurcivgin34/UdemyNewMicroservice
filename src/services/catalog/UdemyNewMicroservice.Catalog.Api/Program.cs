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

//Eðer ki aþaðýdaki kod yerine await app.AddSeedDataExt() metodunu kullansaydýk, seed data oluþana kadar uygulamanýn ayaða kalkmasý seed data nýn bitmesine kadar sürecekti. , bu yüzden bu yapýyý kullanarak beklemesini istemediðimiz için arka planda ayaða kalksýn, var olan thread bloklanmadan arka planda bu süreç gerçekleþsin.Uygulama hýzlý þekilde ayaða kalksýn.Hata verirse versin , vermezse baþarýlý þekilde mesaj yazarak bitirsin iþlemini
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