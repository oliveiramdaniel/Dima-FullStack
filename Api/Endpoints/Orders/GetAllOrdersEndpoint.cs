using System.Security.Claims;
using Api.Common.Api;
using Core;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Orders;

public class GetAllOrdersEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Orders: Get All")
            .WithSummary("Recover all orders")
            .WithDescription("Recover all orders")
            .WithOrder(5)
            .Produces<PagedResponse<List<Order>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IOrderHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllOrdersRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };

        var result = await handler.GetAllAsync(request);
        return result.IsSucess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}