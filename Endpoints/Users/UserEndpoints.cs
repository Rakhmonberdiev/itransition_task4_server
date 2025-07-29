namespace itransition_task4_server.Endpoints.Users
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGetUsersEndpoint();
            return app;
        }
    }
}
