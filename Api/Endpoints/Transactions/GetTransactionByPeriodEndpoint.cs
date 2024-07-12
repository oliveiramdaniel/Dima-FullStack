using Api.Common.Api;
using Core;
using Core.Handlers;
using Core.Models;
using Core.Requests.Categories;
using Core.Requests.Transactions;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints.Transactions
{
    public class GetTransactionByPeriodEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapGet("/", HandleAsync)
                 .WithName("Transactions: Get All")
                 .WithSummary("Get all transactions")
                 .WithDescription("Get all transactions")
                 .WithOrder(4)
                 .Produces<PagedResponse<List<Transaction>?>>();


        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int PageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetTransactionByPeriodRequest
            {
                UserId = "danielmoliveira@outlook.com",
                PageNumber = PageNumber,
                PageSize = pageSize,
                StartDate = startDate,
                EndDate = endDate
            };


            var result = await handler.GetByPeriodAync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);

        }
    }
}
