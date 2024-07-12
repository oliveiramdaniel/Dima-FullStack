using Core.Models;
using Core.Requests.Transactions;
using Core.Responses;

namespace Core.Handlers
{
    public interface ITransactionHandler
    {
        Task<Response<Transaction>> CreateAsync(CreateTransactionRequest request);
        Task<Response<Transaction>> UpdateAsync(UpdateTransactionRequest request);
        Task<Response<Transaction>> DeleteAsync(DeleteTransactionRequest request);
        Task<Response<Transaction>> GetByIdAsync(GetTransactionByIdRequest request);
        Task<PagedResponse<List<Transaction>?>> GetByPeriodAync(GetTransactionByPeriodRequest request);
    }
}
