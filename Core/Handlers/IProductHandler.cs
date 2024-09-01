using Core.Models;
using Core.Requests.Orders;
using Core.Responses;

namespace Core.Handlers;

public interface IProductHandler
{
    Task<PagedResponse<List<Product>>> GetAllAsync(GetAllProductsRequest request);
    Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request);
}