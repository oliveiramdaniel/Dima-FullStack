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
        handler: (CreateCategoryRequest request, 
                    ICategoryHandler handler) 
            => handler.CreateAsync(request))
    .WithName("Categories: Create")
    .WithSummary("Create a new category")
    .Produces<Response<Category>>();

app.Run();