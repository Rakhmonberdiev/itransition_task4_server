using itransition_task4_server.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace itransition_task4_server.Data.Seed
{
    public static class DbInitializer
    {
        public static async Task InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (db.Database.GetPendingMigrations().Any()) await db.Database.MigrateAsync();
            await UserSeeder.SeedUsersAsync(userManager);
        }
    }
}
