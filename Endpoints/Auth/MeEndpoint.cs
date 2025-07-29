using itransition_task4_server.Endpoints.Auth.DTOs;
using System.Security.Claims;

namespace itransition_task4_server.Endpoints.Auth
{
    public static class MeEndpoint
    {
        public static void MapMeEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("me", (ClaimsPrincipal user) =>
            {
                var email = user.FindFirst(ClaimTypes.Email)?.Value;
                if (email is null)
                    return Results.Unauthorized();
                return Results.Ok(new AuthResponse(email));
            }).RequireAuthorization()
            .WithName("Me");
        }
    }
}
