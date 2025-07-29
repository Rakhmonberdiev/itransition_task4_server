using itransition_task4_server.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace itransition_task4_server.Data.Seed
{
    public static class UserSeeder
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (await userManager.Users.AnyAsync()) return;

            for (int i = 1; i <= 50; i++)
            {
                var user = new AppUser
                {
                    UserName = $"user{i}",
                    Email = $"user{i}@gmail.com",
                    EmailConfirmed = true,
                    RegisteredAt = DateTime.UtcNow.AddDays(-i),
                    LastLoginAt = DateTime.UtcNow.AddMinutes(-i * 10),
                    IsBlocked = i % 7 == 0
                };
                await userManager.CreateAsync(user, "1");
            }

        }
    }
}
