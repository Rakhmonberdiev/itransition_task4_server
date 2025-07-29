namespace itransition_task4_server.Endpoints.Auth.DTOs
{
    public sealed record LoginRequest(string Email, string Password,bool isPersistent);
}
