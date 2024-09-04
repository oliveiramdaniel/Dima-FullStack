using Azure;
using Api.Common.Api;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;

namespace Api.Endpoints.Orders;

public class GetProductBySlugEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{slug}", HandleAsync)
            .WithName("Products: Get By Id")
            .WithSummary("Recover a product")
            .WithDescription("Recover a product")
            .WithOrder(4)
            .Produces<Response<Product?>>();

    private static async Task<IResult> HandleAsync(
        IProductHandler handler,
        string slug)
    {
        var request = new GetProductBySlugRequest
        {
            Slug = slug
        };

        var result = await handler.GetBySlugAsync(request);
        return result.IsSucess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}