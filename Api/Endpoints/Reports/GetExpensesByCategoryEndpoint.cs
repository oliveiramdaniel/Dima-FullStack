using System.Security.Claims;
using Api.Common.Api;
using Core.Handlers;
using Core.Models.Reports;
using Core.Requests.Reports;
using Core.Responses;

namespace Api.Endpoints.Reports;

public class GetExpensesByCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/expenses", HandleAsync)
            .Produces<Response<List<ExpensesByCategory>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IReportHandler handler)
    {
        var request = new GetExpensesByCategoryRequest
        {
            UserId = user.Identity?.Name ?? string.Empty
        };
        var result = await handler.GetExpensesByCategoryReportAsync(request);
        return result.IsSucess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}