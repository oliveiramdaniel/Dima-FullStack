using Api.Common.Api;
using Api.Models;
using Core.Handlers;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Api.Endpoints.Identity
{
    public class LogoutEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/logout", Handle)
            .RequireAuthorization();

        public static Task<IResult> Handle(ClaimsPrincipal user)
        {
            if (user.Identity is null || !user.Identity.IsAuthenticated)
                return Task.FromResult(Results.Unauthorized());

            var identity = user.Identity as ClaimsIdentity;
            var roles = identity.FindAll(identity.RoleClaimType).Select(c => new
            {
                c.Issuer,
                c.OriginalIssuer,
                c.Type,
                c.Value,
                c.ValueType
            });

            return Task.FromResult<IResult>(TypedResults.Json(roles));
        }
    }
}
