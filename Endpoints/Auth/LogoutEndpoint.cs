using Microsoft.AspNetCore.Authentication;

namespace itransition_task4_server.Endpoints.Auth
{
    public static class LogoutEndpoint
    {
        public static void MapLogoutEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("logout", async (HttpContext context) =>
            {
                await context.SignOutAsync();
                return Results.NoContent();
            }).RequireAuthorization()
            .WithName("Logout");
        }
    }
}
