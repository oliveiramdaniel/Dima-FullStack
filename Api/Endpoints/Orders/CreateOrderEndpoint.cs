using System.Security.Claims;
using Api.Common.Api;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;

namespace Api.Endpoints.Orders;

public class CreateOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Orders: Create a new order")
            .WithSummary("Create a new order")
            .WithDescription("Create a new order")
            .WithOrder(1)
            .Produces<Response<Order?>>();

    private static async Task<IResult> HandleAsync(
        IOrderHandler handler,
        CreateOrderRequest request,
        ClaimsPrincipal user)
    {
        request.UserId = user.Identity!.Name ?? string.Empty;

        var result = await handler.CreateAsync(request);
        return result.IsSucess
            ? TypedResults.Created($"v1/orders/{result.Data?.Number}", result)
            : TypedResults.BadRequest(result);
    }
}