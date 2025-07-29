using itransition_task4_server.Data.Entities;
using itransition_task4_server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace itransition_task4_server.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {

            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AppDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

            services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddCookie(IdentityConstants.ApplicationScheme, options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromHours(1);
                    options.SlidingExpiration = true;
                    options.LoginPath = "/auth/login";
                    options.LogoutPath = "/auth/logout";
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnValidatePrincipal = async ctx =>
                        {
                            var userId = ctx.Principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                            if (userId is null)
                            {
                                ctx.RejectPrincipal();
                                return;
                            }
                            var userManager = ctx.HttpContext.RequestServices
                                                 .GetRequiredService<UserManager<AppUser>>();
                            var user = await userManager.FindByIdAsync(userId);

                            if (user is null || user.IsBlocked)
                            {
                                ctx.RejectPrincipal();
                                await ctx.HttpContext.SignOutAsync();
                            }
                        }
                    };
                });
            services.AddAuthorization();
            return services;
        }
    }
}
