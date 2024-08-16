using Core.Handlers;
using Core.Requests;
using Core.Requests.Account;
using Core.Responses;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text;

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
            var emptyContent = new StringContent("{}", Encoding.UTF8,mediaType:"application/json" );
            var response = await _client.PostAsync("v1/identity/logout", emptyContent);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Logout successful.");
            }
            else
            {
                Debug.WriteLine($"Logout failed with status code: {response.StatusCode}");
            }
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/identity/register", request);
            return result.IsSuccessStatusCode
                ? new Response<string>("Register Sucessfully!", 201, "Register Sucessfully!")
                : new Response<string>("", 400, "Invalid Register");
            
        }
    }
}
