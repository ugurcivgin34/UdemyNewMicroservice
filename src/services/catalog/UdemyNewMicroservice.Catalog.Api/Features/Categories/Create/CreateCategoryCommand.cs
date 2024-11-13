using MediatR;
using UdemyNewMicroservice.Shared;

namespace UdemyNewMicroservice.Catalog.Api.Features.Categories.Create
{

    //Diğer hali aşağıdaki gibidir...Record tanımlamamızın sebebi oluşturulduktan sonra propertlerinin değiştirilmemesinin istemememiz
    public record CreateCategoryCommand(string Name) :IRequest<ServiceResult<CreateCategoryResponse>>;

    //public record X
    //{
    //    public string Name { get; init; }
    //    public X(string name)
    //    {
    //        Name = name;

    //        var x = new X("kalem");
    //        x.Name = "Silgi";
    //    }
    //}
}
