using Api.Common.Api;
using Api.Endpoints.Categories;
using Api.Endpoints.Identity;
using Api.Endpoints.Transactions;
using Api.Models;

namespace Api.Endpoints
{
    public static class Endpoint
    {
        //Extension Method
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");
            
            endpoints.WithTags("Helth Check").MapGet("/", () => new { Message = "OK" });

            endpoints.MapGroup("v1/categories")
                .WithTags("Categories")
                .RequireAuthorization()
                .MapEndpoint<CreateCategoryEndpoint>()
                .MapEndpoint<UpdateCategoryEndpoint>()
                .MapEndpoint<GetCategoryByIdEndpoint>()
                .MapEndpoint<GetAllCategoriesEndpoint>()
                .MapEndpoint<DeleteCategoryEndpoint>();


            endpoints.MapGroup("v1/transactions")
                .WithTags("Transactions")
                .RequireAuthorization()
                .MapEndpoint<CreateTransactionEndpoint>()
                .MapEndpoint<UpdateTransactionEndpoint>()
                .MapEndpoint<GetTransactionByIdEndpoint>()
                .MapEndpoint<GetTransactionByPeriodEndpoint>()
                .MapEndpoint<DeleteTransactionEndpoint>();


            endpoints.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapIdentityApi<User>();

            endpoints.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapEndpoint<LogoutEndpoint>()
                .MapEndpoint<GetRolesEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) 
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
