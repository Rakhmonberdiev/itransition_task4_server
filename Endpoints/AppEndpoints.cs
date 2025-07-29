using itransition_task4_server.Endpoints.Auth;
using itransition_task4_server.Endpoints.Users;

namespace itransition_task4_server.Endpoints
{
    public static class AppEndpoints
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGroup("auth").WithTags("Auth").MapAuthEndpoints();
            app.MapGroup("users").WithTags("Users").MapUserEndpoints();
            return app;
        }
    }
}
