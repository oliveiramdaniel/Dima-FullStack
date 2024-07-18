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

var app = builder.Build();


if(app.Environment.IsDevelopment())
{
    app.ConfigureDevEnvironment();
}

app.UseSecurity();

app.MapEndpoints();

//app.UseDeveloperExceptionPage();

app.Run();