using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace UdemyNewMicroservice.Shared.Filters
{
    public class ValidationFilter<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>(); 

            //Fast Fail
            if(validator is null)
            {
                return await next(context);
            }

            var requestModel = context.Arguments.OfType<T>().FirstOrDefault(); //Endpointteki ilk argümen command olanı almak için bunu yaptık.O şekilde tanımlanmış olmalı.

            if (requestModel is null)
            {
                return await next(context);

            }

            var validateResult = await validator.ValidateAsync(requestModel);

            if(!validateResult.IsValid)
            {
                return Results.ValidationProblem(validateResult.ToDictionary());
            }


            return await next(context);
        }
    }
}
