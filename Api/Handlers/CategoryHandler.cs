using Api.Data;
using Core.Handlers;
using Core.Models;
using Core.Requests.Categories;
using Core.Responses;
using System.Data;

namespace Api.Handlers
{
    public class CategoryHandler(AppDbContext context) : ICategoryHandler
    {
        public async Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request)
        {
            try
            {
                var category = new Category()
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Description = request.Description
                };

                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();


                return new CreateCategoryResponse
                {
                    Data = category
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  
                throw new Exception(message: "Failed to create category");
            }
        }

        public async Task<DeleteCategoryResponse> DeleteAsync(DeleteCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAllCategoriesResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GetCategoryByIdResponse> GetByIdAsync(GetCategoryByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateCategoryResponse> UpdateAsync(UpdateCategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
