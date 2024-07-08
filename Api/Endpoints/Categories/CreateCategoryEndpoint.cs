using Api.Common.Api;
using Core.Handlers;
using Core.Requests.Categories;

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
            ICategoryHandler handler,
            CreateCategoryRequest request)
        {
            var result = await handler.CreateAsync(request);
            return result.IsSucess 
                ? TypedResults.Created($"/{ result.Data?.Id}", result.Data) 
                : TypedResults.BadRequest(result.Data);
        }
    }
}
