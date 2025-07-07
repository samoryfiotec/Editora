using FluentValidation;
using Microsoft.AspNetCore.Http;

public class ValidationFilter<T> : IEndpointFilter
{
    private readonly IValidator<T> _validator;

    public ValidationFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var entity = context.Arguments.OfType<T>().FirstOrDefault();
        if (entity is not null)
        {
            var result = await _validator.ValidateAsync(entity);
            if (!result.IsValid)
                return Results.ValidationProblem(result.ToDictionary());
        }
        return await next(context);
    }
}