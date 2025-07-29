namespace itransition_task4_server.Endpoints.Users.DTOs
{
    public sealed record class UpdateBlockUsersRequest(
        IEnumerable<Guid> Ids,
        bool? Block
        );
}
