namespace itransition_task4_server.Endpoints.Auth.DTOs
{
    public sealed record RegisterRequest(string FullName,string Email, string Password);
}
