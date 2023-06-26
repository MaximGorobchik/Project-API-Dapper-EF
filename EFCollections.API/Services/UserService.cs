using EFCatalogs.DAL.Data.Interfaces;
using EFCatalogs.Interfaces;
using main.Models.Users;

namespace EFCatalogs.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _unitOfWork._UsersRepository.GetAllAsync();
        }

        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await _unitOfWork._UsersRepository.GetByIdAsync(id);
        }

        public async Task<int> AddUserAsync(Users user)
        {
           return await _unitOfWork._UsersRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(int id, Users user)
        {
            var existingUser = await _unitOfWork._UsersRepository.GetByIdAsync(id);
            existingUser.Username = user.Username;
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;
            existingUser.Birthdate = user.Birthdate;
            existingUser.Age = user.Age;
            existingUser.Email = user.Email;
            await _unitOfWork._UsersRepository.UpdateAsync(existingUser);
        }

        public async Task DeleteUserAsync(int id)
        {
           await _unitOfWork._UsersRepository.DeleteAsync(id);
        }
    }
}
