using Core.Models;
using Core.Requests.Categories;
using Core.Responses;

namespace Core.Handlers
{
    //Define contract betewenn UI and DB
    public interface ICategoryHandler
    {
        Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request);
        Task<UpdateCategoryResponse> UpdateAsync(UpdateCategoryRequest request);
        Task<DeleteCategoryResponse> DeleteAsync(DeleteCategoryRequest request);
        Task<GetCategoryByIdResponse> GetByIdAsync(GetCategoryByIdRequest request);
        Task<GetAllCategoriesResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request);
    }
}
