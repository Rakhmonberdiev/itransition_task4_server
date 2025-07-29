using Microsoft.AspNetCore.Identity;

namespace itransition_task4_server.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
        public bool IsBlocked { get; set; } = false;
    }
}
