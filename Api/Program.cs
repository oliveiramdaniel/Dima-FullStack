using Api.Common.Api;
using Api.Data;
using Api.Endpoints;
using Api.Handlers;
using Api.Models;
using Core;
using Core.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();

//var cnnStr = builder.Configuration.
//    GetConnectionString(name: "DefaultConnection") ?? string.Empty;

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
        x.UseSqlServer(Configuration.ConnectionString);
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

app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapPost("/logout", async (
        SignInManager<User> signInManager) =>
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        })
        .RequireAuthorization();

app.MapGroup("v1/identity")
    .WithTags("Identity")
    .MapGet("/roles", ( ClaimsPrincipal user ) =>
        {
            if (user.Identity is null || !user.Identity.IsAuthenticated)
                return Results.Ok();

            var identity = user.Identity as ClaimsIdentity;
            var roles = identity.FindAll(identity.RoleClaimType).Select(c => new
            {
                c.Issuer,
                c.OriginalIssuer,
                c.Type,
                c.Value,
                c.ValueType
            });

            return TypedResults.Json(roles);
        })
        .RequireAuthorization();


app.UseDeveloperExceptionPage();

app.Run();