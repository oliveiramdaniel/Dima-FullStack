using System.Security.Claims;
using Api.Common.Api;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;

namespace Api.Endpoints.Orders;

public class GetOrderByNumberEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{number}", HandleAsync)
            .WithName("Orders: Get By Number")
            .WithSummary("Recover a order by number")
            .WithDescription("Recover a order by number")
            .WithOrder(6)
            .Produces<Response<Order?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IOrderHandler handler,
        string number)
    {
        var request = new GetOrderByNumberRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            Number = number
        };

        var result = await handler.GetByNumberAsync(request);
        return result.IsSucess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}