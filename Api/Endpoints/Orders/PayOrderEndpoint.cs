using System.Security.Claims;
using Api.Common.Api;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;

namespace Api.Endpoints.Orders;

public class PayOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{number}/pay", HandleAsync)
            .WithName("Orders: Pay an order")
            .WithSummary("Pay for an order")
            .WithDescription("Pay for an order")
            .WithOrder(3)
            .Produces<Response<Order?>>();

    private static async Task<IResult> HandleAsync(
        IOrderHandler handler,
        //string number,
        long id,
        PayOrderRequest request,
        ClaimsPrincipal user)
    {
        //request.OrderNumber = number;
        request.Id = id;
        request.UserId = user.Identity!.Name ?? string.Empty;

        var result = await handler.PayAsync(request);
        return result.IsSucess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}