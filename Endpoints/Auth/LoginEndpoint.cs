using itransition_task4_server.Data.Entities;
using itransition_task4_server.Endpoints.Auth.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace itransition_task4_server.Endpoints.Auth
{
    public static class LoginEndpoint
    {
        public static void MapLoginEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("login", async (
                LoginRequest request,
                SignInManager<AppUser> signInManager,
                UserManager<AppUser> userManager
                ) =>
            {
                var user = await userManager.FindByEmailAsync(request.Email);
                if (user == null || user.IsBlocked)
                    return Results.Unauthorized();
                var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (!result.Succeeded)
                    return Results.Unauthorized();
                await userManager.Users.Where(u => u.Id == user.Id)
                    .ExecuteUpdateAsync(u => u.SetProperty(x => x.LastLoginAt, DateTime.UtcNow));
                await signInManager.SignInAsync(user, request.isPersistent);
                return Results.Ok(new AuthResponse(user.Email!));
            }).WithName("Login").AddFluentValidationAutoValidation();
        }
    }
}
