using itransition_task4_server.Endpoints.Users.DTOs;
using itransition_task4_server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace itransition_task4_server.Endpoints.Users
{
    public static class UserBlockUnblockEndpoint
    {
        public static void MapUserBlockUnblock(this IEndpointRouteBuilder app)
        {
            app.MapPost("update-block", async (
                [FromBody] UpdateBlockUsersRequest req,
                IUserService userService) =>
            {
                if (req.Block.Value)
                    await userService.BlockUsersAsync(req.Ids);
                else
                    await userService.UnBlockUsersAsync(req.Ids);
                return Results.NoContent();
            }).RequireAuthorization().AddFluentValidationAutoValidation();
        }
    }
}
