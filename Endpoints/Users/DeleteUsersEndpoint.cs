using itransition_task4_server.Endpoints.Users.DTOs;
using itransition_task4_server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace itransition_task4_server.Endpoints.Users
{
    public static class DeleteUsersEndpoint
    {
        public static void MapDeleteUsersEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapDelete("delete", async (
                [FromBody] DeleteUsersRequest req,
                IUserService userService) =>
            {
                await userService.DeleteUsersAsync(req.Ids);
                return Results.NoContent();
            }).RequireAuthorization();
        }
    }
}
