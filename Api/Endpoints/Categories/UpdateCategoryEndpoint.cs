using Api.Common.Api;
using Api.Models;
using Core.Handlers;
using Core.Requests.Categories;
using System.Security.Claims;

namespace Api.Endpoints.Categories
{
    public class UpdateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapPut("/{id}", HandleAsync)
                 .WithName("Categories: Update")
                 .WithSummary("Update a category")
                 .WithDescription("Update a category")
                 .WithOrder(2)
                 .Produces<UpdateCategoryResponse?>();
      

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICategoryHandler handler,
            UpdateCategoryRequest request,
            long id)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;

            var result = await handler.UpdateAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);

        }
    }
}
