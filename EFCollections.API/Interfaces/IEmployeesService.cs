

using main.Models.Employees;

namespace EFCatalogs.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employees>> GetAllEmployeesAsync();
        Task<Employees> GetEmployeeByIdAsync(int id);
        Task<int> AddEmployeeAsync(Employees employee);
        Task UpdateEmployeeAsync(int id, Employees employee);
        Task DeleteEmployeeAsync(int id);
    }
}
