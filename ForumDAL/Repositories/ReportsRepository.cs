using System.Data;
using System.Data.SqlClient;
using Dapper;
using main.Models.Categories;
using main.Models.Reports;
using ReportService.DAL.Repositories.Interfaces;
using ReportService.Repositories;

namespace ReportService.DAL.Repositories
{
    public class ReportsRepository : GenericRepository<Reports>, IReportsRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDbTransaction _dbTransaction;
        public ReportsRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
            : base(sqlConnection, dbTransaction, "Reports")
        {
            _sqlConnection = sqlConnection;
            _dbTransaction = dbTransaction;
        }
        /*public async Task InsertAsync(Reports reports)
        {
            string query = "INSERT INTO Reports (CategoryID, StatusID, OpenDate, CloseDate, Description, UserID, EmployeeID) VALUES (@CategoryID, @StatusID, @OpenDate, @CloseDate, @Description, @UserID, @EmployeeID)";

            await _sqlConnection.ExecuteAsync(query, reports, transaction: _dbTransaction);
        }*/
    }
}
