using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using main.Models.Employees;
using main.Models.Users;
using ReportService.DAL.Repositories.Interfaces;
using ReportService.Repositories;

namespace ReportService.DAL.Repositories
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IDbTransaction _dbTransaction;
        public UsersRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
            : base(sqlConnection, dbTransaction, "Users")
        {
            _sqlConnection = sqlConnection;
            _dbTransaction = dbTransaction;
        }
        /*public async Task InsertAsync(Users users)
        {
            string query = "INSERT INTO Users (Username, Name, Password, Birthdate, Age, Email) VALUES " +
                "(@Username, @Name, @Password, @Age, @Email)";

            await _sqlConnection.ExecuteAsync(query, users, transaction: _dbTransaction);
        }*/
        public async Task<Users> GetUserByUsernameAndPassword(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            var parameters = new { Username = username, Password = password };

            return await _sqlConnection.QueryFirstOrDefaultAsync<Users>(query, parameters);
        }
    }
}
