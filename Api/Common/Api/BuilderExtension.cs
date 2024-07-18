using Core;

namespace Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void AddConfiguration (this WebApplicationBuilder builder)
        {
            Configuration.ConnectionString = builder.Configuration
                .GetConnectionString(name: "DefaultConnection") ?? string.Empty;

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
        }
    }
}
