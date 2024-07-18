using Api.Common.Api;
using Api.Endpoints;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddSecutiry();
builder.AddDataContext();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();


//var cnnStr = builder.Configuration.
//    GetConnectionString(name: "DefaultConnection") ?? string.Empty;

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(x =>
//{
//    x.CustomSchemaIds(n => n.FullName);
//});

//builder.Services
//    .AddAuthentication(IdentityConstants.ApplicationScheme)
//    .AddIdentityCookies(); //JWT Barrer

//builder.Services.AddDbContext<AppDbContext>(
//    optionsAction:x =>
//    {
//        x.UseSqlServer(Configuration.ConnectionString);
//    });


//builder.Services
//    .AddIdentityCore<User>()
//    .AddRoles<IdentityRole<long>>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddApiEndpoints();

//builder.Services.AddAuthorization();




////Dependecy Injection
//builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
//builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();


if(app.Environment.IsDevelopment())
{
    app.ConfigureDevEnvironment();
}

app.UseSecurity();

//app.UseAuthentication();
//app.UseAuthorization();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.MapGet("/", () => new { Message = "OK" });
app.MapEndpoints();

//app.MapGroup("v1/identity")
//    .WithTags("Identity")
//    .MapIdentityApi<User>();

//app.MapGroup("v1/identity")
//    .WithTags("Identity")
//    .MapPost("/logout", async (
//        SignInManager<User> signInManager) =>
//        {
//            await signInManager.SignOutAsync();
//            return Results.Ok();
//        })
//        .RequireAuthorization();

//app.MapGroup("v1/identity")
//    .WithTags("Identity")
//    .MapGet("/roles", ( ClaimsPrincipal user ) =>
//        {
//            if (user.Identity is null || !user.Identity.IsAuthenticated)
//                return Results.Ok();

//            var identity = user.Identity as ClaimsIdentity;
//            var roles = identity.FindAll(identity.RoleClaimType).Select(c => new
//            {
//                c.Issuer,
//                c.OriginalIssuer,
//                c.Type,
//                c.Value,
//                c.ValueType
//            });

//            return TypedResults.Json(roles);
//        })
//        .RequireAuthorization();


app.UseDeveloperExceptionPage();

app.Run();