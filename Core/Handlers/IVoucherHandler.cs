using Core.Models;
using Core.Requests.Orders;
using Core.Responses;

namespace Dima.Core.Handlers;

public interface IVoucherHandler
{
    Task<Response<Voucher?>> GetByNumberAsync(GetVoucherByNumberRequest request);
}