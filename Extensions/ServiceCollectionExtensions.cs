using FluentValidation;

namespace itransition_task4_server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContextServices(conf);
            services.AddIdentityServices();
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            return services;
        }
        public static void UseAppMiddlewares(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
