using Api.Common.Api;
using Core.Handlers;
using Core.Requests.Categories;
using System.Security.Claims;

namespace Api.Endpoints.Categories
{
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapDelete("/{id}", HandleAsync)
                 .WithName("Categories: Delete")
                 .WithSummary("Delete a category")
                 .WithDescription("Delete a category")
                 .WithOrder(3)
                 .Produces<DeleteCategoryResponse?>();
      

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICategoryHandler handler,
            long id)
        {
            var request = new DeleteCategoryRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.DeleteAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);

        }
    }
}
