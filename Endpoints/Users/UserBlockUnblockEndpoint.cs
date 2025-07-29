using FluentValidation;
using itransition_task4_server.Endpoints.Users.DTOs;
using itransition_task4_server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace itransition_task4_server.Endpoints.Users
{
    public static class UserBlockUnblockEndpoint
    {
        public static void MapUserBlockUnblock(this IEndpointRouteBuilder app)
        {
            app.MapPost("update-block", async (
                [FromBody] UpdateBlockUsersRequest req,
                IValidator<UpdateBlockUsersRequest> validator,
                IUserService userService) =>
            {
                var validationResult = await validator.ValidateAsync(req);
                if (!validationResult.IsValid)
                    return Results.ValidationProblem(validationResult.ToDictionary());
                if (req.Block.Value)
                    await userService.BlockUsersAsync(req.Ids);
                else
                    await userService.UnBlockUsersAsync(req.Ids);
                return Results.NoContent();
            });
        }
    }
}
