using Api.Common.Api;
using Core.Handlers;
using Core.Models;
using Core.Requests.Transactions;
using Core.Responses;
using System.Security.Claims;

namespace Api.Endpoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapPut("/{id}", HandleAsync)
                 .WithName("Transactions: Update")
                 .WithSummary("Update a transaction")
                 .WithDescription("Update a transaction")
                 .WithOrder(2)
                 .Produces<Response<Transaction?>>();


        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ITransactionHandler handler,
            UpdateTransactionRequest request,
            long id)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;

            var result = await handler.UpdateAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);

        }
    }
}
