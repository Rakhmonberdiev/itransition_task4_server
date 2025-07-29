namespace itransition_task4_server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContextServices(conf);
            services.AddIdentityServices();
            return services;
        }
    }
}
