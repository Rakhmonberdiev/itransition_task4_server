using itransition_task4_server.Data;
using itransition_task4_server.Endpoints.Users.DTOs;
using itransition_task4_server.Helpers;
using itransition_task4_server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace itransition_task4_server.Services
{
    public class UserService(AppDbContext db) : IUserService
    {


        public async Task<PagedResponse<UserDTO>> GetUsersAsync(GetUsersQuery req)
        {
            var query = db.Users.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(req.Search))
            {
                var term = req.Search.Trim();
                query = query.Where(u =>
                    u.FullName!.Contains(term) ||
                    u.Email!.Contains(term));
            }
            query = query.OrderByDescending(u => u.LastLoginAt);
            var total = await query.CountAsync();
            var items = await query
                .Skip((req.Page - 1) * req.PageSize)
                .Take(req.PageSize)
                .Select(u => new UserDTO(
                    u.Id,
                    u.FullName!,
                    u.Email!,
                    u.LastLoginAt,
                    u.IsBlocked
                ))
                .ToListAsync();

            return new PagedResponse<UserDTO>(
                Items: items,
                TotalCount: total,
                Page: req.Page,
                PageSize: req.PageSize
            );
        }

        public Task BlockUsersAsync(IEnumerable<Guid> ids)
            => SetBlockedStateAsync(ids, true);
        public Task UnBlockUsersAsync(IEnumerable<Guid> ids)
            => SetBlockedStateAsync(ids, false);

        private Task SetBlockedStateAsync(IEnumerable<Guid> ids, bool blocked)
        {
            return db.Users
                .Where(u => ids.Contains(u.Id))
                .ExecuteUpdateAsync(builder =>builder.SetProperty(u => u.IsBlocked, blocked));
        }
        public Task DeleteUsersAsync(IEnumerable<Guid> ids)
        {
            return db.Users
                .Where(u => ids.Contains(u.Id))
                .ExecuteDeleteAsync();
        }
    }
}
