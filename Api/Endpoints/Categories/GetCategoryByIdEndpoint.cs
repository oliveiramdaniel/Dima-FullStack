using Api.Common.Api;
using Api.Models;
using Core.Handlers;
using Core.Requests.Categories;
using System.Security.Claims;

namespace Api.Endpoints.Categories
{
    public class GetCategoryByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapGet("/{id}", HandleAsync)
                 .WithName("Categories: Get By Id")
                 .WithSummary("Get a category")
                 .WithDescription("Get a category")
                 .WithOrder(4)
                 .Produces<GetCategoryByIdResponse?>();
      

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICategoryHandler handler,
            long id)
        {
            var request = new GetCategoryByIdRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.GetByIdAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);

        }
    }
}
