using Api.Common.Api;
using Core;
using Core.Handlers;
using Core.Models;
using Core.Requests.Categories;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Categories
{
    public class GetAllCategoriesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapGet("/", HandleAsync)
                 .WithName("Categories: Get All")
                 .WithSummary("Get all categories")
                 .WithDescription("Get all categories")
                 .WithOrder(4)
                 .Produces<PagedResponse<List<Category>?>>();


        private static async Task<IResult> HandleAsync(
            ICategoryHandler handler,
            [FromQuery]int PageNumber = Configuration.DefaultPageNumber,
            [FromQuery]int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllCategoriesRequest
            {
                UserId = "danielmoliveira@outlook.com",
                PageNumber = PageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetAllAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);

        }
    }
}
