using Api.Common.Api;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Api.Endpoints.Identity
{
    public class GetRolesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/roles", HandleAsync)
            .RequireAuthorization();

        public static async Task<IResult> HandleAsync(ClaimsPrincipal user)
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }
    }
}
