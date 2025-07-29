using itransition_task4_server.Data.Entities;

namespace itransition_task4_server.Endpoints
{
    public static class AppEndpoints
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapIdentityApi<AppUser>();
            return app;
        }
    }
}
