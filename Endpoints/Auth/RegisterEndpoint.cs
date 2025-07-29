using FluentValidation;
using itransition_task4_server.Data.Entities;
using itransition_task4_server.Endpoints.Auth.DTOs;
using Microsoft.AspNetCore.Identity;

namespace itransition_task4_server.Endpoints.Auth
{
    public static class RegisterEndpoint
    {
        public static void MapRegisterEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("regiser", async (RegisterRequest request,
                SignInManager<AppUser> signInManager,
                UserManager<AppUser> userManager, 
                IValidator<RegisterRequest> validator) =>
            {
                var validationResult = await validator.ValidateAsync(request);
                if (!validationResult.IsValid) return Results.ValidationProblem(validationResult.ToDictionary());
                var user = new AppUser
                {
                    UserName = request.Email,
                    Email = request.Email,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, request.Password);
                await signInManager.SignInAsync(user, isPersistent: true);
                return Results.Ok(new AuthResponse(user.Email));
            }).WithName("Register");
      
        }
    }
}
