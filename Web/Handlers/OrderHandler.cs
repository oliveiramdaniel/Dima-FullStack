using Core.Handlers;
using Core.Models;
using Core.Requests.Orders;
using Core.Responses;
using System.Net.Http.Json;

namespace Web.Handlers
{
    public class OrderHandler(IHttpClientFactory httpClientFactory) : IOrderHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Order?>> CancelAsync(CancelOrderRequest request)
        {
            var result = await _client.PostAsJsonAsync($"v1/orders/{request.Id}/cancel", request);
            return await result.Content.ReadFromJsonAsync<Response<Order?>>()
                ?? new Response<Order?>(null, 400, "Failed to cancel the order.");
        }
         

        public async Task<Response<Order?>> CreateAsync(CreateOrderRequest request)
        {
            var result = await _client.PostAsJsonAsync($"v1/orders/", request);
            return await result.Content.ReadFromJsonAsync<Response<Order?>>()
                ?? new Response<Order?>(null, 400, "Failed to create the order.");
        }

        public async Task<Response<Order?>> PayAsync(PayOrderRequest request)
        {
            var result = await _client.PostAsJsonAsync($"v1/orders/{request.Id}/pay", request);
            return await result.Content.ReadFromJsonAsync<Response<Order?>>()
                   ?? new Response<Order?>(null, 400, "Failed to pay the order");
        }

        public async Task<Response<Order?>> RefundAsync(RefundOrderRequest request)
        {
            var result = await _client.PostAsJsonAsync($"v1/orders/{request.Id}/refund", request);
            return await result.Content.ReadFromJsonAsync<Response<Order?>>()
                   ?? new Response<Order?>(null, 400, "Failed to refund the order");
        }

        public async Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Order>?>>("v1/orders")
           ?? new PagedResponse<List<Order>?>(null, 400, "Unable to retrieve orders");

        public async Task<Response<Order?>> GetByNumberAsync(GetOrderByNumberRequest request)
        => await _client.GetFromJsonAsync<Response<Order?>>($"v1/orders/{request.Number}")
           ?? new Response<Order?>(null, 400, "Unable to retrieve orders");
    }
}
