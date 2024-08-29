using System.Net.Http.Json;
using Core.Handlers;
using Core.Models;
using Core.Requests.Categories;
using Core.Responses;

namespace Web.Handlers;

public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<CreateCategoryResponse?> CreateAsync(CreateCategoryRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/categories", request);
        return await result.Content.ReadFromJsonAsync<CreateCategoryResponse>()
               ?? new CreateCategoryResponse(null, 400, "Failed to create the category.");
    }

    public async Task<DeleteCategoryResponse?> DeleteAsync(DeleteCategoryRequest request)
    {
        var result = await _client.DeleteAsync($"v1/categories/{request.Id}");
        return await result.Content.ReadFromJsonAsync<DeleteCategoryResponse>()
               ?? new DeleteCategoryResponse(null, 400, "Failed to delete the category.");
    }

    public async Task<PagedResponse<List<Category?>>> GetAllAsync(GetAllCategoriesRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Category>>>("v1/categories")
            ?? new PagedResponse<List<Category>>(null, 400, "Failed to retrieve the categories.");

    public async Task<GetCategoryByIdResponse?> GetByIdAsync(GetCategoryByIdRequest request)
        => await _client.GetFromJsonAsync<GetCategoryByIdResponse>($"v1/categories/{request.Id}")
            ?? new GetCategoryByIdResponse(null, 400, "Failed to retrieve the category.");

    public async Task<UpdateCategoryResponse?> UpdateAsync(UpdateCategoryRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/categories/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<UpdateCategoryResponse> ()
               ?? new UpdateCategoryResponse(null, 400, "Failed to update the category.");
    }
}