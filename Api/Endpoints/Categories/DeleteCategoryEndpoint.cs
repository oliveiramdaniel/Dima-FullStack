using Api.Common.Api;
using Core.Handlers;
using Core.Requests.Categories;

namespace Api.Endpoints.Categories
{
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapPut("/{id}", HandleAsync)
                 .WithName("Categories: Delete")
                 .WithSummary("Delete a category")
                 .WithDescription("Delete a category")
                 .WithOrder(3)
                 .Produces<DeleteCategoryResponse?>();
      

        private static async Task<IResult> HandleAsync(
            ICategoryHandler handler,
            long id)
        {
            var request = new DeleteCategoryRequest
            {
                UserId = "String10",
                Id = id
            };

            var result = await handler.DeleteAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result.Data)
                : TypedResults.BadRequest(result.Data);

        }
    }
}
