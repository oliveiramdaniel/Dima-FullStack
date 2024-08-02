using Core.Handlers;
using Core.Requests;
using Core.Requests.Account;
using Core.Responses;
using System.Net.Http.Json;

namespace Web.Handlers
{
    public class AccountHandler(IHttpClientFactory httpClientFactory) : IAccountHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<string>> LoginAsync(LoginRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/identity/login?useCookies=true", request);
            return result.IsSuccessStatusCode
                ? new Response<string>("Login Sucessfully!", 200, "Login Sucessfully!")
                : new Response<string>("", 400, "Invalid Login");
        }

        public async Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> RegisterAsync(RegisterRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/identity/register", request);
            return result.IsSuccessStatusCode
                ? new Response<string>("Login Sucessfully!", 200, "Login Sucessfully!")
                : new Response<string>("", 400, "Invalid Login");
            
        }
    }
}
