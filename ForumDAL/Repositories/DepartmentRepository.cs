using System.Data;
using System.Data.SqlClient;
using Dapper;
using main.Models.Categories;
using main.Models.Departments;
using ReportService.DAL.Repositories.Interfaces;
using ReportService.Repositories;

namespace ReportService.DAL.Repositories
{
    public class DepartmentRepository : GenericRepository<Departments>, IDepartmentsRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDbTransaction _dbTransaction;
        public DepartmentRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
            : base(sqlConnection, dbTransaction, "Departments")
        {
            _sqlConnection = sqlConnection;
            _dbTransaction = dbTransaction;
        }
        /*public async Task InsertAsync(Departments departments)
        {
            string query = "INSERT INTO Departments (Name) VALUES (@Name)";

            await _sqlConnection.ExecuteAsync(query, departments, transaction: _dbTransaction);
        }*/
    }
}
