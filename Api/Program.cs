using Api.Data;
using Api.Endpoints;
using Api.Handlers;
using Core.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.
    GetConnectionString(name: "DefaultConnection") ?? string.Empty;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});

builder.Services
    .AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies(); //JWT Barrer

builder.Services.AddDbContext<AppDbContext>(
    optionsAction:x =>
    {
        x.UseSqlServer(cnnStr);
    });

builder.Services.AddAuthorization();

//Dependecy Injection
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => new { Message = "OK" });

app.MapEndpoints();



//app.MapPost(
//        pattern: "/v1/categories", //UserId
//        handler: async (CreateCategoryRequest request, 
//                    ICategoryHandler handler) 
//            => await handler.CreateAsync(request))
//    .WithName("Categories: Create")
//    .WithSummary("Create a new category")
//    .Produces<CreateCategoryResponse?>(); //Define reponse the endpoint


//app.MapPut(
//        pattern: "/v1/categories/{id}", //UserId
//        handler: async (long id,
//                   UpdateCategoryRequest request,
//                   ICategoryHandler handler)
//                   => {
//                       request.Id = id;
//                       return Results.Json(await handler.UpdateAsync(request));
//                   })
//    .WithName("Categories: Update")
//    .WithSummary("Update a category")
//    .Produces<UpdateCategoryResponse?>();

//app.MapDelete(
//        pattern: "/v1/categories/{id}", //UserId
//        handler: async (long id,
//                    //DeleteCategoryRequest request,
//                    ICategoryHandler handler)
//                    => {
//                        var request = new DeleteCategoryRequest
//                        {
//                            Id = id,
//                            UserId = "string"
//                        };
//                        return Results.Json(await handler.DeleteAsync(request));
//                    })
//    .WithName("Categories: Delete")
//    .WithSummary("Delete a category")
//    .Produces<DeleteCategoryResponse>();

//app.MapGet(
//        pattern: "/v1/categories",
//        handler: async (
//                    ICategoryHandler handler)
//                    => {
//                        var request = new GetAllCategoriesRequest
//                        {
//                            UserId = "string10"
//                        };
//                        return await handler.GetAllAsync(request);
//                    })
//    .WithName("Categories: Get all UserId")
//    .WithSummary("Return all categories from the users")
//    .Produces<PagedResponse<List<Category>?>>();

//app.MapGet(
//        pattern: "/v1/categories/{id}", //UserId
//        handler: async (long id,
//                    //DeleteCategoryRequest request,
//                    ICategoryHandler handler)
//                    => {
//                        var request = new GetCategoryByIdRequest
//                        {
//                            Id = id,
//                            UserId = "string10"
//                        };
//                        return Results.Json(await handler.GetByIdAsync(request));
//                    })
//    .WithName("Categories: Get by Id")
//    .WithSummary("Return a category")
//    .Produces<GetCategoryByIdResponse>();



app.UseDeveloperExceptionPage();

app.Run();