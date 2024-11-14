using AutoMapper;
using MediatR;
using System.Net;
using UdemyNewMicroservice.Catalog.Api.Features.Categories.Dtos;
using UdemyNewMicroservice.Catalog.Api.Repositories;
using UdemyNewMicroservice.Shared;
using UdemyNewMicroservice.Shared.Extensions;

namespace UdemyNewMicroservice.Catalog.Api.Features.Categories.GetById
{
    public record GetAllCategoryQuery(Guid Id) : IRequest<ServiceResult<CategoryDto>>;

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
                    (await mediator.Send(new GetAllCategoryQuery(id))).ToGenericResult());

            return group;
        }
    }
}