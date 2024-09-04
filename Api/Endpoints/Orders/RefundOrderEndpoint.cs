using System.Security.Claims;
using Api.Common.Api;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;

namespace Api.Endpoints.Orders;

public class RefundOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{id}/refund", HandleAsync)
            .WithName("Orders: Refund an order")
            .WithSummary("Refund an order")
            .WithDescription("Refund an order")
            .WithOrder(4)
            .Produces<Response<Order?>>();

    private static async Task<IResult> HandleAsync(
        IOrderHandler handler,
        long id,
        ClaimsPrincipal user)
    {
        var request = new RefundOrderRequest()
        {
            Id = id,
            UserId = user.Identity!.Name ?? string.Empty
        };

        var result = await handler.RefundAsync(request);
        return result.IsSucess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}