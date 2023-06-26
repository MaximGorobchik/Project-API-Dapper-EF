using EFCatalogs.DAL.Data.Interfaces;
using main.Models.Departments;

namespace EFCatalogs.DAL.Data.Repositories
{
    public class DepartmentRepository : GenericRepository<Departments>, IDepartmentsRepository
    {

        public DepartmentRepository(ReportContext reportContext)
            : base(reportContext)
        {
        }
    }
}
