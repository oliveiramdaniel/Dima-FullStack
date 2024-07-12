using Api.Common.Api;
using Core.Handlers;
using Core.Models;
using Core.Requests.Categories;
using Core.Requests.Transactions;
using Core.Responses;

namespace Api.Endpoints.Transactions
{
    public class GetTransactionByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapGet("/{id}", HandleAsync)
                 .WithName("Transactions: Get By Id")
                 .WithSummary("Get a transaction")
                 .WithDescription("Get a transaction")
                 .WithOrder(4)
                 .Produces<Response<Transaction?>>();


        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            long id)
        {
            var request = new GetTransactionByIdRequest
            {
                Id = id
            };

            var result = await handler.GetByIdAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);

        }
    }
}
