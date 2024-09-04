using Api.Data;
using Core.Enums;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class OrderHandler(AppDbContext context) : IOrderHandler
{
    public async Task<Response<Order?>> CancelAsync(CancelOrderRequest request)
    {
        Order? order;
        try
        {
            order = await context
                .Orders
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (order is null)
                return new Response<Order?>(null, 404, "Order not found");
        }
        catch
        {
            return new Response<Order?>(null, 500, "Failed to obtain order");
        }

        switch (order.Status)
        {
            case EOrderStatus.Canceled:
                return new Response<Order?>(order, 400, "The order has already been canceled!");

            case EOrderStatus.Paid:
                return new Response<Order?>(order, 400, "A paid order cannot be canceled!");

            case EOrderStatus.Refunded:
                return new Response<Order?>(order, 400, "A refunded order cannot be canceled!");

            case EOrderStatus.WaitingPayment:
                break;

            default:
                return new Response<Order?>(order, 400, "Order with invalid status!");
        }

        order.Status = EOrderStatus.Canceled;
        order.UpdatedAt = DateTime.Now;

        try
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<Order?>(order, 500, "Could not update your order");
        }

        return new Response<Order?>(order, 200, $"Order {order.Number} updated!");
    }

    public async Task<Response<Order?>> CreateAsync(CreateOrderRequest request)
    {
        Product? product;
        try
        {
            product = await context
                .Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.ProductId && x.IsActive == true);

            if (product is null)
                return new Response<Order?>(null, 404, "Product not found or inactive");

            context.Attach(product);
        }
        catch
        {
            return new Response<Order?>(null, 500, "Failed to verify product");
        }

        Voucher? voucher = null;
        try
        {
            if (request.VoucherId is not null)
            {
                voucher = await context
                    .Vouchers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.VoucherId && x.IsActive == true);

                if (voucher is null)
                    return new Response<Order?>(null, 404, "Voucher not found or inactive");

                if (voucher.IsActive == false)
                    return new Response<Order?>(null, 404, "This voucher has already been used");

                voucher.IsActive = false;

                // context.Attach(voucher);
                context.Vouchers.Update(voucher);
            }
        }
        catch
        {
            return new Response<Order?>(null, 500, "Failed to check voucher");
        }

        var order = new Order
        {
            UserId = request.UserId,
            Product = product,
            ProductId = request.ProductId,
            Voucher = voucher,
            VoucherId = request.VoucherId
        };

        try
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<Order?>(null, 500, "Could not register your order");
        }

        return new Response<Order?>(order, 201, $"Order {order.Number} successfully registered!");
    }

    public async Task<Response<Order?>> PayAsync(PayOrderRequest request)
    {
        Order? order;
        try
        {
            order = await context
                .Orders
                .Include(x => x.Product)
                .Include(x => x.Voucher)
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
                //.FirstOrDefaultAsync(x => x.Number == request.OrderNumber && x.UserId == request.UserId);


            if (order is null)
                return new Response<Order?>(null, 404, $"Order {request.Id} not found");
        }
        catch
        {
            return new Response<Order?>(null, 500, "Failed to query order");
        }

        switch (order.Status)
        {
            case EOrderStatus.Canceled:
                return new Response<Order?>(order, 400, "The order is canceled!");

            case EOrderStatus.Paid:
                return new Response<Order?>(order, 400, "The order has already been paid for");

            case EOrderStatus.Refunded:
                return new Response<Order?>(order, 400, "A refunded order cannot be canceled");

            case EOrderStatus.WaitingPayment:
                break;

            default:
                return new Response<Order?>(order, 400, "Invalid order status");
        }

        try
        {
            //var getTransactionByOrderNumberRequest = new GetTransactionByOrderNumberRequest
            //{
            //    Number = order.Number,
            //};
            //var result = await stripeHandler.GetTransactionsByOrderNumberAsync(getTransactionByOrderNumberRequest);

            //if (result.IsSuccess == false)
            //    return new Response<Order?>(null, 500, "Could not find the payment for your order!");

            //if (result.Data is null)
            //    return new Response<Order?>(null, 500, "Could not find the payment for your order!");

            //if (result.Data.Any(item => item.Refunded))
            //    return new Response<Order?>(null, 500, "This order has already been refunded and cannot be paid!");

            //if (!result.Data.Any(item => item.Paid))
            //    return new Response<Order?>(null, 500, "This order has not been paid yet!");

            //request.ExternalReference = result.Data[0].Id;
        }
        catch
        {
            return new Response<Order?>(null, 500, "Could not find the payment for your order!");
        }

        order.Status = EOrderStatus.Paid;
        order.ExternalReference = request.ExternalReference;
        order.UpdatedAt = DateTime.Now;

        try
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<Order?>(order, 500, "Could not process the payment for your order!");
        }

        return new Response<Order?>(order, 200, $"Order {order.Number} successfully paid!");
    }

    public async Task<Response<Order?>> RefundAsync(RefundOrderRequest request)
    {
        Order? order;
        try
        {
            order = await context
                .Orders
                .Include(x => x.Product)
                .Include(x => x.Voucher)
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (order is null)
                return new Response<Order?>(null, 404, "Order not found");
        }
        catch
        {
            return new Response<Order?>(null, 500, "Failed to query your order");
        }

        switch (order.Status)
        {
            case EOrderStatus.Canceled:
                return new Response<Order?>(order, 400, "The order is canceled!");

            case EOrderStatus.WaitingPayment:
                return new Response<Order?>(order, 400, "The order has not been paid yet");

            case EOrderStatus.Refunded:
                return new Response<Order?>(order, 400, "The order has already been refunded");

            case EOrderStatus.Paid:
                break;

            default:
                return new Response<Order?>(order, 400, "Invalid order status");
        }

        order.Status = EOrderStatus.Refunded;
        order.UpdatedAt = DateTime.Now;

        try
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<Order?>(order, 500, "Could not refund your order");
        }

        return new Response<Order?>(order, 200, $"Order {order.Number} successfully refunded!");
    }

    public async Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request)
    {
        try
        {
            var query = context
                .Orders
                .AsNoTracking()
                .Include(x => x.Product)
                .Include(x => x.Voucher)
                .Where(x => x.UserId == request.UserId)
                .OrderBy(x => x.CreatedAt);

            var orders = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Order>?>(
                orders,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Order>?>(null, 500, "Could not query the orders");
        }
    }

    public async Task<Response<Order?>> GetByNumberAsync(GetOrderByNumberRequest request)
    {
        try
        {
            var order = await context
                .Orders
                .AsNoTracking()
                .Include(x => x.Product)
                .Include(x => x.Voucher)
                .FirstOrDefaultAsync(x => x.Number == request.Number && x.UserId == request.UserId);

            return order is null
                ? new Response<Order?>(null, 404, "Order not found")
                : new Response<Order?>(order);
        }
        catch
        {
            return new Response<Order?>(null, 500, "Could not retrieve the order");
        }
    }
}