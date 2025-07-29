namespace itransition_task4_server.Endpoints.Users.DTOs
{
    public sealed record DeleteUsersRequest(IEnumerable<Guid> Ids);
}
