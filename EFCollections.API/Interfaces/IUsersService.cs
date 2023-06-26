using main.Models.Users;

namespace EFCatalogs.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIdAsync(int id);
        Task<int> AddUserAsync(Users user);
        Task UpdateUserAsync(int id, Users user);
        Task DeleteUserAsync(int id);
    }
}
