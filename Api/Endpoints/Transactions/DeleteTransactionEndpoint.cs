using Api.Common.Api;
using Core.Handlers;
using Core.Models;
using Core.Requests.Categories;
using Core.Requests.Transactions;
using Core.Responses;

namespace Api.Endpoints.Transactions
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapDelete("/{id}", HandleAsync)
                 .WithName("Transactions: Delete")
                 .WithSummary("Delete a transaction")
                 .WithDescription("Delete a transaction")
                 .WithOrder(3)
                 .Produces<Response<Transaction?>>();


        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            long id)
        {
            var request = new DeleteTransactionRequest
            {
                UserId = "danielmoliveira@outlook.com",
                Id = id
            };

            var result = await handler.DeleteAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);

        }
    }
}
