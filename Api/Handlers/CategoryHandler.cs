using Api.Data;
using Azure;
using Core.Handlers;
using Core.Models;
using Core.Requests.Categories;
using Core.Responses;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace Api.Handlers
{
    public class CategoryHandler(AppDbContext context) : ICategoryHandler
    {
        public async Task<CreateCategoryResponse?> CreateAsync(CreateCategoryRequest request)
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


                return new CreateCategoryResponse(category, 201, "Category created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  
                return new CreateCategoryResponse(null, 500, "Failed to create category");
            }
        }

        public async Task<DeleteCategoryResponse?> DeleteAsync(DeleteCategoryRequest request)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category is null)
                    return new DeleteCategoryResponse(null, 404, "Category not found");

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return new DeleteCategoryResponse(category, 200, message: "Category Delete sucessfully");
            }
            catch (Exception)
            {
                return new DeleteCategoryResponse(null, 500, "Not possible to delete category");
            }
        }

        public async Task<PagedResponse<List<Category?>>> GetAllAsync(GetAllCategoriesRequest request)
        {
            try
            {
                var query = context.Categories.AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderBy(x => x.Title);

                var allCategories = await query.ToListAsync();

                //Pagination
                var categories = await query.
                    Skip((request.PageNumber-1) * request.PageSize).
                    Take(request.PageSize).ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Category?>>(categories, count, request.PageNumber, request.PageSize); 
            }
            catch
            {
                return new PagedResponse<List<Category>>(null, 500, "Not was possible select the category!");
            }
        }

        public async Task<GetCategoryByIdResponse?> GetByIdAsync(GetCategoryByIdRequest request)
        {
            try
            {
                
                var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

               return category is null 
                    ? new GetCategoryByIdResponse(null, 404, "Category not found") 
                    : new GetCategoryByIdResponse(category);

            }
            catch (Exception)
            {
                return new GetCategoryByIdResponse(null, 500, "Not possible found the category by Id");
            }
        }

        public async Task<UpdateCategoryResponse?> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category is null)
                    return new UpdateCategoryResponse(null, 404, "Category not found");

                category.Title = request.Title;
                category.Description = request.Description;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                //Console.WriteLine($"Response: {JsonConvert.SerializeObject(response)}"); // Log de depuração

                return new UpdateCategoryResponse(category, 200, "Category updated successfully");

            }
            catch (Exception)
            {
                return new UpdateCategoryResponse(null, 500, "Not possible update category");
            }
        }
    }
}
