using Api.Data;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers;

public class VoucherHandler(AppDbContext context) : IVoucherHandler
{
    public async Task<Response<Voucher?>> GetByNumberAsync(GetVoucherByNumberRequest request)
    {
        try
        {
            var voucher = await context
                .Vouchers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Number == request.Number && x.IsActive == true);

            return voucher is null
                ? new Response<Voucher?>(null, 404, "Voucher not found")
                : new Response<Voucher?>(voucher);
        }
        catch
        {
            return new Response<Voucher?>(null, 500, "Could not retrieve the voucher");
        }
    }
}