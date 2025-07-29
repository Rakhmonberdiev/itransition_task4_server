namespace itransition_task4_server.Endpoints.Users.DTOs
{
    public sealed record GetUsersQuery(
        int Page = 1,
        int PageSize = 10,
        string? Search = null  
        );
}
