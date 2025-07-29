using FluentValidation;
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
                IValidator<DeleteUsersRequest> validator,
                IUserService userService) =>
            {
                var validationResult = await validator.ValidateAsync(req);
                if (!validationResult.IsValid)
                    return Results.ValidationProblem(validationResult.ToDictionary());
                await userService.DeleteUsersAsync(req.Ids);
                return Results.NoContent();
            }).RequireAuthorization();
        }
    }
}
