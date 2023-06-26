using EFCatalogs.DAL.Data.Interfaces;
using EFCatalogs.Interfaces;
using main.Models.Departments;

namespace EFCatalogs.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Departments>> GetAllDepartmentsAsync()
        {
            // Виконати потрібні операції для отримання всіх департаментів
            return await _unitOfWork._DepartmentsRepository.GetAllAsync();
        }

        public async Task<Departments> GetDepartmentByIdAsync(int id)
        {
            // Виконати потрібні операції для отримання департаменту за ідентифікатором
            return await _unitOfWork._DepartmentsRepository.GetByIdAsync(id);
        }

        public async Task<int> AddDepartmentAsync(Departments department)
        {
            // Виконати потрібні операції для додавання нового департаменту
            return await _unitOfWork._DepartmentsRepository.AddAsync(department);
        }

        public async Task UpdateDepartmentAsync(int id, Departments department)
        {
            // Виконати потрібні операції для оновлення департаменту
            var existingDepartment = await _unitOfWork._DepartmentsRepository.GetByIdAsync(id);
            if (existingDepartment != null)
            {
                // Виконати оновлення департаменту
                existingDepartment.Name = department.Name;
                await _unitOfWork._DepartmentsRepository.UpdateAsync(existingDepartment);
            }
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            // Виконати потрібні операції для видалення департаменту за ідентифікатором
            await _unitOfWork._DepartmentsRepository.DeleteAsync(id);
        }
    }
}
