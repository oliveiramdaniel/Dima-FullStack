using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;
using System.Net.Http.Json;

namespace Web.Handlers
{
    public class ProductHandler(IHttpClientFactory httpClientFactory) : IProductHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<PagedResponse<List<Product>>> GetAllAsync(GetAllProductsRequest request)
         => await _client.GetFromJsonAsync<PagedResponse<List<Product>>>("v1/products")
            ?? new PagedResponse<List<Product>>(null, 400, "Failed to retrieve the products.");

        public async Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request)
         => await _client.GetFromJsonAsync<Response<Product?>>($"v1/products/{request.Slug}")
            ?? new Response<Product?>(null, 400, "Failed to retrieve the product.");
    }
}
