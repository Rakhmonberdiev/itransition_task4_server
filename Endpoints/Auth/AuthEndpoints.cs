namespace itransition_task4_server.Endpoints.Auth
{
    public static class AuthEndpoints
    {
        public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapLoginEndpoint();
            app.MapRegisterEndpoint();
            app.MapMeEndpoint();
            app.MapLogoutEndpoint();
            return app;
        }
    }
}
