namespace itransition_task4_server.Endpoints.Users.DTOs
{
    public sealed record UserDTO(
        Guid Id,
        string FullName,
        string Email,
        DateTime? LastLoginAt,
        bool IsBlocked
        );
    
}
