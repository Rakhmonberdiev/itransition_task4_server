using itransition_task4_server.Endpoints.Users.DTOs;
using itransition_task4_server.Helpers;

namespace itransition_task4_server.Services.Interfaces
{
    public interface IUserService
    {
        Task<PagedResponse<UserDTO>> GetUsersAsync(GetUsersQuery req);
        Task BlockUsersAsync(IEnumerable<Guid> ids);
        Task UnBlockUsersAsync(IEnumerable<Guid> ids);
    }
}
