using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Employees;

namespace EFCatalogs.DAL.Data.Repositories
{
    public class EmployeesRepository : GenericRepository<Employees>, IEmployeesRepository
    {

        public EmployeesRepository(ReportContext reportContext)
            : base(reportContext)
        {
        }
    }
}
