using itransition_task4_server.Data.Entities;
using itransition_task4_server.Endpoints.Auth.DTOs;
using Microsoft.AspNetCore.Identity;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace itransition_task4_server.Endpoints.Auth
{
    public static class RegisterEndpoint
    {
        public static void MapRegisterEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("regiser", async (RegisterRequest request,
                SignInManager<AppUser> signInManager,
                UserManager<AppUser> userManager
                ) =>
            {
                var user = new AppUser
                {
                    FullName = request.FullName,
                    UserName = request.Email,
                    Email = request.Email,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: true);
                    return Results.Ok(new AuthResponse(user.Email));
                }
                return Results.BadRequest(new
                {
                    message = "An unexpected error occurred. Please try again later."
                });

            }).WithName("Register").AddFluentValidationAutoValidation();
      
        }
    }
}
