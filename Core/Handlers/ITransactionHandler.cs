using Core.Requests;
using Core.Requests.Transactions;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Handlers
{
    public interface ITransactionHandler
    {
        Task<Response<Transaction>> CreateAsync(CreateTransactionRequest request);
        Task<Response<Transaction>> UpdateAsync(UpdateTransactionRequest request);
        Task<Response<Transaction>> DeleteAsync(DeleteTransactionRequest request);
        Task<Response<Transaction>> GetByIdAsync(GetTransactionByIdRequest request);
        Task<PagedResponse<List<Transaction>?>> GetByPeriodRequest(GetTransactionByPeriodRequest request);
    }
}
