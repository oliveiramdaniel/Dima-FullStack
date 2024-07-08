using Api.Common.Api;
using Core.Handlers;
using Core.Requests.Categories;

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
            ICategoryHandler handler,
            UpdateCategoryRequest request,
            long id)
        {
            request.UserId = "String10";
            request.Id = id;

            var result = await handler.UpdateAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result.Data)
                : TypedResults.BadRequest(result.Data);

        }
    }
}
