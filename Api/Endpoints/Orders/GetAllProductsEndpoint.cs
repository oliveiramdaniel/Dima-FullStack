using Api.Common.Api;
using Core;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Orders;

public class GetAllProductsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Products: Get All")
            .WithSummary("Recover all products")
            .WithDescription("Recover all products")
            .WithOrder(1)
            .Produces<PagedResponse<List<Product>?>>();

    private static async Task<IResult> HandleAsync(
        IProductHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllProductsRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
        };
        var result = await handler.GetAllAsync(request);
        return result.IsSucess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result.Data);
    }
}