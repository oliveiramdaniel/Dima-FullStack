using Api.Common.Api;
using Core.Handlers;
using Core.Requests.Categories;

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
            ICategoryHandler handler,
            long id)
        {
            var request = new GetCategoryByIdRequest
            {
                UserId = "String10",
                Id = id
            };

            var result = await handler.GetByIdAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result.Data)
                : TypedResults.BadRequest(result.Data);

        }
    }
}
