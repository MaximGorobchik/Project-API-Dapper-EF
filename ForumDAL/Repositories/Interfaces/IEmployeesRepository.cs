
using main.Models.Employees;
using ReportService.Repositories.Interfaces;

namespace ReportService.DAL.Repositories.Interfaces
{
    public interface IEmployeesRepository: IGenericRepository<Employees>
    {
        //Task InsertAsync(Employees employee);
    }
}
