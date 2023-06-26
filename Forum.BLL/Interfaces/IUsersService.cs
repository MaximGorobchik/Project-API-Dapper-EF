using main.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportService.BLL.Services.Interfaces
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
