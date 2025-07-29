using itransition_task4_server.Endpoints.Users.DTOs;
using itransition_task4_server.Services.Interfaces;

namespace itransition_task4_server.Endpoints.Users
{
    public static class GetUsersEndpoint
    {
        public  static void MapGetUsersEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("", async ([AsParameters] GetUsersQuery query, IUserService userService) =>
            {
                var result = await userService.GetUsersAsync(query);
                return Results.Ok(result);
            }).RequireAuthorization();
        }
    }
}
