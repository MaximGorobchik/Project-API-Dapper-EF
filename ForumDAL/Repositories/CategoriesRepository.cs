using System.Data;
using System.Data.SqlClient;
using Dapper;
using main.Models.Categories;
using main.Models.Departments;
using ReportService.DAL.Repositories.Interfaces;
using ReportService.Repositories;

namespace ReportService.DAL.Repositories
{
    public class CategoriesRepository : GenericRepository<Categories>, ICategoriesRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDbTransaction _dbTransaction;

        public CategoriesRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
            : base(sqlConnection, dbTransaction, "Categories")
        {
            _sqlConnection = sqlConnection;
            _dbTransaction = dbTransaction;
        }
        /*public async Task InsertAsync(Categories categories)
        {
            string query = "INSERT INTO Categories (Name, DepartmentID) VALUES (@Name, @DepartmentID)";

            await _sqlConnection.ExecuteAsync(query, categories, transaction: _dbTransaction);
        }*/
    }
}
