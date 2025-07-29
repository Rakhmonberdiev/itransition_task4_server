using itransition_task4_server.Endpoints.Auth;

namespace itransition_task4_server.Endpoints
{
    public static class AppEndpoints
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGroup("auth").WithTags("Auth").MapAuthEndpoints();
            return app;
        }
    }
}
