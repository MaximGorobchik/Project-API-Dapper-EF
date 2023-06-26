using System.Data;
using System.Data.SqlClient;
using Dapper;
using main.Models.Employees;
using main.Models.Status;
using ReportService.DAL.Repositories.Interfaces;
using ReportService.Repositories;

namespace ReportService.DAL.Repositories
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDbTransaction _dbTransaction;
        public StatusRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
            : base(sqlConnection, dbTransaction, "Status")
        {
            _sqlConnection = sqlConnection;
            _dbTransaction = dbTransaction;
        }
        /*public async Task InsertAsync(Status status)
        {
            string query = "INSERT INTO Status (Label) VALUES (@Label)";

            await _sqlConnection.ExecuteAsync(query, status, transaction: _dbTransaction);
        }*/
    }
}
