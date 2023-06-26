
using main.Models.Departments;

namespace ReportService.BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Departments>> GetAllDepartmentsAsync();
        Task<Departments> GetDepartmentByIdAsync(int id);
        Task<int> AddDepartmentAsync(Departments department);
        Task UpdateDepartmentAsync(int id, Departments department);
        Task DeleteDepartmentAsync(int id);
    }
}
