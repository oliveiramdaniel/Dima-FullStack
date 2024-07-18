using Api.Common.Api;
using Core.Handlers;
using Core.Requests.Categories;
using System.Security.Claims;

namespace Api.Endpoints.Categories
{
    public class CreateCategoryEndpoint : IEndpoint
    {
        static void IEndpoint.Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                .WithName("Categories: Create")
                .WithSummary("Create a new category")
                .WithDescription("Create a new category")
                .WithOrder(1)
                .Produces<CreateCategoryResponse?>();

        public static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICategoryHandler handler,
            CreateCategoryRequest request)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);
            return result.IsSucess 
                ? TypedResults.Created($"/{ result.Data?.Id}", result) 
                : TypedResults.BadRequest(result);
        }
    }
}
