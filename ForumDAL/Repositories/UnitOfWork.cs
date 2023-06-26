using ReportService.DAL.Repositories.Interfaces;
using System.Data;

namespace ForumDAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        ICategoriesRepository _CategoriesRepository { get; }
        IDepartmentsRepository _DepartmentsRepository { get; }
        IEmployeesRepository _EmployeesRepository { get; }
        IReportsRepository _ReportsRepository { get; }
        IStatusRepository _StatusRepository { get; }
        IUsersRepository _UsersRepository { get; }

        public ICategoriesRepository CategoriesRepository => throw new NotImplementedException();

        public IDepartmentsRepository DepartmentsRepository => throw new NotImplementedException();

        public IEmployeesRepository EmployeesRepository => throw new NotImplementedException();

        public IReportsRepository ReportsRepository => throw new NotImplementedException();

        public IStatusRepository StatusRepository => throw new NotImplementedException();

        public IUsersRepository UsersRepository => throw new NotImplementedException();

        readonly IDbTransaction _dbTransaction;

        public UnitOfWork(
        ICategoriesRepository CategoriesRepository,
        IDepartmentsRepository DepartmentsRepository,
        IEmployeesRepository EmployeesRepository,
        IReportsRepository ReportsRepository,
        IStatusRepository StatusRepository,
        IUsersRepository UsersRepository,
        IDbTransaction dbTransaction)
        {
            _CategoriesRepository = CategoriesRepository;
            _DepartmentsRepository = DepartmentsRepository;
            _EmployeesRepository = EmployeesRepository;
            _ReportsRepository = ReportsRepository;
            _StatusRepository = StatusRepository;
            _UsersRepository = UsersRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
                // By adding this we can have muliple transactions as part of a single request
                //_dbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }
        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}