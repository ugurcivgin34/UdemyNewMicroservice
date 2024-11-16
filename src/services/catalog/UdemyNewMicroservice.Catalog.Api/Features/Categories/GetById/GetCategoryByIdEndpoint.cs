namespace UdemyNewMicroservice.Catalog.Api.Features.Categories.GetById
{
    public record GetAllCategoryQuery(Guid Id) : IRequestByServiceResult<CategoryDto>;

    public class GetCategoryByIdHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.FindAsync(request.Id, cancellationToken);

            if (hasCategory == null)
            {
                return ServiceResult<CategoryDto>.Error("Category not found", $"The category with id({request.Id} was not found", HttpStatusCode.NotFound);
            }

            var categoryAsDto = mapper.Map<CategoryDto>(hasCategory);
            return ServiceResult<CategoryDto>.SuccessAsOk(categoryAsDto);
        }
    }

    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}",
                async (IMediator mediator, Guid id) =>
                    (await mediator.Send(new GetAllCategoryQuery(id))).ToGenericResult())
                .WithName("GetByIdCategory")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}