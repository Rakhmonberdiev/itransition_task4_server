using FluentValidation;
using itransition_task4_server.Services;
using itransition_task4_server.Services.Interfaces;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace itransition_task4_server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContextServices(conf);
            services.AddIdentityServices();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            services.AddScoped<IUserService, UserService>();
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
