using System.Data;
using System.Data.SqlClient;
using Dapper;
using main.Models.Categories;
using main.Models.Employees;
using ReportService.DAL.Repositories.Interfaces;
using ReportService.Repositories;

namespace ReportService.DAL.Repositories
{
    public class EmployeesRepository : GenericRepository<Employees>, IEmployeesRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDbTransaction _dbTransaction;
        public EmployeesRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
            : base(sqlConnection, dbTransaction, "Employees")
        {
            _sqlConnection = sqlConnection;
            _dbTransaction = dbTransaction;
        }
        /*public async Task InsertAsync(Employees employees)
        {
            string query = "INSERT INTO Employees (Firstname, Lastname, Birthdate, Age, DepartmentID) VALUES (@Firstname, @Lastname, @Birthdate, @Age, @DepartmentID)";

            await _sqlConnection.ExecuteAsync(query, employees, transaction: _dbTransaction);
        }*/
    }
}
