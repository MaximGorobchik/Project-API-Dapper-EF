using main.Models.Employees;

namespace EFCatalogs.DAL.Data.Interfaces
{
    public interface IEmployeesRepository : IGenericRepository<Employees>
    {
        //Task InsertAsync(Employees employee);
    }
}
