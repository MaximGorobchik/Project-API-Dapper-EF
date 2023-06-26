using main.Models.Users;
using ReportService.Repositories.Interfaces;

namespace ReportService.DAL.Repositories.Interfaces
{
    public interface IUsersRepository: IGenericRepository<Users>
    {
        //Task InsertAsync(Users user);
        Task<Users> GetUserByUsernameAndPassword(string username, string password);
    }
}
