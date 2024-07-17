using Api.Data;
using Api.Endpoints;
using Api.Handlers;
using Api.Models;
using Core.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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


builder.Services
    .AddIdentityCore<User>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

//Dependecy Injection
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => new { Message = "OK" });

app.MapEndpoints();
app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseDeveloperExceptionPage();

app.Run();