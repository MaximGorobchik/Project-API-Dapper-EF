using EFCatalogs.DAL.Data.Interfaces;

namespace EFCatalogs.DAL.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ReportContext databaseContext;

        public ICategoriesRepository _CategoriesRepository { get; }
        public IDepartmentsRepository _DepartmentsRepository { get; }

        public IEmployeesRepository _EmployeesRepository { get; }

        public IReportsRepository _ReportsRepository { get; }

        public IStatusRepository _StatusRepository { get; }

        public IUsersRepository _UsersRepository { get; }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(
             ReportContext databaseContext,
             ICategoriesRepository categoriesRepository, IDepartmentsRepository departmentsRepository, IEmployeesRepository employeesRepository,
             IReportsRepository reportsRepository, IStatusRepository statusRepository, IUsersRepository usersRepository)
        {
            this.databaseContext = databaseContext;

            _CategoriesRepository = categoriesRepository;
            _DepartmentsRepository = departmentsRepository;
            _EmployeesRepository = employeesRepository;
            _ReportsRepository = reportsRepository;
            _StatusRepository = statusRepository;
            _UsersRepository = usersRepository;
        }
    }
}
