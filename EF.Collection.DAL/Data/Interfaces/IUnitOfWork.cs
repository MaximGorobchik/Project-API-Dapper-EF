namespace EFCatalogs.DAL.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoriesRepository _CategoriesRepository { get; }
        IDepartmentsRepository _DepartmentsRepository { get; }
        IEmployeesRepository _EmployeesRepository { get; }
        IReportsRepository _ReportsRepository { get; }
        IStatusRepository _StatusRepository { get; }
        IUsersRepository _UsersRepository { get; }

        Task SaveChangesAsync();
    }
}
