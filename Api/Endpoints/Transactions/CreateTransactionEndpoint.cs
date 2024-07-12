using Api.Common.Api;
using Core.Handlers;
using Core.Models;
using Core.Requests.Categories;
using Core.Requests.Transactions;
using Core.Responses;

namespace Api.Endpoints.Transactions
{
    public class CreateTransactionEndpoint : IEndpoint
    {
        static void IEndpoint.Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                .WithName("Transactions: Create")
                .WithSummary("Create a new transaction")
                .WithDescription("Create a new transaction")
                .WithOrder(1)
                .Produces<Response<Transaction?>>();

        public static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            CreateTransactionRequest request)
        {
            request.UserId = "danielmoliveira@outlook.com";
            var result = await handler.CreateAsync(request);
            return result.IsSucess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
