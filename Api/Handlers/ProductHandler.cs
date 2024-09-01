using Api.Data;
using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Api.Handlers;

public class ProductHandler(AppDbContext context) : IProductHandler
{
    public async Task<PagedResponse<List<Product>>> GetAllAsync(GetAllProductsRequest request)
    {
        try
        {
            var query = context
                .Products
                .AsNoTracking()
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.Title);

            var products = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Product>>(
                products,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Product>>(null, 500, "Could not retrieve the product");
        }
    }

    public async Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request)
    {
        try
        {
            var product = await context
                .Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Slug == request.Slug && x.IsActive == true);

            return product is null
                ? new Response<Product?>(null, 404, "Product not found")
                : new Response<Product?>(product);
        }
        catch
        {
            return new Response<Product?>(null, 500, "Could not retrieve the product");
        }
    }
}