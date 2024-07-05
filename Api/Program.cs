using Api.Data;
using Api.Handlers;
using Core.Handlers;
using Core.Models;
using Core.Requests.Categories;
using Core.Responses;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.
    GetConnectionString(name: "DefaultConnection") ?? string.Empty;


builder.Services.AddDbContext<AppDbContext>(
    optionsAction:x =>
    {
        x.UseSqlServer(cnnStr);
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});

//Dependecy Injection
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost(
        pattern: "/v1/categories", //UserId
        handler: async (CreateCategoryRequest request, 
                    ICategoryHandler handler) 
            => await handler.CreateAsync(request))
    .WithName("Categories: Create")
    .WithSummary("Create a new category")
    .Produces<CreateCategoryResponse?>(); //Define reponse the endpoint


app.MapPut(
        pattern: "/v1/categories/{id}", //UserId
        handler: async (long id,
                   UpdateCategoryRequest request,
                   ICategoryHandler handler)
                   => {
                       request.Id = id;
                       await handler.UpdateAsync(request);
                   })
    .WithName("Categories: Update")
    .WithSummary("Update a category")
    .Produces<Response<Category?>>();



app.MapDelete(
        pattern: "/v1/categories/{id}", //UserId
        handler: async (long id,
                    //DeleteCategoryRequest request,
                    ICategoryHandler handler)
                    => {
                        var request = new DeleteCategoryRequest
                        {
                            Id = id
                        };
                        await handler.DeleteAsync(request);
                    })
    .WithName("Categories: Delete")
    .WithSummary("Delete a category")
    .Produces<DeleteCategoryResponse>();









app.Run();