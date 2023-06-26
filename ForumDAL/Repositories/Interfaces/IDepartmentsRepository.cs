
using main.Models.Departments;
using ReportService.Repositories.Interfaces;

namespace ReportService.DAL.Repositories.Interfaces
{
    public interface IDepartmentsRepository: IGenericRepository<Departments>
    {
        //Task InsertAsync(Departments departments);
    }
}
