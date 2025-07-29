using itransition_task4_server.Data;
using Microsoft.EntityFrameworkCore;

namespace itransition_task4_server.Extensions
{
    public static class DbExtensions
    {
        public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(conf.GetConnectionString("PostgresConnection")));


            return services;
        }
    }
}
