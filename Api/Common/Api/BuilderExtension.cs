﻿using Api.Data;
using Api.Handlers;
using Api.Models;
using Core;
using Core.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AddConfiguration (this WebApplicationBuilder builder)
        {
            Configuration.ConnectionString = builder.Configuration
                .GetConnectionString(name: "DefaultConnection") ?? string.Empty;

            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

            Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        }

        public static void AddDocumentation (this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n => n.FullName);
            });
        }

        public static void AddSecutiry (this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies(); //JWT Barrer

            builder.Services.AddAuthorization();
        }

        public static void AddDataContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(
                optionsAction: x =>
                {
                    x.UseSqlServer(Configuration.ConnectionString);
                });

            builder.Services
                .AddIdentityCore<User>()
                .AddRoles<IdentityRole<long>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddApiEndpoints();
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            //Dependecy Injection
            builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
            builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
                options.AddPolicy(
                    ApiConfiguration.CorsPolicyName,
                    policy => policy
                    .WithOrigins([
                        Configuration.BackendUrl,
                        Configuration.FrontendUrl
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));
        }
    }
}
