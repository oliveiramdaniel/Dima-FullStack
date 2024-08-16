using Api.Common.Api;
using Api.Models;
using Core.Handlers;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Api.Endpoints.Identity
{
    public class LogoutEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app
                .MapPost("/logout", HandleAsync)
                .RequireAuthorization();

        private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }
    }
}
