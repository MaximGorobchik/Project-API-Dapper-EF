
namespace ReportService.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoriesRepository CategoriesRepository { get; }
        IDepartmentsRepository DepartmentsRepository { get; }
        IEmployeesRepository EmployeesRepository { get; }
        IReportsRepository ReportsRepository { get; }
        IStatusRepository StatusRepository { get; }
        IUsersRepository UsersRepository { get; }
    }
}
