using Api.Data;
using Core.Common.Extensions;
using Core.Handlers;
using Core.Models;
using Core.Requests.Transactions;
using Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers
{
    public class TransactionHandler(AppDbContext context) : ITransactionHandler
    {
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            try
            {
                var transaction = new Transaction
                {
                    UserId = request.UserId,
                    CategoryId = request.CategoryId,
                    CreatedAt = DateTime.UtcNow,
                    Amount = request.Amount,
                    PaidOrReceivedAt = request.PaidOrReceiveAt,
                    Title = request.Title,
                    Type = request.Type
                };

                await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 201, "Transaction create sucessfully!");
            }
            catch
            {

                return new Response<Transaction?>(null, 500, "Not was possible to create transaction");
            }
        }

        public async Task<Response<Transaction>> DeleteAsync(DeleteTransactionRequest request)
        {
            try
            {
                var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transaction is null)
                    new Response<Transaction?>(null, 404, "Transaction not found!");

                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction);
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Not possible found your transaction");
            }
        }

        public async Task<Response<Transaction>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            try
            {
                var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id);

                return transaction is null
                    ? new Response<Transaction?>(null, 404, "Transaction not found!")
                    : new Response<Transaction?>(transaction);

            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Not possible found your transaction");
            }
        }

        public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAync(GetTransactionByPeriodRequest request)
        {
            try
            {
                //If StardDate and EndDate are not informed, the current date will be used
                request.StartDate ??= DateTime.Now.GetFirstDay();
                request.EndDate ??= DateTime.Now.GetLastDay();

            }
            catch
            {
                return new PagedResponse<List<Transaction>?>(null, 500, "Not possible found your transaction");
            }

            try
            {
                var query = context.Transactions.AsNoTracking().
                        Where(x => x.CreatedAt >= request.StartDate && x.CreatedAt <= request.EndDate && x.UserId == request.UserId)
                        .OrderBy(x => x.CreatedAt);

                var results = query.ToList();

                foreach (var result in results)
                {
                    var logMessage = $"Transaction ID: {result.Id}, User ID: {result.UserId}, Created At: {result.CreatedAt}";
                    Console.WriteLine(logMessage);
                }


                var transactions = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Transaction?>>(transactions, count, request.PageNumber, request.PageSize);
            }
            catch
            {

                return new PagedResponse<List<Transaction>?>(null, 500, "Not possible found your transaction"); 
            }
        }

        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            try
            {
                var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transaction is null)
                    new Response<Transaction?>(null, 404, "Transaction not found!");

                transaction.CategoryId = request.CategoryId;
                transaction.Amount = request.Amount;
                transaction.Title = request.Title;
                transaction.Type = request.Type;
                transaction.PaidOrReceivedAt = request.PaidOrReceiveAt;

                context.Transactions.Update(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction);
            }
            catch 
            {
                return new Response<Transaction?>(null, 500, "Not possible found your transaction");
            }
        }
    }
}
