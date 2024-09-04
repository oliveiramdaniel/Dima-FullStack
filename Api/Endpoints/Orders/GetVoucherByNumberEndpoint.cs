using Api.Common.Api;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;

namespace Api.Endpoints.Orders;

public class GetVoucherByNumberEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{number}", HandleAsync)
            .WithName("Voucher: Get By Number")
            .WithSummary("Recover a voucher")
            .WithDescription("Recover a voucher")
            .WithOrder(4)
            .Produces<Response<Voucher?>>();

    private static async Task<IResult> HandleAsync(
        IVoucherHandler handler,
        string number)
    {
        var request = new GetVoucherByNumberRequest
        {
            Number = number
        };

        var result = await handler.GetByNumberAsync(request);
        return result.IsSucess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}